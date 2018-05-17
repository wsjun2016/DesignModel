using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel._2.简单工厂
{
    //简单工厂
    //只抽象一个产品类型
    //就一个工厂根据传入的种类字段，造出单个抽象产品的不同实例

    public abstract class Car
    {
        public abstract void Display();
    }
    public class DaZhong : Car
    {
        public override void Display()
        {
            Console.WriteLine("大众");
        }
    }
    public class DongFeng : Car
    {
        public override void Display()
        {
            Console.WriteLine("东风");
        }
    }

    public class SimpleFactory
    {
        public static Car Create(CarType type)
        {
            Car car = null;

            switch (type)
            {
                case CarType.DaZhong: car = new DaZhong();break;
                case CarType.DongFeng:car = new DongFeng();break;
            }

            return car;
        }
    }

    public enum CarType
    {
        DaZhong,
        DongFeng
    }
}
