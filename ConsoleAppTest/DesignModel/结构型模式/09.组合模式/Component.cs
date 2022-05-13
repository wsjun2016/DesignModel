using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._09.组合模式 {
    //组合模式
    //将对象组合成树形结构以表示“部分-整体”的层次结构。Composite使得用户对单个对象和组合对象的使用具有一致性。
    //针对某一个类型的处理，可以将 一对多 的关系 转化为 一对一 的关系
    //如何将 多 转换为 一，用集合
    //单个对象和多个对象的处理方式一样，那么就证明 多个对象所属的集合中的类型和单个对象的类型一致
    //即单个对象是Component，那么这个对象中的集合就是IList<Component>，这样才能一致性处理

    //角色
    //抽象构件角色（Component）：这是一个抽象角色，它给参加组合的对象定义出了公共的接口及默认行为，可以用来管理所有的子对象（在透明式的组合模式是这样的）。在安全式的组合模式里，构件角色并不定义出管理子对象的方法，这一定义由树枝结构对象给出。
    //树叶构件角色（Leaf）：树叶对象是没有下级子对象的对象，定义出参加组合的原始对象的行为。（原始对象的行为可以理解为没有容器对象管理子对象的方法，或者原始对象行为+管理子对象的行为（Add，Remove等）=面对客户代码的接口行为集合）
    //树枝构件角色（Composite）：代表参加组合的有下级子对象的对象，树枝对象给出所有管理子对象的方法实现，如Add、Remove等。组合模式实现的最关键的地方是--简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。

    //组合模式有两种实现方式：
    //一种是透明式的组合模式，另外一种是安全式的组合模式。
    //在这里我就详细说一下何为“透明式”？何为“安全式”？
    //所谓透明式是指“抽象构件角色”定义的接口行为集合包含两个部分：一部分是叶子对象本身所包含的行为（比如Operation），另外一部分是容器对象本身所包含的管理子对象的行为(Add,Remove)。
    //              这个抽象构件必须同时包含这两类对象所有的行为，客户端代码才会透明的使用，无论调用容器对象还是叶子对象，接口方法都是一样的，这就是透明--针对客户端代码的透明，但是也有它自己的问题。
    //              叶子对象不会包含自己的子对象，为什么要有Add,Remove等类似方法呢？调用叶子对象这样的方法可能（注意：我这里说的是可能，因为有些人会把这些方法实现为空，不做任何动作，当然也不会有异常抛出了，不要抬杠）会抛出异常，这样就不安全了，然后人们就提出了“安全式的组合模式”。
    //所谓安全式是指“抽象构件角色”只定义叶子对象的方法，确切的说这个抽象构件只定义两类对象共有的行为，然后容器对象的方法定义在“树枝构件角色”上，这样叶子对象有叶子对象的方法，容器对象有容器对象的方法，这样责任很明确，当然调用肯定不会抛出异常了。
    //大家可以根据自己的情况自行选择是实现为“透视式”还是“安全式”，以下我们会针对这两种情况都进行实现。

    //应用场景
    //如果需要实现树状对象结构，可以使用组合模式
    //组合模式为你提供了两种共享公共接口的基本元素类型：简单叶节点和复杂容器。 容器中可以包含叶节点和其他容器。这使得你可以构建树状嵌套递归对象结构。
    //如果你希望客户端代码以相同方式处理简单和复杂元素，可以使用该模式。
    //组合模式中定义的所有元素共用同一个接口。在这一接口的帮助下，客户端不必在意其所使用的对象的具体类。

    //实现方式
    //1.确保应用的核心模型能够以树状结构表示。尝试将其分解为简单元素和容器。记住，容器必须能够同时包含简单元素和其他容器。
    //2.声明组件接口及其一系列方法，这些方法对简单和复杂元素都有意义。
    //3.创建一个叶节点类表示简单元素。程序中可以有多个不同的叶节点类。
    //4.创建一个容器类表示复杂元素。在该类中，创建一个数组成员变量来存储对于其子元素的引用。该数组必须能够同时保存叶节点和容器，因此请确保将其声明为组合接口类型。实现组件接口方法时，记住容器应该将大部分工作交给其子元素来完成。
    //5.最后，在容器中定义添加和删除子元素的方法。
    //记住，这些操作可在组件接口中声明。这将会违反_接口隔离原则_，因为叶节点类中的这些方法为空。但是，这可以让客户端无差别地访问所有元素，即使是组成树状结构的元素。

    public abstract class Component
    {
        protected string _name;

        public Component(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);
        public abstract int Add(Component obj);
        public abstract int Remove(Component obj);
        public abstract Component GetChild(int index);
    }

    //叶子节点
    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String( ' ',depth)+_name);
        }

        public override int Add(Component obj)
        {
            throw new NotImplementedException();
        }

        public override int Remove(Component obj)
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }

    //复合类型
    public class ComplexComponent : Component
    {
        protected IList<Component> _items;
        public ComplexComponent(string name) : base(name)
        {
            _items=new List<Component>();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + _name);
            foreach (var item in _items)
            {
               item.Display(depth+2);
            }
        }

        public override int Add(Component obj)
        {
            if(obj!=null)
                _items.Add(obj);
            return _items.Count;
        }

        public override int Remove(Component obj)
        {
            if (obj != null)
                _items.Remove(obj);
            return _items.Count;
        }

        public override Component GetChild(int index)
        {
            if (index > -1 && index < _items.Count)
                return _items[index];
            else throw new IndexOutOfRangeException("index is out of range!");
        }
    }

}
