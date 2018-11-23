using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._15.命令模式
{
    //命令模式
    //耦合是软件不能低于变化灾难性的根本原因，不仅实体对象与实体对象之间存在耦合关系，且实体对象与行为操作之间也存耦合关系
    //将一个请求或行为封装为一个对象，从而使得可以用不同的请求对客户进行参数化，对请求排队或记录日志，以及支持可撤销的操作。
    //即 可以将一个方法或行为封装为一个类对象


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

    public abstract class Command
    {
        protected MyDocument _document { get; set; }
        public Command(MyDocument document)
        {
            _document = document;
        }

        public abstract void Execute();
    }

    public class DisplayCommand:Command
    {
        public DisplayCommand(MyDocument document) : base(document) { }

        public override void Execute()
        {
            _document.Display();
        }

    }

    public class UndoCommand : Command
    {
        public UndoCommand(MyDocument document) : base(document) { }

        public override void Execute()
        {
            _document.Undo();
        }
    }


    public class RedoCommand : Command
    {
        public RedoCommand(MyDocument document) : base(document) { }
        public override void Execute()
        {
            _document.Redo();
        }
    }

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
