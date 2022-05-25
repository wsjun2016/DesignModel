using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._12.享元模式 {
    //享元模式
    //注重接口的信息保留，在内部 使用 共享技术 对 对象存储 进行优化

    //共享对象有两种状态需要注意：
    //1.内部状态，可以存储在享元内部，也就是不随着外部环境变化而变化的状态，也就是不变的，是可以共享的；
    //2.外部状态，不可以共享，该状态会随着环境的变化而变化，这些状态由客户端来维持(因为外部环境的变化是由客户端引起的)

    //如何寻找享元的内部状态和外部状态？
    //将不变的属性当做内部状态，存储在享元中
    //将随外部变化的属性当做外部状态，不存在享元中，将之放在享元的操作方法(Operation)的形参中，由客户端来维持
    //剔除了 外部状态 就剩下 内部状态


    //如果享元工厂中不存在某个享元，需要创建之，并保存到享元工厂中

    //角色
    //抽象享元角色（Flyweight）：此角色是所有的具体享元类的基类，为这些类规定出需要实现的公共接口。那些需要外部状态的操作可以通过调用方法以参数形式传入；
    //具体享元角色（ConcreteFlyweight）：实现抽象享元角色所规定的接口。如果有内部状态的话，可以在类内部定义；
    //享元工厂角色（FlyweightFactory）：本角色负责创建和管理享元角色。本角色必须保证享元对象可以被系统适当地共享，当一个客户端对象调用一个享元对象的时候，享元工厂角色检查系统中是否已经有一个符合要求的享元对象。如果已经存在，享元工厂角色就提供已存在的享元对象，如果系统中没有一个符合的享元对象的话，享元工厂角色就应当创建一个合适的享元对象；
    //客户端角色（Client）：本角色需要存储所有享元对象的外部状态；

    //应用场景
    //仅在程序必须支持大量对象且没有足够的内存容量时使用享元模式
    //应用该模式所获的收益大小取决于使用它的方式和情景。它在下列情况中最有效：
    //• 程序需要生成数量巨大的相似对象
    //• 这将耗尽目标设备的所有内存
    //• 对象中包含可抽取且能在多个对象间共享的重复状态。

    //实现方式
    //1.将需要改写为享元的类成员变量拆分为两个部分：
    //  内在状态：包含不变的、可在许多对象中重复使用的数据的成员变量；
    //  外在状态：包含每个对象各自不同的情景数据的成员变量。
    //2.保留类中表示内在状态的成员变量，并将其属性设置为不可修改。这些变量仅可在构造函数中获得初始数值。
    //3.找到所有使用外在状态成员变量的方法，为在方法中所用的每个成员变量新建一个参数，并使用该参数代替成员变量。
    //4.你可以有选择地创建工厂类来管理享元缓存池，它负责在新建享元时检查已有的享元。如果选择使用工厂，客户端就只能通过工厂来请求享元，它们需要将享元的内在状态作为参数传递给工厂。


    public class FlyweightFactory
    {
        public Hashtable Items;

        public FlyweightFactory()
        {
            Items = new Hashtable();
        }

        public Character GetCharacter(object key)
        {
            return Items[key] as Character;
        }
    }

    public abstract class Character
    {
        //position为外部状态
        public abstract void Operation(int position);
    }

    public class EnglishCharacter : Character {
        //内部状态 表示当前字符
        protected char _character;

        public EnglishCharacter(char character) {
            _character = character;
        }

        //position为外部状态
        public override void Operation(int position)
        {
            Console.WriteLine($"innerState:{_character} outerState:{position}");
        }
    }

    public class ChineseCharacter : Character
    {
        //内部状态 表示当前字符
        protected string _character;

        public ChineseCharacter(string chineseCharacter)
        {
            _character = chineseCharacter;
        }

        //position为外部状态
        public override void Operation(int position)
        {
           Console.WriteLine($"innerState:{_character}  outerState:{position}");
        }
    }

}
