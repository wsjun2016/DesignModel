using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._05.建造者模式 {
    //建造者模式 也可以叫 生成器模式
    //将对象构造代码从产品类中抽取出来，并将其放在一个名为生成器的独立对象中。
    //包含 主管类、生成器和产品
    //只抽象出生成器，因为生成器模式 是 使相同的构造过程 创建 不同的对象
    //将 构造 与 对象的表示 隔离
    //生成器模式让你能够分步骤创建复杂对象

    //角色
    //生成器（Builder）接口声明在所有类型生成器中通用的 产品构造步骤。
    //具体生成器（Concrete Builders）提供构造过程的不同实现。具体生成器也可以构造不遵循通用接口的产品。
    //产品（Products）是最终生成的对象。由不同生成器构造的产品无需属于同一类层次结构或接口。
    //主管（Director）类定义调用构造步骤的顺序，这样你就可以创建和复用特定的产品配置。
    //客户端（Client）必须将某个生成器对象与主管类关联。一般情况下，你只需通过主管类构造函数的参数进行一次性关联即可。此后主管类就能使用生成器对象完成后续所有的构造任务。但在客户端将生成器对象传递给主管类制造方法时还有另一种方式。在这种情况下，你在使用主管类生产产品时每次都可以使用不同的生成器。

    //相同的主管类 可以 接收 不同的具体生成器 生成 不同的产品

    //适用场景
    //使用生成器模式可避免“重叠构造函数（telescopicconstructor）”的出现。
    //假设你的构造函数中有十个可选参数，那么调用该函数会非常不方便；因此，你需要重载这个构造函数，新建几个只有较少参数的简化版。 但这些构造函数仍需调用主构造函数，传递一些默认数值来替代省略掉的参数。
    //生成器模式让你可以分步骤生成对象，而且允许你仅使用必须的步骤。应用该模式后，你再也不需要将几十个参数塞进构造函数里了。
    //如果你需要创建的各种形式的产品，它们的制造过程相似且仅有细节上的差异，此时可使用生成器模式。
    //基本生成器接口中定义了所有可能的制造步骤，具体生成器将实现这些步骤来制造特定形式的产品。同时，主管类将负责管理制造步骤的顺序。
    //生成器在执行制造步骤时，不能对外发布未完成的产品。这可以避免客户端代码获取到不完整结果对象的情况。

    //实现方法
    //1.清晰地定义通用步骤， 确保它们可以制造所有形式的产品。否则你将无法进一步实施该模式。
    //2.在基本生成器接口中声明这些步骤。
    //3.为每个形式的产品创建具体生成器类，并实现其构造步骤。
    //不要忘记实现获取构造结果对象的方法。你不能在生成器接口中声明该方法，因为不同生成器构造的产品可能没有公共接口，因此你就不知道该方法返回的对象类型。但是，如果所有产品都位于单一类层次中，你就可以安全地在基本接口中添加获取生成对象的方法。
    //4.考虑创建主管类。它可以使用同一生成器对象来封装多种构造产品的方式。
    //5.客户端代码会同时创建生成器和主管对象。构造开始前，客户端必须将生成器对象传递给主管对象。通常情况下，客户端只需调用主管类构造函数一次即可。主管类使用生成器对象完成后续所有制造任务。还有另一种方式，那就是客户端可以将生成器对象直接传递给主管类的制造方法。
    //6.只有在所有产品都遵循相同接口的情况下，构造结果可以直接通过主管类获取。否则，客户端应当通过生成器获取构造结果。

    #region 相同产品的生成构造

    //具有相同公共产品的接口 的 生成器
    public interface IBuilder
    {
        void SetId();
        void SetName();
        //如果有通用的公共产品接口，则可以直接在抽象生成器接口中定义返回对象类型，否则，需要在具体生成器中定义返回对象的方法
        Computer GetComputer();
    }

    public class Computer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    //主管类
    public class Director
    {
        //指挥生成器 按照顺序 构造 产品
        public void Construct(IBuilder builder)
        {
            //构造Id模块
            builder.SetId();
            //构造Name模块
            builder.SetName();
        }
    }

    public class DellBuilder : IBuilder
    {
        private Computer computer = null;
        public DellBuilder()
        {
            computer = new Computer();
        }
       
        public Computer GetComputer()
        {
            return computer;
        }

        public void SetId()
        {
            computer.Id = "1";
        }

        public void SetName()
        {
            computer.Name = "Dell";
        }
    }

    public class LenoveBuilder : IBuilder
    {
        private Computer computer = null;
        public LenoveBuilder()
        {
            computer = new Computer();
        }

        public Computer GetComputer()
        {
            return computer;
        }

        public void SetId()
        {
            computer.Id = "2";
        }

        public void SetName()
        {
            computer.Name = "Lenove";
        }
    }

    #endregion


    #region 不同产品的生成构造

    //汽车
    public class BMCar
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    //汽车使用手册
    public class BMCarManual
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public int TotalPage { get; set; }
    }

    //抽象生成器
    public interface IBMBuilder
    {
        void SetName();
        void SetVersion();
    }

    //具体生成器
    //由于生成的产品种类不同，因此需要将返回产品对象的方法放到具体生成器中
    public class BMCarBuilder:IBMBuilder
    {
        private BMCar _car;

        public BMCarBuilder()
        {
            _car=new BMCar();
        }
        public void SetName()
        {
            _car.Name = nameof(BMCar);
        }

        public void SetVersion()
        {
            _car.Version = "1.0.1";
        }

        //由于生成的产品种类不同，因此需要将返回产品对象的方法放到具体生成器中
        public BMCar GetProduct() => _car;
    }

    public class BMCarManualBuilder:IBMBuilder
    {
        private BMCarManual _bmCarManual;

        public BMCarManualBuilder()
        {
            _bmCarManual=new BMCarManual();
        }

        public void SetName()
        {
            _bmCarManual.Name = nameof(BMCarManual);
            SetTotalPage();
        }

        public void SetVersion()
        {
            _bmCarManual.Version = "1.0.1";
        }

        public void SetTotalPage()
        {
            _bmCarManual.TotalPage = 100;
        }

        //由于生成的产品种类不同，因此需要将返回产品对象的方法放到具体生成器中
        public BMCarManual GetProduct() => _bmCarManual;
    }

    //主管类
    public class BMDirector
    {
        //定义构造产品的步骤
        public void Construct(IBMBuilder builder)
        {
            builder?.SetName();
            builder?.SetVersion();
        }
    }

    #endregion



    //这是对 生成器 的扩展
    //可以将复杂模块对外做扩展开放
    public class Computer2Builder
    {
        protected Computer2 computer = new Computer2 { Option=new Option()};

        //将Id模块对外扩展
        public virtual Computer2Builder Set(Action<Option> action)
        {
            if (action != null)
                action(computer.Option);            
            return this;
        }      
        public virtual Computer2 GetComputer() { return computer; }
    }

    public class Computer2
    {
        public Option Option { get; set; }
    }

    public class Option
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
