using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._24.状态模式 {
    //状态模式
    //允许一个对象在其内部状态改变时改变它的行为，从而使对象看起来似乎修改了其行为
    //在软件构建过程中，某些对象的状态如果改变，其行为也会随之发生变化。
    //状态对象可存储对于上下文对象的反向引用。状态可以通过该引用从上下文处获取所需信息，并且能触发状态转移。

    //角色
    //抽象状态：接口会声明特定于状态的方法。这些方法应能被其他所有具体状态所理解，因为你不希望某些状态所拥有的方法永远不会被调用；
    //具体状态：每一个具体状态类都实现了环境（Context）的一个状态所对应的行为；
    //环境上下文类：保存了对于一个具体状态对象的引用，并会将所有与该状态相关的工作委派给它。上下文通过状态接口与状态对象交互，且会提供一个设置器用于传递新的状态对象；

    //应用场景
    //如果对象需要根据自身当前状态进行不同行为，同时状态的数量非常多且与状态相关的代码会频繁变更的话，可使用状态模式。
    //模式建议你将所有特定于状态的代码抽取到一组独立的类中。这样一来，你可以在独立于其他状态的情况下添加新状态或修改已有状态，从而减少维护成本。
    //如果某个类需要根据成员变量的当前值改变自身行为，从而需要使用大量的条件语句时，可使用该模式。
    //状态模式会将这些条件语句的分支抽取到相应状态类的方法中。同时，你还可以清除主要类中与特定状态相关的临时成员变量和帮手方法代码。
    //当相似状态和基于条件的状态机转换中存在许多重复代码时，可使用状态模式。
    //状态模式让你能够生成状态类层次结构，通过将公用代码抽取到抽象基类中来减少重复。

    //实现方式
    //1.确定哪些类是上下文。它可能是包含依赖于状态的代码的已有类；如果特定于状态的代码分散在多个类中，那么它可能是一个新的类。
    //2.声明状态接口。虽然你可能会需要完全复制上下文中声明的所有方法，但最好是仅把关注点放在那些可能包含特定于状态的行为的方法上。
    //3.为每个实际状态创建一个继承于状态接口的类。然后检查上下文中的方法并将与特定状态相关的所有代码抽取到新建的类中。
    //在将代码移动到状态类的过程中，你可能会发现它依赖于上下文中的一些私有成员。你可以采用以下几种变通方式： ◦ 将这些成员变量或方法设为公有。 ◦ 将需要抽取的上下文行为更改为上下文中的公有方法，然后在状态类中调用。这种方式简陋却便捷，你可以稍后再对其进行修补。 ◦ 将状态类嵌套在上下文类中。这种方式需要你所使用的编程语言支持嵌套类。
    //4.在上下文类中添加一个状态接口类型的引用成员变量，以及一个用于修改该成员变量值的公有设置器。
    //5.再次检查上下文中的方法，将空的条件语句替换为相应的状态对象方法。
    //6. 为切换上下文状态，你需要创建某个状态类实例并将其传递给上下文。你可以在上下文、各种状态或客户端中完成这项工作。无论在何处完成这项工作，该类都将依赖于其所实例化的具体类。

    
    //上下文角色
    public class Order
    {
        public Order()
        {
            _state=new WaitingforOrderState();
        }

        private State _state;
        public DateTime CreationTime { get; set; } = DateTime.MinValue;

        //改变状态
        public void ChangeState(State state)
        {
            Console.WriteLine($"当前订单状态：{_state.StateName}");
            _state = state;
            Console.WriteLine($"订单状态变更为：{_state.StateName}");
        }
        //执行状态被改变后的操作
        public void ActionOnState() => _state.Process(this);
    }

    //抽象状态
    public abstract class State
    {
        //当前的状态名称
        public virtual string StateName { get; set; }
        //当前状态的处理逻辑
        public abstract void Process(Order order);
    }

    //具体状态
    //等待下单
    public class WaitingforOrderState : State
    {
        public override string StateName => nameof(WaitingforOrderState);

        public override void Process(Order order)
        {
            Console.WriteLine("正在等待下单...");
        }
    }

    //已下单
    public class OrderedState:State
    {
        public override string StateName => nameof(OrderedState);
        public override void Process(Order order)
        {
            order.CreationTime = DateTime.Now;
            Console.WriteLine("已下单，待发货");
        }
    }

    //发货
    public class DeliverState:State
    {
        public override string StateName => nameof(DeliverState);
        public override void Process(Order order)
        {
            //如果在8小时内不发货，就自动退款
            var hours = (DateTime.Now - order.CreationTime).TotalHours;
            if (hours > 8)
            {
                Console.WriteLine("8小时内未发货，自动退款！");
                order.ChangeState(new RefundState());
                order.ActionOnState();
            }
            else Console.WriteLine("已发货");
        }
    }

    //已收货
    public class ConfirmState:State
    {
        public override string StateName => nameof(ConfirmState);
        public override void Process(Order order)
        {
            Console.WriteLine("已确认收货");
            order.ChangeState(new CompletedState());
            order.ActionOnState();
        }
    }

    //申请退款
    public class RefundState:State
    {
        public override string StateName => nameof(RefundState);
        public override void Process(Order order)
        {
            Console.WriteLine("退款完成");
            order.ChangeState(new CompletedState());
            order.ActionOnState();
        }
    }

    public class CompletedState:State
    {
        public override string StateName => nameof(CompletedState);
        public override void Process(Order order)
        {
            Console.WriteLine("订单已完结");
        }
    }
}
