using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._17.观察者模式
{
    //观察者模式
    //定义对象间一对多的关系，当被观察的那个对象的状态发生改变时，所有依赖于它的对象都得到通知并被自动更新
    //被观察者对象是一，观察者是多
    //被观察者对象需要维护一个观察者对象列表

    #region 抽象一个观察者接口和一个目标基类 来 实现 观察者模式

    //一个观察者接口
    public interface IObserver
    {
        void Update(Subject subject);
    }
    
    //一个被观察者基类
    public abstract class Subject
    {
        private List<IObserver> _observerList=new List<IObserver>();     

        public int Status { get; set; }

        public void Work()
        {
            foreach(var item in _observerList)
            {
                if (item != null)
                    item.Update(this);
            }
        }

        public void AddObserver(IObserver observer) => _observerList.Add(observer);
        public void RemoveObserver(IObserver observer) => _observerList.Remove(observer);
    }


    public class BankAccount : Subject
    {

    }

    public class Emailer : IObserver
    {
        private string _emailer;
        public Emailer(string emailer) => _emailer = emailer;
        public void Update(Subject subject)
        {
            //如果被观察者的状态是100，则发送email
            if (subject.Status == 100)
                Console.WriteLine($"send email to {_emailer}");
        }
    }

    public class Mobile : IObserver
    {
        private string _phone;
        public Mobile(string phone) => _phone = phone;
        public void Update(Subject subject)
        {
            if (subject.Status == 1 || subject.Status == 100)
                Console.WriteLine($"send sms to {_phone}");
        }
    }

    #endregion


    #region 使用 Event事件 来 实现 观察者模式

    //将事件当做观察者接口，可以多次接入观察者对象

    //定义一个观察者Update方法的委托
    public delegate void NotifyEventHandler(object sender);

    public abstract class SubjectA
    {
        //将事件当做观察者接口，可以多次接入观察者对象
        public event NotifyEventHandler NotifyEvent;
        public int Status { get; set; }
        public void Work()
        {
            //do something
            //......
            OnNotifyEvent();
        }
        protected void OnNotifyEvent()
        {
            if (NotifyEvent != null)
                NotifyEvent(this);
        }
    }

    public class BankAccountA : SubjectA
    {

    }

    //具体的观察者
    public class EmailerA
    {
        private string _email;
        public EmailerA(string email) => _email = email;
        public void Update(object item)
        {
            if(item!=null && item is SubjectA)
            {
                SubjectA obj = item as SubjectA;
                Console.WriteLine($"SubjectA.Status={obj.Status},then send to EmailA {_email}");
            }
        }
    }

    //具体的观察者
    public class MobileA
    {
        private string _phone;
        public MobileA(string phone) => _phone = phone;
        public void Update(object item)
        {
            if(item !=null && item is SubjectA)
            {
                SubjectA obj = item as SubjectA;
                Console.WriteLine($"SubjectA.Status={obj.Status},then send to MobileA {_phone}");
            }
        }
    }




    #endregion

}
