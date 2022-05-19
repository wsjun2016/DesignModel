using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._10.装饰者模式 {
    //装饰者模式
    //注重 稳定接口，并在此前提下 扩展对象的功能

    //抽象出一个 构件类型
    //抽象出一个 装饰者类型，继承 抽象构件类型，再引用一个 抽象构件类型
    //装饰者类型 就是用来 扩展 具体抽象构件的功能
    //由 抽象构件类型 延伸出 具体构件类型 和 抽象装饰类型，继而 抽象装饰类型 延伸出 具体装饰类型。具体装饰类型 可以 扩展 具体构件类型 的功能
    //抽象构件类__
    //           |__具体构件类  <----扩展功能--|    
    //           |__抽象装饰类__               |
    //                          |__具体装饰类---

    //角色
    //抽象构件角色（Component）：声明封装器和被封装对象的公用接口。
    //具体构件角色（Concrete Component）：继承抽象构件，需要被装饰的类型。
    //装饰基类角色（Decorator）：引用一个构件（Component）对象的实例，并实现抽象构件接口，是具体装饰角色的基础抽象类。
    //具体装饰角色（Concrete Decorator）：定义了可动态添加到抽象构件的额外行为。具体装饰类会重写装饰基类的方法，并在调用父类方法之前或之后进行额外的行为。
    //客户端（Client）：可以使用多层装饰来封装构件，只要它能使用通用接口与所有对象互动即可。

    //应用场景
    //如果你希望在无需修改代码的情况下即可使用对象，且希望在运行时为对象新增额外的行为，可以使用装饰模式。
    //装饰能将业务逻辑组织为层次结构，你可为各层创建一个装饰，在运行时将各种不同逻辑组合成对象。由于这些对象都遵循通用接口，客户端代码能以相同的方式使用这些对象。
    //如果用继承来扩展对象行为的方案难以实现或者根本不可行，你可以使用该模式。
    //许多编程语言使用 final 最终 关键字来限制对某个类的进一步扩展。复用最终类已有行为的唯一方法是使用装饰模式：用封装器对其进行封装。

    //实现方式
    //1.确保业务逻辑可用一个基本组件及多个额外可选层次表示。
    //2.找出基本组件和可选层次的通用方法。创建一个组件接口并在其中声明这些方法。
    //3.创建一个具体组件类，并定义其基础行为。
    //4.创建装饰基类，使用一个成员变量存储指向被封装对象的引用。该成员变量必须被声明为组件接口类型，从而能在运行时连接具体组件和装饰。装饰基类必须将所有工作委派给被封装的对象。
    //5.确保所有类实现组件接口。
    //6.将装饰基类扩展为具体装饰。具体装饰必须在调用父类方法（总是委派给被封装对象）之前或之后执行自身的行为。 
    //7.客户端代码负责创建装饰并将其组合成客户端所需的形式。


    #region 示例代码一

    //抽象出来的构件类型
    public abstract class Phone
    {
        public abstract void Print();
    }

    //具体构件
    public class ApplePhone : Phone {
        public override void Print() {
            Console.WriteLine("apple phone");
        }
    }

    //抽象出来的 装饰者类型
    public abstract class Decorator:Phone
    {
        //引用一个抽象构件
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

    #endregion


    #region 示例代码二

    //抽象构件
    public interface IDataSource {
        void Write();
        string Read();
    }

    //具体构件
    public class MyDataSource : IDataSource {

        protected string FileName { get; set; }

        public MyDataSource(string fileName) {
            FileName = fileName;
        }
        public string Read() {
            Console.WriteLine($"从{FileName}文件中读出数据");
            return "xxx";
        }

        public void Write() {
            Console.WriteLine($"写入数据到{FileName}");
        }
    }

    //抽象装饰基类
    public abstract class DataSourceDecorator : IDataSource {
        private IDataSource _dataSource;
        public DataSourceDecorator(IDataSource dataSource) {
            _dataSource = dataSource;
        }

        public virtual string Read() {
            return _dataSource?.Read();
        }

        public virtual void Write() {
            _dataSource?.Write();
        }
    }

    //具体装饰基类
    public class EncryptDataSourceDecorator : DataSourceDecorator {
        public EncryptDataSourceDecorator(IDataSource dataSource) : base(dataSource) { }

        public override string Read() {
            var data = base.Read();
            Console.WriteLine($"对读取的数据{data}进行解密，并得到解密后的数据");
            return "yyy";
        }

        public override void Write() {
            Console.WriteLine($"对数据进行加密");
            base.Write();
        }
    }

    //具体装饰基类
    public class CompressionDataSourceDecorator : DataSourceDecorator {
        public CompressionDataSourceDecorator(IDataSource dataSource) : base(dataSource) { }

        public override string Read() {
            var data = base.Read();
            Console.WriteLine($"将数据{data}解压");
            return "zzz";
        }

        public override void Write() {
            Console.WriteLine("将数据压缩");
            base.Write();
        }
    }


    #endregion

}
