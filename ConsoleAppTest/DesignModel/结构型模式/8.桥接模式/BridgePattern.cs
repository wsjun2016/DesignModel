using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._8.桥接模式
{
    //桥接模式
    //将抽象与实现分离
    //使得在多个有关系的维度下，每个维度可以有多个不同的变化(也就是说，一个抽象可以有多个子类)
    //且在每个维度变化的同时，它们之间互不影响，也就是说每个维度随意切换子类的同时，每个维度之间互不影响
    //桥接模式 使用组合

    //当每个维度可以被抽象化出来时，就可以用桥接模式
    //一个维度就是一个抽象类或接口，多个变化指的就是该抽象类或接口有多个子类(即 使用多态的性质)

    #region 第一个
    //用毛笔画画
    //共有两个维度，毛笔和颜色
    //毛笔分为大中小号，颜色分为赤橙黄绿青蓝紫等

    public abstract class Color
    {
        public string Name { get; set; }
    }

    public abstract class Brush
    {
        protected Color Color = null;
        public abstract void Paint();
        public virtual void SetColor(Color color)
        {
            this.Color = color;
        }
    }

    public class BigBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"brush:big color:{Color.Name}");
        }
    }

    public class SmallBrush : Brush
    {
        public override void Paint()
        {
            Console.WriteLine($"brush:small color:{Color.Name}");
        }
    }

    public class Red : Color
    {
        public Red() { this.Name = "red"; }
    }

    public class Black : Color
    {
        public Black() { this.Name = "black"; }
    }

    public class Green : Color
    {
        public Green() { this.Name = "green"; }
    }

    #endregion

    #region 第二个

    //抽象部分
    public abstract class Abstraction
    {
        protected Implementor _implementor;
        public Implementor Implementor
        {
            get { return _implementor; }
            set { _implementor = value; }
        }

        public virtual void Operation()
        {
            _implementor.ImpOperation();
        }
    }

    //引起抽象部分变化的子类
    public  class ObjectAbstraction : Abstraction
    {
        public override void Operation()
        {
            _implementor.ImpOperation();
        }
    }

    //实现部分(将某些行为或其他等抽象出来)
    public abstract class Implementor
    {
        //将行为抽象出来
        public abstract void ImpOperation();
    }

    //引起实现部分变化的子类A
    public class AImplementor : Implementor
    {
        public override void ImpOperation()
        {
            Console.WriteLine($"AImplementor.ImpOperation");
        }
    }

    //引起实现部分变化的子类B
    public class BImplementor : Implementor
    {
        public override void ImpOperation()
        {
            Console.WriteLine($"BImplementor.ImpOperation");
        }
    }


    #endregion

}
