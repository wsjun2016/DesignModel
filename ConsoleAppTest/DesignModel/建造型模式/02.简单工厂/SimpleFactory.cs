using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._02.简单工厂
{
    //简单工厂
    //只抽象一个产品类型
    //就一个工厂根据传入的种类字段，造出单个抽象产品的不同实例
    [Serializable]
    public abstract class Car
    {
        public const string CarName = "";
        public string Name { get; set; }
        public void Display() {
            Console.WriteLine(Name);
        }
    }
    [Serializable]
    public class DaZhong : Car
    {
        public new const string CarName = nameof(DaZhong);
        public DaZhong()
        {
            Name = "大众";
        }     
    }
    [Serializable]
    public class DongFeng : Car
    {
        public new const string CarName = nameof(DongFeng);
        public DongFeng()
        {
            Name = "东风";
        }       
    }

    public class SimpleFactory
    {
        //直接根据 枚举类型 来判断生成
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

        //也可以根据 具体的类型名称 来生成
        public static Car Create(string carName)
        {
            Type type = Type.GetType($"{typeof(Car).Namespace}.{carName}");
            if (type == null) throw new Exception($"不支持{carName}对应的类型");
            return Activator.CreateInstance(type) as Car;
        }

    }

    public enum CarType
    {
        DaZhong,
        DongFeng
    }
}
