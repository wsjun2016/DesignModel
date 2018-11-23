using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._13.代理模式
{
    //代理模式
    //为某个对象提供一种代理，以控制对这个对象的访问
    //可以对 远程或异地的 对象 使用代理模式，使得可以在本地进行访问，如Internet代理。也可以对复杂对象使用代理模式，使得可以更方便的调用


    //第一种：使用组合依赖的方式代理某个对象
    //假如异地有一个MyMath类，我们可以将之组合在代理类中，使得在本地可以很方便的进行调用
    public class MathProxy
    {
        //被代理的对象
        private readonly IMyMath math=new MyMath();

        //代理Math.Max方法
        public int Max(int a,int b)
        {
            return math.Max(a,b);
        }

        //代理Math.Min方法
        public int Min(int a,int b)
        {
            return math.Min(a, b);
        }
    }


    //第二种：继承某个对象的接口，强制代理所有方法
    public interface IMyMath
    {
        int Max(int a,int b);
        int Min(int a,int b);
        int Add(int a, int b);
    }

    public class MyMath : IMyMath
    {
        public int Add(int a, int b) => a + b;

        public int Min(int a, int b) => Math.Min(a, b);

        public int Max(int a, int b) => Math.Max(a, b);
    }

    //代理类
    public class MyMathProxy : IMyMath
    {
        //被代理的对象
        private readonly IMyMath math = new MyMath();

        //以下是被强制代理的所有方法

        public int Add(int a, int b)
        {
            return math.Add(a, b);
        }        

        public int Max(int a, int b)
        {
            return math.Max(a, b);
        }

        public int Min(int a, int b)
        {
            return math.Min(a, b);
        }
    }














}
