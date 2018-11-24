using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._19.中介者模式
{
    //中介者模式
    //用一个中介对象来封装一系列对象的交互。中介者使各个对象之间不需要互相引用，从而使其耦合松散，而且还可以独立的改变他们之间的交互。
    //中介者模式 解耦 系统内的各个对象之间的交互关系，是双向的

    //角色：
    //1.抽象中介者类Mediator：在里面定义了各个同事之间需要交互的方法，可以是公共的通信方法，也可以是小范围的交互方法
    //2.具体中介者类：需要了解并维护各个同事对象，并负责具体的协调同事对象的交互关系
    //3.抽象同事类Colleague：主要约束同事对象的类型，并实现一些具体同事类之间的公共功能
    //4.具体同事类：实现自己的业务，需要与其他同事通信的时候，就与持有的中介者对象通信，中介者对象会负责与其他的同事类交互

    //中介者模式的优点
    //      （1）、松散耦合
    //               中介者模式通过把多个同事对象之间的交互封装到中介对象里面，从而使得对象之间松散耦合，基本上可以做到互不依赖。这样一来，同时对象就可以独立的变化和复用，不再“牵一发动全身”

    //      （2）、集中控制交互
    //               多个同事对象的交互，被封装在中介者对象里面集中管理，使得这些交互行为发生变化的时候，只需要修改中介者就可以了。

    //      （3）、多对多变为一对多
    //               没有中介者模式的时候，同事对象之间的关系通常是多对多，引入中介者对象后，中介者和同事对象的关系通常变为双向的一对多，这会让对象的关系更容易理解和实现。

    // 中介者模式的缺点
    //      （1）、过多集中化
    //             如果同事对象之间的交互非常多，而且比较复杂，当这些复杂性全都集中到中介者的时候，会导致中介者对象变的十分复杂，而且难于维护和管理。


    //以下就以通信为例
    //抽象中介者
    public abstract class Mediator
    {
        //注册一个抽象同事类
        public abstract Mediator Register(Colleague colleague);
        //同事类之间互相发送消息
        public abstract void Send(string from,string to,string message);
    }

    //抽象同事类
    public abstract class Colleague
    {
        private Mediator _mediator;
        private string _name;

        public Colleague(string name) => _name = name;
        public string Name => _name;
        public Mediator Mediator { get => _mediator; set => _mediator = value; }

        public void Send(string to,string message)
        {
            //_mediator.Send方法里面调用了其他中介者的方法
            if (_mediator != null)
                _mediator.Send(_name, to, message);
        }

        public virtual void Recieve(string  from ,string message)
        {
            Console.WriteLine($"{from} to {_name}:{message}");
        }

    }

    //具体中介者类
    public class ChatroomMediator : Mediator
    {
        private Hashtable table = new Hashtable();
        public override Mediator Register(Colleague colleague)
        {
            if (colleague != null)
            {
                if (table[colleague.Name] == null)
                    table[colleague.Name] = colleague;
                colleague.Mediator = this;
            }
            return this;
        }

        public override void Send(string from, string to, string message)
        {
            //调用了其他中介者的方法
            Colleague obj = table[to] as Colleague;
            if (obj != null)
            {
                obj.Recieve(from, message);
            }
        }
    }

    //具体同事类
    public class Member : Colleague
    {
        public Member(string name) : base(name) { }
        public override void Recieve(string from, string message)
        {
            Console.WriteLine("To a Member");
            base.Recieve(from, message);
        }
    }










}
