using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._03.工厂方法
{
    //工厂方法模式针对单个对象
    //抽象出来的工厂和抽象的产品是平级的

    public abstract class Food
    {
        public abstract void Display();
    }

    public abstract class FactoryMethodAbstract
    {
        public abstract Food CreateFood();
    }

    //具体建造产品的工厂和具体的产品类是平级的

    public class BaiCai : Food
    {
        public override void Display()
        {
            Console.WriteLine("白菜");
        }
    }

    public class BaiCaiFactory: FactoryMethodAbstract
    {
        public override Food CreateFood()
        {
            return new BaiCai();
        }
    }


    public class XiHongShi : Food
    {
        public override void Display()
        {
            Console.WriteLine("西红柿");
        }
    }

    public class XiHongShiFactory: FactoryMethodAbstract
    {
        public override Food CreateFood()
        {
            return new XiHongShi();
        }
    }



}
