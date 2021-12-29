using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Class1
    {
        public delegate void FooDelegate(string s);

        static void Main(string[] args)

        {

            Console.WriteLine("主线程." + Thread.CurrentThread.ManagedThreadId);

            FooDelegate fooDelegate = Foo;


            //执行完委托才执行BeginInvoke里的FooComepleteCallback
            fooDelegate.BeginInvoke("Hello world.",

                FooComepleteCallback, fooDelegate);

            Console.WriteLine("主线程继续执行..." + Thread.CurrentThread.ManagedThreadId);



            Console.WriteLine("Press any key to continue...");

            Console.ReadKey(true);

        }

        public static void Foo(string s)
        {

            Console.WriteLine("函数当前线程：" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(s);

            Thread.Sleep(1000);
        }

        //回调方法要求
        //1.返回类型为void
        //2.只有一个参数IAsyncResult

        public static void FooComepleteCallback(IAsyncResult result)

        {

            Console.WriteLine("回调函数所在线程：" + Thread.CurrentThread.ManagedThreadId);

            (result.AsyncState as FooDelegate).EndInvoke(result);

            Console.WriteLine("回调函数线程结束." + result.AsyncState.ToString());

        }
    }
}
