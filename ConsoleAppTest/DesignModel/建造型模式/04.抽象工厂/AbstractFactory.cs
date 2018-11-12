using DesignModel.建造型模式._02.简单工厂;
using DesignModel.建造型模式._03.工厂方法;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._04.抽象工厂
{
    //抽象工厂
    //抽象工厂针对系列对象
    //抽象出来的工厂与抽象出来的系列抽象类同级
    //具体的工厂与具体的系列类型同级

   
   public abstract class AbstractFactory
    {       
        //建造汽车
        public abstract Car CreateCar();
        //建造食物
        public abstract Food CreateFood();
    }

    public class ChongQingFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new DaZhong();
        }

        public override Food CreateFood()
        {
            return new BaiCai();
        }
    }

    public class ChengDuFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new DongFeng();
        }

        public override Food CreateFood()
        {
            return new XiHongShi();
        }
    }

}
