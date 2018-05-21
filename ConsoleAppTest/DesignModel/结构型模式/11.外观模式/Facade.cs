using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._11.外观模式
{
    //外观模式
    //注重 简化接口，简化客户端对子系统内部复杂接口的操作
    //集合子系统内部各个复杂的接口，提供一个一致对外的高层接口，使得 客户端 通过该高层接口 能更加容易的访问子系统的各个接口
    //将客户端与子系统解耦
    //使得子系统内部发生变化时，客户端并不需要更改任何逻辑。
    //外观模式是提供一个统一的接口来简化接口
    
    public class Facade
    {
        //集合众多子系统，并提供一个简单的对外接口
        //使得客户端直接与外观类对话
        private SubSystemA _a;
        private SubSystemB _b;
        private SubSystemC _c;
        private SubSystemD _d;

        public Facade()
        {
            _a=new SubSystemA();
            _b=new SubSystemB();
            _c=new SubSystemC();
            _d=new SubSystemD();
        }

        public void Operation()
        {
            _a.Execute();
            _b.Print();
            _c.Display();
            _d.Show();
        }
    }

    //子系统A
    public class SubSystemA
    {
        public void Execute()
        {
            Console.WriteLine("SubSystemA");
        }
    }

    //子系统B
    public class SubSystemB {
        public void Print() {
            Console.WriteLine("SubSystemB");
        }
    }

    //子系统C
    public class SubSystemC {
        public void Display() {
            Console.WriteLine("SubSystemC");
        }
    }


    //子系统D
    public class SubSystemD {
        public void Show() {
            Console.WriteLine("SubSystemD");
        }
    }




}
