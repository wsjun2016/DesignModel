using DesignModel.建造型模式._02.简单工厂;
using DesignModel.建造型模式._03.工厂方法;
using DesignModel.建造型模式._04.抽象工厂;
using DesignModel.建造型模式._05.建造者模式;
using DesignModel.建造型模式._06.原型模式;
using DesignModel.建造型模式._01.单例模式;
using System;
using DesignModel.结构型模式._09.组合模式;
using DesignModel.结构型模式._07.适配器模式;
using DesignModel.结构型模式._08.桥接模式;
using DesignModel.结构型模式._10.装饰者模式;
using DesignModel.结构型模式._11.外观模式;
using DesignModel.结构型模式._12.享元模式;


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

            #region 组合模式

            //Component leafA=new Leaf("leafA");
            //leafA.Display(1);
            //Component leafB = new Leaf("leafB");
            //leafB.Display(1);

            //Component complex=new ComplexComponent("complex");
            //complex.Display(1);
            //complex.Add(leafA);
            //complex.Add(leafB);
            //complex.Display(1);

            #endregion

            #region 装饰者模式

            //Phone phone=new ApplePhone();
            //phone.Print();

            //Decorator decorator=new Sticker(phone);
            //decorator.Print();

            //Decorator d2=new Accessories(decorator);
            //d2.Print();

            #endregion

            #region 外观模式

            //Facade facade=new Facade();
            //facade.Operation();

            #endregion

            #region 享元模式

            FlyweightFactory f=new FlyweightFactory();
            f.Items.Add('A',new EnglishCharacter('A'));
            f.Items.Add('B', new EnglishCharacter('B'));
            f.Items.Add('C', new EnglishCharacter('C'));
            f.Items.Add("天子", new ChineseCharacter("天子"));

            //以下三个A 获取的 是同一个享元对象
            EnglishCharacter A1 = f.GetCharacter('A') as EnglishCharacter;
            A1.Operation(1);

            EnglishCharacter A2 = f.GetCharacter('A') as EnglishCharacter;
            A2.Operation(2);

            EnglishCharacter A3 = f.GetCharacter('A') as EnglishCharacter;
            A3.Operation(3);

           
            EnglishCharacter D = f.GetCharacter('D') as EnglishCharacter;
            //如果没有，需要创建，并保存到享元工厂中
            if (D == null)
            {
                D = new EnglishCharacter('D');
                f.Items.Add('D',D);
            }
            D.Operation(1);

            EnglishCharacter D2 = f.GetCharacter('D') as EnglishCharacter;
            D2.Operation(3);

            //使用中文
            ChineseCharacter chineseCharacter = f.GetCharacter("天子") as ChineseCharacter;
            chineseCharacter.Operation(3);

            #endregion





            Console.ReadKey();
        }
    }
}
