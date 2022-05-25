using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._15.命令模式 {
    //命令模式
    //耦合是软件不能抵御变化灾难性的根本原因，不仅实体对象与实体对象之间存在耦合关系，且实体对象与行为操作之间也存耦合关系
    //将一个请求或行为封装为一个对象，从而使得可以用不同的请求对客户进行参数化，对请求排队或记录日志，以及支持可撤销的操作。
    //即 可以将一个方法或行为封装为一个类对象
    //即 命令触发者引用命令，命令引用请求者，将 命令触发者 和 命令的请求者 通过 命令 来解耦

    //角色
    //发送者（Sender）——亦称“触发者（Invoker）”——类负责对请求进行初始化，其中必须包含一个成员变量来存储对于命令对象的引用。发送者触发命令，而不向接收者直接发送请求。注意，发送者并不负责创建命令对象：它通常会通过构造函数从客户端处获得预先生成的命令。
    //命令（Command）接口通常仅声明一个执行命令的方法。
    //具体命令（Concrete Commands） 会实现各种类型的请求。具体命令自身并不完成工作，而是会将调用委派给一个业务逻辑对象。但为了简化代码，这些类可以进行合并。
    //      接收对象执行方法所需的参数可以声明为具体命令的成员变量。你可以将命令对象设为不可变，仅允许通过构造函数对这些成员变量进行初始化。
    //接收者（Receiver）类包含部分业务逻辑。几乎任何对象都可以作为接收者。绝大部分命令只处理如何将请求传递到接收者的细节，接收者自己会完成实际的工作。
    //客户端（Client）会创建并配置具体命令对象。客户端必须将包括接收者实体在内的所有请求参数传递给命令的构造函数。此后，生成的命令就可以与一个或多个发送者相关联了。

    //应用场景
    //如果你需要通过操作来参数化对象，可使用命令模式。
    //  命令模式可将特定的方法调用转化为独立对象。这一改变也带来了许多有趣的应用：你可以将命令作为方法的参数进行传递、将命令保存在其他对象中，或者在运行时切换已连接的命令等。
    //如果你想要将操作放入队列中、操作的执行或者远程执行操作，可使用命令模式。
    //  同其他对象一样，命令也可以实现序列化（序列化的意思是转化为字符串），从而能方便地写入文件或数据库中。一段时间后，该字符串可被恢复成为最初的命令对象。因此，你可以延迟或计划命令的执行。但其功能远不止如此！使用同样的方式，你还可以将命令放入队列、记录命令或者通过网络发送命令。
    //如果你想要实现操作回滚功能，可使用命令模式。
    //  尽管有很多方法可以实现撤销和恢复功能，但命令模式可能是其中最常用的一种。
    //  为了能够回滚操作，你需要实现已执行操作的历史记录功能。命令历史记录是一种包含所有已执行命令对象及其相关程序状态备份的栈结构。
    //  这种方法有两个缺点。首先，程序状态的保存功能并不容易实现，因为部分状态可能是私有的。你可以使用备忘录模式来在一定程度上解决这个问题。
    //  其次，备份状态可能会占用大量内存。因此，有时你需要借助另一种实现方式：命令无需恢复原始状态，而是执行反向操作。反向操作也有代价：它可能会很难甚至是无法实现。

    //实现方式
    //1.声明仅有一个执行方法的命令接口。
    //2.抽取请求并使之成为实现命令接口的具体命令类。每个类都必须有一组成员变量来保存请求参数和对于实际接收者对象的引用。所有这些变量的数值都必须通过命令构造函数进行初始化。
    //3.找到担任发送者职责的类。在这些类中添加保存命令的成员变量。发送者只能通过命令接口与其命令进行交互。发送者自身通常并不创建命令对象，而是通过客户端代码获取。
    //4.修改发送者使其执行命令，而非直接将请求发送给接收者。
    //5.客户端必须按照以下顺序来初始化对象： 
    //  1).创建接收者；
    //  2).创建命令，如有需要可将其关联至接收者；
    //  3).创建发送者并将其与特定命令关联。


    //接收者
    public class MyDocument {
        public void Display()
        {
            Console.WriteLine("display method！");
        }

        public void Undo()
        {
            Console.WriteLine("Undo method!");
        }

        public void Redo()
        {
            Console.WriteLine("Redo method!");
        }
    }

    //命令
    public abstract class Command
    {
        protected MyDocument _document { get; set; }
        public Command(MyDocument document)
        {
            _document = document;
        }

        public abstract void Execute();
    }

    //具体命令
    public class DisplayCommand:Command
    {
        public DisplayCommand(MyDocument document) : base(document) { }

        public override void Execute()
        {
            _document.Display();
        }

    }

    //具体命令
    public class UndoCommand : Command
    {
        public UndoCommand(MyDocument document) : base(document) { }

        public override void Execute()
        {
            _document.Undo();
        }
    }

    //具体命令
    public class RedoCommand : Command
    {
        public RedoCommand(MyDocument document) : base(document) { }
        public override void Execute()
        {
            _document.Redo();
        }
    }

    //命令发送者，或称为 命令触发者
    public class CommandInvoker
    {
        protected Command _command;
        public CommandInvoker SetCommand(Command command)
        {
            _command = command;
            return this;
        }
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }



}
