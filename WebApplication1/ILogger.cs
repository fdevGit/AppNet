using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public interface ITest { }
    public class TestClass : ITest { }

    public interface ITest2 { }
    public class TestClass2 : ITest { }

    public interface ITest3 { }
    public class TestClass3 : ITest { }

    public interface ITest4 { }
    public class TestClass4 : ITest { }

    public interface ILogger
    {
        void WriteLog(string text);
    }

    public class DbLogger : ILogger
    {
        ITest t1;
        ITest2 t2;
        ITest3 t3;
        ITest4 t4;
        public DbLogger(ITest _t1, ITest2 _t2, ITest3 _t3)
        {
            t1 = _t1; t2 = _t2; t3 = _t3;
        }
        public void WriteLog(string text)
        {
            throw new Exception("DbLogger");
        }
    }
    public class TextLogger : ILogger
    {
        public void WriteLog(string text)
        {
            throw new Exception("TextLogger");
        }
    }
}