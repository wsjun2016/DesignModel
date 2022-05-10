using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._23.访问者模式 {
    //访问者模式
    //可以在不改变类的前提下，动态的为类添加新的行为操作
    //访问者模式建议将新行为放入一个名为访问者的独立类中，而不是试图将其整合到已有类中。现在，需要执行操作的原始对象将作为参数被传递给访问者中的方法，让方法能访问对象所包含的一切必要数据。
    //它能将算法与其作用的对象隔离开来
    //类似于 扩展方法
    //如果需要新增或扩展与类相关的某个行为，只需要实现一个新的访问者类即可
    //在此模式中，最终还是需要修改节点类，但毕竟改动很小，且使得我们能够在后续进一步添加行为时无需再次修改代码

    //角色：
    //抽象访问者(Visitor)：接口声明了一系列以对象结构的具体元素为参数的访问者方法。如果编程语言支持重载，这些方法的名称可以是相同的，但是其参数一定是不同的；
    //具体访问者(ConcreteVisitor)：会为不同的具体元素类实现相同行为的几个不同版本；
    //抽象元素类(Element)：接口声明了一个方法来“接收” 访问者。该方法必须有一个参数被声明为抽象访问者类型；
    //具体元素类(ConcreteElement)：必须实现接收方法。 该方法的目的是根据当前元素类将其调用重定向到相应访问者的方法。请注意，即使元素基类实现了该方法，所有子类都必须对其进行重写并调用访问者对象中的合适方法；
    //客户端(Client)：通常会作为集合或其他复杂对象（例如一个组合树）的代表。 客户端通常不知晓所有的具体元素类，因为它们会通过抽象接口与集合中的对象进行交互；


    //抽象访问者
    //需要知道具体的元素类型
    public interface IVisitor
    {
        void Visit(ElementA elementA);
        void Visit(ElementB elementB);

        //也可以不用知晓具体元素类的类型，但是需要在实现该Visit方法的时候，对具体的元素类型进行判断(可以搭配使用 状态模式)
        //void Visit(Element element);
    }

    //具体访问者
    //实现对各个具体元素类型的行为扩展
    public class VisitorA : IVisitor
    {
        //在具体访问者中对ElementA类扩展一个方法
        public void Visit(ElementA elementA)
        {
            Console.WriteLine($"{nameof(ElementA)} 在 VisitorA 中扩展的方法");
        }

        //在具体访问者中对ElementA类扩展一个方法
        public void Visit(ElementB elementB)
        {
            Console.WriteLine($"{nameof(ElementB)} 在 VisitorA 中扩展的方法");
        }
    }

    public class VisitorB:IVisitor
    {
        public void Visit(ElementA elementA)
        {
            Console.WriteLine($"{nameof(ElementA)} 在 VisitorB 中扩展的方法");
        }

        public void Visit(ElementB elementB)
        {
            Console.WriteLine($"{nameof(ElementB)} 在 VisitorB 中扩展的方法");
        }
    }

    //抽象元素类
    //需要声明一个"接收"方法来接收一个抽象访问者参数
    public abstract class Element
    {
        public abstract void SelfMethod();

        //需要延迟到具体元素类中去实现
        public abstract void Accept(IVisitor visitor);
    }

    //具体元素类
    //实现"接收"方法，即重定向到相应的访问者的方法
    public class ElementA : Element
    {
        public override void SelfMethod()
        {
            Console.WriteLine("ElementA SelfMethod");
        }

        public override void Accept(IVisitor visitor)
        {
            //重定向到相应的访问者的方法
            visitor.Visit(this);
        }
    }

    public class ElementB:Element
    {
        public override void SelfMethod()
        {
            Console.WriteLine("ElementB SelfMethod");

        }

        public override void Accept(IVisitor visitor)
        {
            //重定向到相应的访问者的方法
            visitor.Visit(this);
        }
    }
}
