using DesignModel.建造型模式._2.简单工厂;
using DesignModel.建造型模式._3.工厂方法;
using DesignModel.建造型模式._4.抽象工厂;
using DesignModel.建造型模式._5.建造者模式;
using DesignModel.建造型模式._6.原型模式;
using DesignModel.建造型模式._1.单例模式;
using System;
using DesignModel.结构型模式._7.适配器模式;
using DesignModel.结构型模式._8.桥接模式;

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

            #region 建造者模式

            ////一般的建造者模式
            //Director director = new Director();
            //IBuilder dellBuilder = new DellBuilder();
            //director.Construct(dellBuilder);
            //Computer dell = dellBuilder.GetComputer();
            //Console.WriteLine($"{dell.Id}   {dell.Name}");

            //IBuilder lenoveBuilder = new LenoveBuilder();
            //director.Construct(lenoveBuilder);
            //Computer lenove = lenoveBuilder.GetComputer();
            //Console.WriteLine($"{lenove.Id}   {lenove.Name}");

            ////对外做扩展的建造者模式
            //Computer2Builder builder = new Computer2Builder();
            //Computer2 shenzhou= builder.Set(option=> {
            //    option.Id = "3";
            //    option.Name = "神州";
            //}).GetComputer();
            //Console.WriteLine($"{shenzhou.Option.Id}   {shenzhou.Option.Name}");

            #endregion

            #region 原型模式

            //PrototypeA a = new PrototypeA();
            //a.DaZhong = SimpleFactory.Create(CarType.DaZhong);
            //a.Name = "A";
            //a.DaZhong.Name = "大众A";
            //Console.WriteLine($"{a.Name} {a.DaZhong.Name}");

            //PrototypeA b = a.WiseClone() as PrototypeA;
            //a.Name = "B";
            //a.DaZhong.Name = "大众B";
            //Console.WriteLine($"{b.Name} {b.DaZhong.Name}");

            //PrototypeA c = a.DeepClone() as PrototypeA;
            //a.Name = "C";
            //a.DaZhong.Name = "大众C";
            //Console.WriteLine($"{c.Name} {c.DaZhong.Name}");

            #endregion

            #region 适配器模式

            ////源接口
            //TwoHole aTwoHole = new ATwoHole();
            //aTwoHole.TwoHoleRequest();
            //TwoHole bTwoHole = new BTwoHole();
            //bTwoHole.TwoHoleRequest();

            ////类适配器的目标接口
            ////只能适配单个源接口
            //IThreeHole aThreeHole = new AClassAdapter();
            //aThreeHole.ThreeHoleRequest();
            ////类适配器的目标接口
            ////只能适配单个源接口
            //IThreeHole bThreeHole = new BClassAdapter();
            //bThreeHole.ThreeHoleRequest();

            ////对象适配器的目标接口
            ////可以一次性适配多个源接口
            //IThreeHole abThreeHole = new ObjectAdapter(aTwoHole,bTwoHole);
            //abThreeHole.ThreeHoleRequest();

            #endregion

            #region 桥接模式

            //第一种
            //Brush brush = new BigBrush();
            //brush.SetColor(new Red());
            //brush.Paint();

            //brush.SetColor(new Black());
            //brush.Paint();

            //brush = new SmallBrush();
            //brush.SetColor(new Red());
            //brush.Paint();

            //第二种
            //Abstraction abstraction = new ObjectAbstraction();
            //abstraction.Implementor = new AImplementor();
            //abstraction.Operation();

            //abstraction.Implementor = new BImplementor();
            //abstraction.Operation();

            #endregion

            Console.ReadKey();
        }
    }
}
