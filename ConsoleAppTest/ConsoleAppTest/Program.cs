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
using DesignModel.结构型模式._13.代理模式;
using DesignModel.行为型模式._14.模板方法;
using Newtonsoft.Json;
using DesignModel.行为型模式._15.命令模式;
using DesignModel.行为型模式._16.迭代器模式;
using System.Collections;
using DesignModel.行为型模式._17.观察者模式;
using DesignModel.行为型模式._18.解释器模式;
using DesignModel.行为型模式._19.中介者模式;
using DesignModel.行为型模式._20.职责链模式;
using DesignModel.行为型模式._21.备忘录模式;
using System.Collections.Generic;

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

            //FlyweightFactory f=new FlyweightFactory();
            //f.Items.Add('A',new EnglishCharacter('A'));
            //f.Items.Add('B', new EnglishCharacter('B'));
            //f.Items.Add('C', new EnglishCharacter('C'));
            //f.Items.Add("天子", new ChineseCharacter("天子"));

            ////以下三个A 获取的 是同一个享元对象
            //EnglishCharacter A1 = f.GetCharacter('A') as EnglishCharacter;
            //A1.Operation(1);

            //EnglishCharacter A2 = f.GetCharacter('A') as EnglishCharacter;
            //A2.Operation(2);

            //EnglishCharacter A3 = f.GetCharacter('A') as EnglishCharacter;
            //A3.Operation(3);


            //EnglishCharacter D = f.GetCharacter('D') as EnglishCharacter;
            ////如果没有，需要创建，并保存到享元工厂中
            //if (D == null)
            //{
            //    D = new EnglishCharacter('D');
            //    f.Items.Add('D',D);
            //}
            //D.Operation(1);

            //EnglishCharacter D2 = f.GetCharacter('D') as EnglishCharacter;
            //D2.Operation(3);

            ////使用中文
            //ChineseCharacter chineseCharacter = f.GetCharacter("天子") as ChineseCharacter;
            //chineseCharacter.Operation(3);

            #endregion

            #region 代理模式

            //MathProxy proxy = new MathProxy();
            //Console.WriteLine(proxy.Min(1,3));

            #endregion

            #region 模板方法

            ////string json = "{\"SName\":\"张三\",\"SAge\":12}";
            //string json = "{\"TName\":\"李四\",\"TAge\":32}";
            //int actionId = 1002;

            //AjaxResult result = null;
            //switch (actionId)
            //{
            //    case 1001:
            //        result = new StudentHandler().Process(json);
            //        break;
            //    case 1002:
            //        result = new TeacherHandler().Process(json);
            //        break;
            //    default:
            //        result = AjaxResult.Null;
            //        Console.WriteLine("错误的接口！");
            //        break;
            //}

            ////返回结果
            //Console.WriteLine(JsonConvert.SerializeObject(result));

            #endregion

            #region 命令模式

            //MyDocument document = new MyDocument();
            //Command displayCommand = new DisplayCommand(document);
            //CommandInvoker invoker = new CommandInvoker();
            //invoker.SetCommand(displayCommand);
            //invoker.ExecuteCommand();

            //Command redoCommand = new RedoCommand(document);
            //invoker.SetCommand(redoCommand).ExecuteCommand();

            //Command undoCommand = new UndoCommand(document);
            //invoker.SetCommand(undoCommand).ExecuteCommand();

            #endregion

            #region 迭代器模式

            //int a = 1;
            //IMyList list = new MyList();
            //list.Add(a++);
            //list.Add(a++);
            //list.Add(a++);
            //list.Add(a++);
            //list.Add(a++);
            //list.Add(a++);
            //list.Add(a++);

            ////获取当前聚合对象的迭代器
            //IMyIterator iterator = list.GetIterator();

            ////开始迭代
            //while (iterator.MoveNext())
            //{
            //    Console.WriteLine(iterator.CurrentItem());
            //    iterator.Next();
            //}

            #endregion

            #region 使用框架自带的迭代器

            //StudentList list = new StudentList();
            //list.Add(new Student { SName="张三",SAge=10});
            //list.Add(new Student { SName = "李三", SAge = 11 });
            //list.Add(new Student { SName = "王三", SAge = 11 });
            //list.Add(new Student { SName = "赵三", SAge = 12 });
            //list.Add(new Student { SName = "钱三", SAge = 13 });
            //list.Add(new Student { SName = "孙三", SAge = 14 });

            ////只要有IEnumerator迭代器，就可以使用foreach进行迭代数据
            //foreach (Student obj in list)
            //    Console.WriteLine(obj.ToString());

            #endregion

            #region 观察者模式

            ////第一种实现，使用观察者接口
            //Subject subject = new BankAccount();            
            //subject.AddObserver(new Emailer("will@qq.com"));
            //subject.AddObserver(new Mobile("18282736255"));

            //subject.Status = 100;
            //subject.Work();

            ////第二种实现，使用Event事件
            //SubjectA subjectA = new BankAccountA();
            //subjectA.NotifyEvent += new NotifyEventHandler(new EmailerA("willA@qq.com").Update);
            //subjectA.NotifyEvent += new NotifyEventHandler(new MobileA("18282736255A").Update);
            //subjectA.Status = 100;
            //subjectA.Work();

            #endregion

            #region 解释器模式

            //string roman = "五亿七千三百零二万六千四百五十二";
            ////分解：((五)亿)((七千)(三百)(零)(二)万)((六千)(四百)(五十)(二))
            ////只有个位没有带单位，是一位，其他带单位的都是2位字符

            //MyContext context = new MyContext(roman);
            //ArrayList list = new ArrayList();
            //list.Add(new GeExpression());
            //list.Add(new ShiExpression());
            //list.Add(new BaiExpression());
            //list.Add(new QianExpression());
            //list.Add(new WanExpression());
            //list.Add(new YiExpression());

            //foreach (var exp in list)
            //    (exp as MyExpression).Interpreter(context);

            //Console.WriteLine(context.Data);


            #endregion

            #region 中介者模式

            ////创建一个中介者
            //Mediator chatroom = new ChatroomMediator();

            ////创建一些同事类
            //Colleague john = new Member("john");
            //Colleague linda = new Member("linda");
            //Colleague will = new Member("will");

            ////将同事类注册到中介者中
            //chatroom.Register(john).Register(linda).Register(will);

            ////开始同事类之间的中介交互
            //john.Send("linda", "hello");
            //linda.Send("will", "How are you today?");
            //will.Send("linda", "I'm fine");


            #endregion

            #region 职责链模式

            //MyOrderRequest request = new MyOrderRequest("扫把", 1001000);

            ////实例化处理者
            //Manager manager = new Manager("john");
            //FinancialManager fmanager = new FinancialManager("linda");
            //CEO ceo = new CEO("will");

            ////设置职责链
            //manager.NextHandler = fmanager;
            //fmanager.NextHandler = ceo;

            ////开始处理请求
            //manager.RequestProcess(request);

            #endregion

            #region 备忘录模式


            //List<PersonalTelephone> list = new List<PersonalTelephone>
            //{
            //    new PersonalTelephone{Name="张三",Telephone="11111111111"},
            //    new PersonalTelephone{Name="李四",Telephone="22222222222"},
            //    new PersonalTelephone{Name="王五",Telephone="33333333333"},
            //};

            ////实例化一个 发起人Originator对象
            //MobileOriginator originator = new MobileOriginator(list);
            //originator.Show();

            ////创建一个备忘录
            //MobileMemento memento = originator.CreateMemento();

            ////使用看守者来管理和保存备忘录
            //MobileCaretaker caretaker = new MobileCaretaker();
            //caretaker.MobileMemento = memento;

            //Console.WriteLine("改变originator的状态数据");
            ////改变发起人originator对象的状态
            //originator.PersonalTelephones.RemoveAt(0);
            //originator.Show();

            //Console.WriteLine("恢复originator的状态数据");
            ////使用备忘录恢复originator的数据
            //originator.SetMementoFrom(caretaker.MobileMemento);
            //originator.Show();
            



            #endregion

            Console.ReadKey();
        }

        private static void SubjectA_NotifyEvent(object sender)
        {
            throw new NotImplementedException();
        }
    }

    //IEnumerable就是框架自带的抽象聚合接口
    public class StudentList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new StudentListEnumerator(this);
        }
        public StudentList()
        {
            _array = new Student[_capacity];
        }

        private Student[] _array;
        private int _length = 0;
        public int _capacity = 10;
        public int Capacity => _capacity;
        public int Length => _length;
        public object GetElement(int index) => index < _length ? _array[index] : throw new IndexOutOfRangeException();
        public int Add(Student student)
        {
            if (_length < _capacity)
                _array[_length++] = student;
            else
            {
                _capacity += 10;
                Student[] tmp = new Student[_capacity];
                _array.CopyTo(tmp, 0);
                _array = tmp;
                Add(student);
            }
            return _length;
        }

    }

    //IEnumerator就是框架自带的抽象迭代器
    public class StudentListEnumerator : IEnumerator
    {
        private StudentList _list;
        private int _index = 0;
        public StudentListEnumerator(StudentList list) => _list = list;
        public object Current => _list.GetElement(_index++);

        public bool MoveNext()
        {
            return _index < _list.Length;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
