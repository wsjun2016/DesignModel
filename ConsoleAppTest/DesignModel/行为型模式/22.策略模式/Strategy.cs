using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._22.策略模式 {
    //策略模式
    //定义一组算法，将每个算法都封装起来，并且是它们之间可以互换。该模式使得算法可独立于使用它的客户而变化
    //策略模式 是为达到某一目的而采取的手段和方法，它的本质是使目标与手段相分离，将算法与对象本身解耦
    //将算法从目标内提出到目标外，并封装成算法类
    //策略模式使用的就是面向对象的继承和多态机制

    //角色
    //1.抽象策略(Strategy)：定义了一个公共接口，各种不同的算法以不同的方式实现这个接口，Context使用这个接口调用不同的算法，一般使用接口或抽象类实现；
    //2.具体策略(ConcreteStrategy)：实现了Strategy定义的接口，提供具体的算法实现
    //3.可以配置策略的上下文(Context)：
    //3.1 持有一个Strategy类的引用。
    //3.2 需要使用ConcreteStrategy提供的算法。
    //3.3 内部维护一个Strategy的实例。
    //3.4 负责动态设置运行时Strategy具体的实现算法。
    //3.5 负责跟Strategy之间的交互和数据传递。

    //策略模式适用情形：
    //1. 如果在一个系统里面有许多类，它们之间的区别仅在于它们的行为，那么使用策略模式可以动态地让一个对象在许多行为中选择一种行为。
    //2. 一个系统需要动态地在几种算法中选择一种。这些具体算法类均有统一的接口，由于多态性原则，客户端可以选择使用任何一个具体算法类，并只持有一个数据类型是抽象算法类的对象。
    //3. 一个系统的算法使用的数据不可以让客户端知道。策略模式可以避免让客户端涉及到不必要接触到的复杂的和只与算法有关的数据。
    //4. 如果一个对象有很多的行为，如果不用恰当的模式，这些行为就只好使用多重的条件选择语句来实现。此时，使用策略模式，把这些行为转移到相应的具体策略类里面，可以避免使用难以维护的多重条件选择语句。

    //策略模式优点：
    //1. 策略模式恰当使用继承可以把公共的代码移到父类里面，从而避免重复的代码。
    //2. 策略模式提供了可以替换继承关系的办法。继承可以处理多种算法或行为。如果不是用策略模式，那么使用算法或行为的环境类就可能会有一些子类，每一个子类提供一个不同的算法或行为。但是，这样一来算法或行为的使用者就和算法或行为本身混在一起。决定使用哪一种算法或采取哪一种行为的逻辑就和算法或行为的逻辑混合在一起，从而不可能再独立演化。继承使得动态改变算法或行为变得不可能。
    //3. 使用策略模式可以避免使用多重条件判断语句。

    //策略模式缺点：
    //1. 客户端必须知道所有的策略类，并自行决定使用哪一个策略类。策略模式只适用于客户端知道所有的算法或行为的情况。
    //2. 策略模式造成很多的策略类。


    //代码实现
    //某软件公司为某电影院开发了一套影院售票系统，在该系统中需要为不同类型的用户提供不同的电影票打折方式，具体打折方案如下：
    //1.学生凭学生证可以享受电影票8折优惠。
    //2.年龄在10周岁及以下的儿童可享受每张票减10元的优惠。
    //3.影院VIP享受半折优惠。


    //Strategy抽象策略算法类
    public abstract class Discout
    {
        public const string DiscountName = "";
        public abstract float Calculate(int money);
    }

    //具体策略类 学生折扣算法
    public class StudentDiscount : Discout
    {
        public new const string DiscountName = nameof(StudentDiscount);

        public override float Calculate(int money)
        {
            return money * 0.8f;
        }
    }

    //具体策略类 儿童折扣算法
    public class ChildDiscount : Discout
    {
        public new const string DiscountName = nameof(ChildDiscount);
        public override float Calculate(int money)
        {
            return money>20?(money-10):money;
        }
    }

    //具体策略类 VIP折扣算法
    public class VIPDiscount:Discout
    {
        public new const string DiscountName = nameof(VIPDiscount);
        public override float Calculate(int money)
        {
            return money * 0.5f;
        }
    }

    //策略的上下文类 电影票类
    public class MovieTicket
    {
        //引用一个策略算法
        private Discout _discout;
        private int _ticketMoney;
        public MovieTicket(int money)
        {
            _ticketMoney = money;
        }

        public void SetDiscount(string discountName)
        {
            _discout = MovieTicketDiscountFactory.Create(discountName);
        }

        //调用 策略算法
        public float Calculate()
        {
            return _discout?.Calculate(_ticketMoney) ?? _ticketMoney;
        }
    }

    //折扣算法类的简单工厂
    public class MovieTicketDiscountFactory
    {
        public static Discout Create(string discountName)
        {
            Type type = Type.GetType($"{typeof(MovieTicketDiscountFactory).Namespace}.{discountName}");
            if (type == null) return null;
            return Activator.CreateInstance(type) as Discout;
        }
    }



    //策略模式的初级定义代码实现

    //抽象策略接口
    public interface IStrategy
    {
        void AlgorithmInterface();
    }

    //具体策略算法A
    public class StrategyA:IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("StrategyA Algorithm");
        }
    }

    //具体策略算法B
    public class StrategyB:IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("StrategyB Algorithm");
        }
    }

    //具体策略算法C
    public class StrategyC : IStrategy {
        public void AlgorithmInterface() {
            Console.WriteLine("StrategyC Algorithm");
        }
    }

    //上下文类
    public class StrategyContext
    {
        //引用一个策略
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy) => _strategy = strategy;

        public void AlgorithmInterface()
        {
            _strategy.AlgorithmInterface();
        }

    }



}
