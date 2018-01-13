using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppDemoWithSimpleInjector
{
    public class MyService: IMyService
    {
        private Guid _guid;

        public MyService()
        {
            _guid = Guid.NewGuid();
        }

        public string HelloWorld()
        {
            return $"Hello world! instance: {_guid}";
        }
    }
}
