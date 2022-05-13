using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._08.桥接模式 {
    //桥接模式
    //连接不同的维度，这些维度又有强烈的变化
    //将抽象与实现分离，更确切的理解，应该是将一个事物中多个维度的变化分离。
    //使得在多个有关系的维度下，每个维度可以有多个不同的变化(也就是说，一个抽象可以有多个子类)
    //且在每个维度变化的同时，它们之间互不影响，也就是说每个维度随意切换子类的同时，每个维度之间互不影响
    //桥接模式 引用各个维度的抽象接口
    //桥接模式通常会于开发前期进行设计，使你能够将程序的各个部分独立开来以便开发。

    //当每个维度可以被抽象化出来时，就可以用桥接模式
    //一个维度就是一个抽象类或接口，多个变化指的就是该抽象类或接口有多个子类(即 使用多态的性质)

    //角色
    //抽象部分（Abstraction）抽象化给出定义，并保存一个对实现部分（Implementor）的引用；
    //精确抽象（Refined Abstraction）提供控制逻辑的变体。与其父类一样，它们通过通用实现接口与不同的实现进行交互；
    //实现部分（Implementor）这个角色给出实现角色的接口，但不给出具体的实现。必须指出的是，这个接口不一定与抽象化角色的接口定义相同。实际上，这两个接口可以非常不一样。实现化角色应当只给出底层操作，而抽象化角色应当只给出基于底层操作的更高一层的操作；
    //抽象部分可以列出和实现部分一样的方法，但是抽象部分通常声明一些复杂行为，这些行为依赖于多种由实现部分声明的原语操作。
    //具体实现（Concrete Implementor）这个角色给出实现角色接口的具体实现。
    //通常情况下，客户端（Client）仅关心如何与抽象部分合作。但是，客户端需要将抽象对象与一个实现对象连接起来。


    //两个类Abstraction和Implementor分别定义了抽象与行为类型的接口，通过调用两接口的子类实现抽象与行为的动态组合。
    //Bridge模式对比于多继承方案是更好的解决方法。

    //应用场景
    //如果你想要拆分或重组一个具有多重功能的庞杂类。
    //类的代码行数越多，弄清其运作方式就越困难，对其进行修改所花费的时间就越长。一个功能上的变化可能需要在整个类范围内进行修改，而且常常会产生错误，甚至还会有一些严重的副作用。
    //桥接模式可以将庞杂类拆分为几个类层次结构。此后，你可以修改任意一个类层次结构而不会影响到其他类层次结构。这种方法可以简化代码的维护工作，并将修改已有代码的风险降到最低。

    //如果你希望在几个独立维度上扩展一个类，可使用该模式。
    //桥接建议将每个维度抽取为独立的类层次。初始类将相关工作委派给属于对应类层次的对象，无需自己完成所有工作。


    //实现方式
    //1.明确类中独立的维度。独立的概念可能是：抽象/平台，域/基础设施，前端/后端或接口/实现。
    //2.了解客户端的业务需求，并在抽象基类中定义它们。
    //3.确定在所有平台上都可执行的业务。并在通用实现接口中声明抽象部分所需的业务。
    //4.为你域内的所有平台创建实现类，但需确保它们遵循实现部分的接口。
    //5.在抽象类中添加指向实现类型的引用成员变量。抽象部分会将大部分工作委派给该成员变量所指向的实现对象。
    //6.如果你的高层逻辑有多个变体，则可通过扩展抽象基类为每个变体创建一个精确抽象。 
    //7.客户端代码必须将实现对象传递给抽象部分的构造函数才能使其能够相互关联。此后，客户端只需与抽象对象进行交互，无需和实现对象打交道。
    


    #region 第一个
    //用毛笔画画
    //共有两个维度，毛笔和颜色
    //毛笔分为大中小号，颜色分为赤橙黄绿青蓝紫等

    public abstract class Color
    {
        public string Name { get; set; }
    }

    public abstract class Brush
    {
        protected Color Color = null;
        public abstract void Paint();
        public virtual void SetColor(Color color)
        {
            this.Color = color;
        }
    }

    public class BigBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"brush:big color:{Color.Name}");
        }
    }

    public class SmallBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"brush:small color:{Color.Name}");
        }
    }

    public class Red : Color
    {
        public Red() { this.Name = "red"; }
    }

    public class Black : Color
    {
        public Black() { this.Name = "black"; }
    }

    public class Green : Color
    {
        public Green() { this.Name = "green"; }
    }

    #endregion

    #region 第二个

    //抽象部分
    public abstract class Abstraction
    {
        protected Implementor _implementor;
        public Implementor Implementor
        {
            get { return _implementor; }
            set { _implementor = value; }
        }

        public virtual void Operation()
        {
            _implementor.ImpOperation();
        }
    }

    //引起抽象部分变化的子类
    public  class ObjectAbstraction : Abstraction
    {
        public override void Operation()
        {
            _implementor.ImpOperation();
        }
    }

    //实现部分(将某些行为或其他等抽象出来)
    public abstract class Implementor
    {
        //将行为抽象出来
        public abstract void ImpOperation();
    }

    //引起实现部分变化的子类A
    public class AImplementor : Implementor
    {
        public override void ImpOperation()
        {
            Console.WriteLine($"AImplementor.ImpOperation");
        }
    }

    //引起实现部分变化的子类B
    public class BImplementor : Implementor
    {
        public override void ImpOperation()
        {
            Console.WriteLine($"BImplementor.ImpOperation");
        }
    }


    #endregion

}
