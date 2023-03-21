using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Luna.Cpp;

namespace Test
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // The code provided will print ‘Hello World’ to the console.
        //    // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

        //    var thread = new Thread(ThreadExec);
        //    thread.Start();

        //    Thread.Sleep(200);

        //    var a = CppTest.Add(1, 2);
        //    Console.WriteLine("Hello World!" + IsMainThread());


        //    Console.ReadKey();

        //    // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        //}

        private static void ThreadExec()
        {
            Console.WriteLine(IsMainThread());
        }

        [DllImport("Luna.Cpp.dll")]
        private static extern int Add(int n1, int n2);

        [DllImport("Luna.Cpp.dll")]
        private static extern int CurrentThreadID();

        [DllImport("Luna.Cpp.dll")]
        [return: MarshalAs(UnmanagedType.I1)]
        private static extern bool IsMainThread();
    }
}
