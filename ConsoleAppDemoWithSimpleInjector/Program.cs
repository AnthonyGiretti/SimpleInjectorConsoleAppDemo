using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Threading;

namespace ConsoleAppDemoWithSimpleInjector
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register<IMyService, MyService>(Lifestyle.Singleton);

            container.Verify();
        }


        static void Main(string[] args)
        {
            while (true)
            {
                using (ThreadScopedLifestyle.BeginScope(container))
                {
                    var service = container.GetInstance<IMyService>();

                    Console.WriteLine(service.HelloWorld());
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
