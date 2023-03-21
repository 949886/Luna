using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Luna.Core.Event;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        //        LunaListener listener = new LunaListener();

        [TestMethod]
        public void Test1()
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var thread = new Thread(ThreadExec);
            thread.Start();

            var obj = new LunaListener();
            var obj2 = new LunaListener2();
            EventBus.Default.Post(new Object());
            EventBus.Default.Post("");
            EventBus.Default.Post(1);
            EventBus.Default.Post(1.1);
            EventBus.Default.Unregister(obj2);
            EventBus.Default.Post(new Object());

        }


        [TestMethod]
        public void Test2()
        {
            while (true)
            {
                var obj = new LunaListener();
                EventBus.Default.Post(1);
                EventBus.Default.Unregister(obj);
            }
        }


        [TestMethod]
        public void Test3()
        {
            var a = Add(1, 2);
            Trace.WriteLine("Hello World!" + a);
        }


        [TestMethod]
        public void Test4()
        {
            var a = Luna.Cpp.CppTest.Add(1, 2);
            Trace.WriteLine("Hello World!" + a);
        }

        [TestMethod]
        public void Test5()
        {
            Trace.WriteLine("Hello World!");
        }


        [DllImport("Luna.cpp.dll")]
        private static extern int Add(int n1, int n2);

        private void ThreadExec()
        {

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public class LunaListener
        {
            public LunaListener()
            {
                EventBus.Default.Register(this);
            }

            ~LunaListener()
            {
                //                EventBus.Default.Unregister(this);
                //                Trace.WriteLine("LunaListener.Deinit");
            }

            public void Test(object args)
            {
                Trace.WriteLine("test");
            }

            [Subscribe]
            public void Callback(int args)
            {
                Trace.WriteLine("test");
            }
        }

        public class LunaListener2
        {
            public LunaListener2()
            {
                EventBus.Default.Register(this);
            }

            ~LunaListener2()
            {
                //            EventBus.Default.Unregister(this);
            }

            [Subscribe]
            public void Callback(object args)
            {
                Trace.WriteLine("test2");
            }

            [Subscribe]
            public void Callback(string args)
            {
                Trace.WriteLine("test4");
            }

            [Subscribe]
            public void Callback(int args)
            {
                Trace.WriteLine("test5");
            }

            [Subscribe]
            public void Callback(double args)
            {
                Trace.WriteLine("test6");
            }
        }
    }
}
