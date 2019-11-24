﻿using System;
using System.Collections.Generic;
using System.Linq;
using NWN.FinalFantasy.Core.Contracts;

// ReSharper disable once CheckNamespace
namespace NWN
{
    partial class Internal
    {
        public const uint OBJECT_INVALID = 0x7F000000;
        public static NWGameObject OBJECT_SELF { get; private set; } = OBJECT_INVALID;
        public static IApplication Application { get; }

        static Internal()
        {
            var appType = typeof(IApplication);
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.DefinedTypes)
                .SingleOrDefault(x => appType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

            if(type == null)
                throw new Exception("Could not find implementation of IApplication.");

            Application = (IApplication) Activator.CreateInstance(type);
        }

        public static void OnMainLoop(ulong frame)
        {
            try
            {
                Application.OnMainLoop(frame);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private struct ScriptContext
        {
            public NWGameObject OwnerObject;
            public string ScriptName;
        }
        private static readonly Stack<ScriptContext> ScriptContexts = new Stack<ScriptContext>();
        public static int OnRunScript(string script, uint oidSelf)
        {
            int ret = 0;
            OBJECT_SELF = oidSelf;
            ScriptContexts.Push(new ScriptContext { OwnerObject = oidSelf, ScriptName = script });
            try
            {
                ret = Application.OnRunScript(script, oidSelf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            ScriptContexts.Pop();
            OBJECT_SELF = ScriptContexts.Count == 0 ? OBJECT_INVALID : ScriptContexts.Peek().OwnerObject;
            return ret;
        }

        private struct Closure
        {
            public NWGameObject OwnerObject;
            public ActionDelegate Run;
        }
        private static ulong NextEventId = 0;
        private static readonly Dictionary<ulong, Closure> Closures = new Dictionary<ulong, Closure>();

        public static void OnClosure(ulong eid, uint oidSelf)
        {
            try
            {
                Closures[eid].Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Closures.Remove(eid);
        }

        public static void ClosureAssignCommand(NWGameObject obj, ActionDelegate func)
        {
            if (NativeFunctions.ClosureAssignCommand(obj.Self, NextEventId) != 0)
            {
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
            }
        }

        public static void ClosureDelayCommand(NWGameObject obj, float duration, ActionDelegate func)
        {
            if (NativeFunctions.ClosureDelayCommand(obj.Self, duration, NextEventId) != 0)
            {
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
            }
        }

        public static void ClosureActionDoCommand(NWGameObject obj, ActionDelegate func)
        {
            if (NativeFunctions.ClosureActionDoCommand(obj.Self, NextEventId) != 0)
            {
                Closures.Add(NextEventId++, new Closure { OwnerObject = obj, Run = func });
            }
        }
    }
}
