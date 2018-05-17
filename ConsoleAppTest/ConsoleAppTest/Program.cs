using DesignModel._2.简单工厂;
using DesignModel._3.工厂方法;
using DesignModel._4.抽象工厂;
using DesignModel.单例模式;
using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 单例模式

            //SingleTon singleTon = SingleTon.Instance;
            //SingleTon singleTon2 = SingleTon.Instance;
            //singleTon.Count = 1;
            //Console.WriteLine($"singleTon.Count={singleTon.Count}");
            //singleTon.Count += 1;
            //Console.WriteLine($"singleTon2.Count={singleTon2.Count}");

            #endregion

            #region 简单工厂

            //Car dazhong = SimpleFactory.Create(CarType.DaZhong);
            //dazhong.Display();

            //Car dongfeng = SimpleFactory.Create(CarType.DongFeng);
            //dongfeng.Display();

            #endregion

            #region 工厂方法

            ////首先得有一个生产白菜的工厂
            //BaiCaiFactory baiCaiFactory = new BaiCaiFactory();
            ////生产白菜
            //Food baicai = baiCaiFactory.CreateFood();
            //baicai.Display();

            ////首先得有一个生产西红柿的工厂
            //XiHongShiFactory xiHongShiFactory = new XiHongShiFactory();
            ////生产白菜
            //Food xihongshi = xiHongShiFactory.CreateFood();
            //xihongshi.Display();

            #endregion

            #region 抽象工厂

            //AbstractFactory chongqing = new ChongQingFactory();
            //chongqing.CreateCar().Display();
            //chongqing.CreateFood().Display();

            //AbstractFactory chengdu = new ChengDuFactory();
            //chengdu.CreateCar().Display();
            //chengdu.CreateFood().Display();

            #endregion


            Console.ReadKey();
        }
    }
}
