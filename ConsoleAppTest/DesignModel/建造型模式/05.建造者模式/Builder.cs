using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._05.建造者模式
{
    //建造者模式
    //包含 指挥者、建造者和产品
    //只抽象出建造者，因为建造者模式 是 使相同的构造过程 创建 不同的对象
    //将 构造 与 对象的表示 隔离

   public interface IBuilder
    {
        void SetId();
        void SetName();
        Computer GetComputer();
    }

    public class Computer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    //指挥者
    public class Director
    {
        //指挥建造者 构造 产品
        public void Construct(IBuilder builder)
        {
            //构造Id模块
            builder.SetId();
            //构造Name模块
            builder.SetName();
        }
    }

    public class DellBuilder : IBuilder
    {
        private Computer computer = null;
        public DellBuilder()
        {
            computer = new Computer();
        }
       
        public Computer GetComputer()
        {
            return computer;
        }

        public void SetId()
        {
            computer.Id = "1";
        }

        public void SetName()
        {
            computer.Name = "Dell";
        }
    }

    public class LenoveBuilder : IBuilder
    {
        private Computer computer = null;
        public LenoveBuilder()
        {
            computer = new Computer();
        }

        public Computer GetComputer()
        {
            return computer;
        }

        public void SetId()
        {
            computer.Id = "2";
        }

        public void SetName()
        {
            computer.Name = "Lenove";
        }
    }








    //这是对 建造者 的扩展
    //可以将复杂模块对外做扩展开放
    public class Computer2Builder
    {
        protected Computer2 computer = new Computer2 { Option=new Option()};

        //将Id模块对外扩展
        public virtual Computer2Builder Set(Action<Option> action)
        {
            if (action != null)
                action(computer.Option);            
            return this;
        }      
        public virtual Computer2 GetComputer() { return computer; }
    }

    public class Computer2
    {
        public Option Option { get; set; }
    }

    public class Option
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
