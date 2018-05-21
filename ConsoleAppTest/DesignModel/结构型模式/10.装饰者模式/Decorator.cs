using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._10.装饰者模式
{
    //装饰者模式
    //注重 稳定接口，并在此前提下 扩展对象的功能

    //抽象出一个 构件类型
    //抽象出一个 装饰者类型，继承 抽象构件类型，再组合一个 抽象构件类型
    //装饰者类型 就是用来 扩展 具体抽象构件的功能

    //抽象出来的构件类型
    public abstract class Phone
    {
        public abstract void Print();
    }

    //抽象出来的 装饰者类型
    public abstract class Decorator:Phone
    {
        private Phone _phone;

        public Decorator(Phone phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            if(_phone!=null)
                _phone.Print();
        }
    }

    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("apple phone");
        }
    }

    //具体的装饰者类
    public class Sticker : Decorator
    {
        public Sticker(Phone phone) : base(phone)
        {
        }

        public override void Print()
        {
            base.Print();
            //添加一个新功能，以此来扩展Print功能
            AddSticker();
        }

        public void AddSticker()
        {
            Console.WriteLine("贴膜");
        }
    }

    public class Accessories : Decorator
    {
        public Accessories(Phone phone) : base(phone)
        {
        }

        public override void Print()
        {
            base.Print();
            //添加一个新功能，以此来扩展Print功能
            SetAccessores();
        }

        public void SetAccessores()
        {
            Console.WriteLine("挂件");
        }
    }


}
