using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.建造型模式._01.单例模式
{
    /// <summary>
    /// 单例模式
    /// 不可继承
    /// 整个应用程序只有一个实例
    /// </summary>
    public sealed class SingleTon
    {
        //提供私有构造函数，只能在内部实例化
        private SingleTon() { }


        private readonly static object _lock = new object();
        private static SingleTon _instance = null;
        
        public int Count { get; set; }
        public static SingleTon Instance
        {
            get
            {
                //第一重锁
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        //第二重锁
                        lock (_lock)
                        {
                            _instance = new SingleTon();
                        }
                    }
                }
                return _instance;
            }
        }


    }

    //使用Lazy<>泛型在需要的时候懒加载单例对象
    public sealed class SingletonViaLazy
    {
        private static readonly Lazy<SingletonViaLazy> _instance = new Lazy<SingletonViaLazy>(()=>new SingletonViaLazy());
        public static SingletonViaLazy Instance = _instance.Value;

        private SingletonViaLazy() { }

        public int Count { set; get; }
    }


}
