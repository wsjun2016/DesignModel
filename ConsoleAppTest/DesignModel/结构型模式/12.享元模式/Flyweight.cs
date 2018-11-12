using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._12.享元模式
{
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
