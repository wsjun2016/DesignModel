using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._07.适配器模式 {
    //适配器模式
    //适配器模式注重转换
    //将已经存在且不适应当前系统的接口或方法 转换为 适应当前系统的接口或方法
    //适配器模式 包含 类适配器模式(继承目标接口 和 源接口) 和 对象适配器模式(继承目标接口，组合源接口)
    //适配器角色即是抽象目标角色的具体实现

    //角色
    //抽象目标角色（Target）：符合Client需要实现逻辑的抽象目标接口，即当前没有但需要实现的对象；
    //客户角色（Client）：与符合Target接口的对象协同；
    //被适配角色（Adaptee)：一个已经存在并已经使用的接口，这个接口需要被适配。即客户端需要实现的逻辑与该接口不兼容，因此无法直接调用其功能；
    //适配器角色（Adapter) ：适配器模式的核心，它将对被适配Adaptee角色已有的接口转换为目标角色Target匹配的接口并进行适配。适配器角色即是抽象目标角色的具体实现；

    //实现要点
    //1）Adapter模式主要应用于“希望复用一些现存的类，但是接口又与复用环境要求不一致的情况”，在遗留代码复用、类库迁移等方面非常有用。
    //2）GoF23定义了两种Adapter模式的实现结构：对象适配器和类适配器。类适配器采用“多继承”的实现方式，在C#语言中，如果被适配角色是类，Target的实现只能是接口，因为C#语言只支持接口的多继承。在C#语言中类适配器也很难支持适配多个对象的情况，同时也会带来了不良的高耦合和违反类的单一职责的原则，所以一般不推荐使用。对象适配器采用“对象组合”的方式，更符合松耦合精神，对适配的对象也没限制，可以一个也可以多个，但是，这也使得重定义Adaptee的行为比较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。Adapter模式可以实现的非常灵活，不必拘泥于GoF23中定义的两种结构。例如，完全可以将Adapter模式中的“现存对象”作为新的接口方法参数，来达到适配的目的。
    //3）Adapter模式本身要求我们尽可能地使用“面向接口的编程”风格，这样才能在后期很方便地适配。

    //下面详细总结下适配器两种形式的优缺点：
    //1、对象适配器模式
    //优点：
    //1）可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”。
    //2）采用 “对象组合”的方式，更符合松耦合。
    //缺点：
    //1）使得重定义Adaptee的行为较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。

    //2、类适配器模式
    //优点：
    //1）可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”。
    //2）可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类。
    //3）仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。
    //缺点：
    //1）用一个具体的Adapter类对Adaptee和Target进行匹配，当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。因为类的适配器模式中没有引入Adaptee的实例，光调用SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。
    //2）采用了 “多继承”的实现方式，带来了不良的高耦合。

    //3、适配器模式的使用场景
    //1）系统需要复用现有类，而该类的接口不符合系统的需求。
    //2）想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。
    //3）对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。

    //代码实现
    //现有两个插孔的插座，但不适应三个插头插入，因此需要适配出三个插孔的插座

    //已经存在的 需要被适配的接口
    //源抽象接口 两插孔的插头
    public abstract class TwoHole
    {
        public abstract void TwoHoleRequest();
    }

    //已经存在的 需要被适配的接口
    //A品牌的 源接口
    public class ATwoHole : TwoHole
    {
        public override void TwoHoleRequest()
        {
            Console.WriteLine("A品牌的两个插孔的插头！");
        }
    }

    //已经存在的 需要被适配的接口
    //B品牌的 源接口
    public class BTwoHole : TwoHole
    {
        public override void TwoHoleRequest()
        {
            Console.WriteLine("B品牌的两个插孔的插头！");
        }
    }

    //目标接口
    //一般将目标接口 定义为 interface形式
    //三个插孔的插头
    public interface IThreeHole
    {
        void ThreeHoleRequest();
    }

    //类适配器模式
    //适配器继承 源接口 和 目标接口
    //因为是单继承，类适配器模式 只能实现 一种 源接口
    //实现A品牌的三个插孔的插头
    public class AClassAdapter : ATwoHole, IThreeHole
    {
        public void ThreeHoleRequest()
        {
            TwoHoleRequest();
        }     
    }

    //类适配器模式
    //适配器继承 源接口 和 目标接口
    //因为是单继承，类适配器模式 只能实现 一种 源接口
    //实现B品牌的三个插孔的插头
    public class BClassAdapter : BTwoHole, IThreeHole
    {
        public void ThreeHoleRequest()
        {
            TwoHoleRequest();
        }
    }

    //对象适配器模式
    //适配器 继承 目标接口，引用 源接口
    //一般在用适配器模式的时候，对象适配器模式 用的次数 更多，因为对象适配器模式可以组合N个源接口
    //而 类适配器模式只能继承一个源接口
    public class ObjectAdapter : IThreeHole
    {
        //适配多个品牌的源接口，也可以适配一个品牌的源接口
        protected TwoHole ATwoHole;
        protected TwoHole BTwoHole;
        public ObjectAdapter(TwoHole aTwoHole,TwoHole bTwoHole)
        {
            ATwoHole = aTwoHole;
            BTwoHole = bTwoHole;
        }
        public void ThreeHoleRequest()
        {
            ATwoHole.TwoHoleRequest();
            BTwoHole.TwoHoleRequest();
        }
    }


}
