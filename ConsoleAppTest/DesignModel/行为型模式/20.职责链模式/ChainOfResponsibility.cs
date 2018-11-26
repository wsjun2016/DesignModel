using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._20.职责链模式
{
    //职责链模式
    //一个请求可能被多个对象处理，但每个请求在运行时只能有一个接受者，如果显示指定，则会带来发送者与接受者之间的耦合。
    //可以使请求的发送者不需要指定具体的接受者，让请求的接受者自己在运行时决定是否来处理当前请求，从而使两者解耦。

    //避免请求发送者与接受者耦合在一起，让多个对象都有可能接受请求，此时可以将这些处理器对象连接成一条链，并沿着这条链传递请求，直到有对象处理该请求为止。

    //角色：
    //1.请求类：包含请求的相关信息
    //2.抽象处理器类：定义了一个处理请求的接口或抽象类。由于不同的具体处理者处理请求的方式不同，因此需要定义一个抽象处理请求的方法。
    //  每一个处理者的下家还是一个处理者，因此，需要在当前处理者内部引用一个自类型的对象，作为其下家的引用，此时处理者可以连成一条链。
    //3.具体处理器类：派生自抽象处理类型或接口。它可以处理用户的请求，但在处理之前，需要判断当前处理者是否有相应的权限，
    //  如果有权限，则处理它，否则将请求转给下家处理者，以完成请求的转发。

    //   职责链模式的实现要点：
    //       Chain of Responsibility模式的应用场合在于“一个请求可能有多个接受者，但是最后真正的接受者只有一个”，只有这时候请求发送者与接受者的耦合才有可能出现“变化脆弱”的症状，职责链的目的就是将二者解耦，从而更好地应对变化。
    //　应用了Chain of Responsibility模式后，对象的职责分派将更具灵活性。我们可以在运行时动态添加/修改请求的处理职责。
    //　当我们要新增一个DHandler处理请求，就不需再改原来的代码了，遵从了开放封闭原则。这样我们的程序就更赋予变化，更有变化的抵抗力。Handler类本身继承自BaseHandler类型，又包含了一个BaseHandler类型的对象，这点类似Decorator模式。
    //　如果请求传递到职责链的末尾仍得不到处理，应该有一个合理的缺省机制。这也是每一个接受对象的责任，而不是发出请求的对象的责任。
    // （1）、职责链模式的主要优点有：
    //       1】、降低耦合度：职责链模式使得一个对象无需知道是其他哪一个对象处理其请求。对象仅需知道该请求会被处理即可，接受者和发送者都没有对方的明确信息，且链中的对象不需要知道链的结构，有客户端负责链的创建。
    //       2】、可简化对象的相互连接：接受者对象仅需维持一个指向其后继者的引用，而不需维持它对所有的候选处理者的引用。
    //       3】、增强给对象指派职责的灵活性：在给对象分派职责时，职责链可以给我们带来更多的灵活性。可以通过在运行时对该连进行动态的增加或修改处理一个请求的职责。
    //       4】、增加新的请求处理类很方便：在系统中增加一个新的请求处理者无需修改原有系统的代码，只需要在客户端重新建链即可，从这一点看来是符合“开闭原则”的。
    //（2）、职责链模式的主要缺点有：
    //       1】、在找到正确的处理对象之前，所有的条件判定都要执行一遍，当责任链过长时，可能会引起性能的问题。
    //       2】、可能导致某个请求不被处理。
    //       3】、客户端需要组装这个链条，耦合了客户端和链条的组成结构，可以把这个在客户端的组合动作提到外面，通过配置来做，会更好点。
    // （3）、在下面的情况下可以考虑使用职责链模式：
    //       1】、一个系统的审批需要多个对象才能完成处理的情况下，例如请假系统等。
    //       2】、代码中存在多个if-else语句的情况下，此时可以考虑使用责任链模式来对代码进行重构
    //       3】、有多个对象可以处理同一个请求，具体哪个对象处理该请求有运行时刻自动确定。客户端只需将请求提交到链上，无须关心请求的处理对象是谁以及它是如何处理的。
    //       4】、不明确指定接受者的情况下，向多个对象中的一个提交一个请求。请求的发送者与请求者解耦，请求将沿着链进行传递，寻求响应的处理者。
    //       5】、可动态指定一组对象处理请求。客户端可以动态创建职责链来处理请求，还可以动态改变链中处理者之间的先后次序


    //设计一个订单采购的多级审批

    //订单请求类，包含了请求的信息载体
    public class MyOrderRequest
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public MyOrderRequest(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }

    //抽象处理者
    public abstract class MyHandler
    {
        //下一个处理器
        public MyHandler NextHandler;
        public string Name { get; set; }
        public MyHandler(string name) => Name = name;

        //一个抽象的处理请求
        public abstract void RequestProcess(MyOrderRequest request);       
    }

    //部门经理，派生自抽象处理者
    public class Manager : MyHandler
    {
        public Manager(string name) : base(name) { }
        public override void RequestProcess(MyOrderRequest request)
        {
            //判断是否有权限
            if ((request?.Amount ?? 0) < 10000)
                Console.WriteLine($"{Name} 部门经理批准了采购{request?.Name}的计划！");
            else if (NextHandler != null)
                NextHandler.RequestProcess(request);
        }
    }

    //财务经理，派生自抽象处理者
    public class FinancialManager : MyHandler
    {
        public FinancialManager(string name) : base(name) { }
        public override void RequestProcess(MyOrderRequest request)
        {
            decimal amount = request?.Amount ?? 0;
            if (amount > 10000 && amount <= 50000)
                Console.WriteLine($"{Name} 财务经理批准了{request?.Name}的计划！");
            else if (NextHandler != null)
                NextHandler.RequestProcess(request);
        }
    }

    //CEO，派生自抽象处理者
    public class CEO : MyHandler
    {
        public CEO(string name) : base(name) { }
        public override void RequestProcess(MyOrderRequest request)
        {
            decimal amount = request?.Amount ?? 0;
            if (amount > 50000 && amount <= 100000)
                Console.WriteLine($"{Name} CEO批准了{request?.Name}的计划！");
            else Console.WriteLine($"计划的金额太大，需要董事会会议讨论才能决定！");
        }
    }











}
