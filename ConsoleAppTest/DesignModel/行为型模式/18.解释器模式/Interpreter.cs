using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._18.解释器模式
{
    //解释器模式
    //给定一个语言，定义它的文法的一种表示，并定义一种解释器，这个解释器使用该表示来解释语言中的句子。

    //相关角色：
    //1.抽象表达式 Expression
    //2.终结符表达式 TerminalExpression，派生自Expression，相当于叶子节点
    //3.非终结符表达式 NonterminalExpression，派生自Expression，相当于树枝节点
    //4.环境上下文角色Context，用来存放文法中各个终结符对应的具体值。

 //       Interpreter模式比较适合简单的文法表示，对于复杂的文法表示，Interpreter模式会产生比较大的类层次结构，需要求助于语法分析生成器这样的标准工具。

 //   （1）、解释器模式的主要优点有：

 //       1】、易于改变和扩展文法。

 //       2】、每一条文法规则都可以表示为一个类，因此可以方便地实现一个简单的语言。

 //       3】、实现文法较为容易。在抽象语法树中每一个表达式节点类的实现方式都是相似的，这些类的代码编写都不会特别复杂，还可以通过一些工具自动生成节点类代码。

 //       4】、增加新的解释表达式较为方便。如果用户需要增加新的解释表达式只需要对应增加一个新的终结符表达式或非终结符表达式类，原有表达式类代码无须修改，符合“开闭原则”

　//（2）、解释器模式的主要缺点有：

 //       1】、对于复杂文法难以维护。在解释器模式中，每一条规则至少需要定义一个类，因此如果一个语言包含太多文法规则，类的个数将会急剧增加，导致系统难以管理和维护，此时可以考虑使用语法分析程序等方式来取代解释器模式。

 //       2】、执行效率较低。由于在解释器模式中使用了大量的循环和递归调用，因此在解释较为复杂的句子时其速度很慢，而且代码的调试过程也比较麻烦。

 //   （3）、在下面的情况下可以考虑使用解释器模式：

 //       Interpreter模式的应用场合是Interpreter模式应用中的难点，只有满足“业务规则频繁变化，且类似的模式不断重复出现，并且容易抽象为语法规则的问题”才适合使用Interpreter模式。

 //       1】、当一个语言需要解释执行，并可以将该语言中的句子表示为一个抽象语法树的时候，可以考虑使用解释器模式（如XML文档解释、正则表达式等领域）

 //       2】、一些重复出现的问题可以用一种简单的语言来进行表达。

 //       3】、一个语言的文法较为简单.

 //       4】、当执行效率不是关键和主要关心的问题时可考虑解释器模式（注：高效的解释器通常不是通过直接解释抽象语法树来实现的，而是需要将它们转换成其他形式，使用解释器模式的执行效率并不高。）


    //环境上下文角色
    public sealed class MyContext
    {
        private string _statement;
        private int _data;

        public MyContext(string statement) => _statement = statement;
        public string Statement { get => _statement; set => _statement = value; }
        public int Data { get => _data; set => _data = value; }
    }


    public abstract class MyExpression
    {
        protected Dictionary<string, int> table = new Dictionary<string, int>(9);
        public MyExpression()
        {
            table.Add("一", 1);
            table.Add("二", 2);
            table.Add("三", 3);
            table.Add("四", 4);
            table.Add("五", 5);
            table.Add("六", 6);
            table.Add("七", 7);
            table.Add("八", 8);
            table.Add("九", 9);
        }

        public virtual void Interpreter(MyContext context)
        {
            if ((context?.Statement?.Length ?? 0) <= 0) return;

            foreach(var key in table.Keys)
            {
                int value = table[key];
                if (context.Statement.EndsWith(key + GetPostFix()))
                {
                    context.Data += value * Multiplier();
                    int length = GetLength();
                    context.Statement = context.Statement.Substring(0, context.Statement.Length - length);
                }
                if (context.Statement.EndsWith("零"))
                {
                    context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);
                }
            }
        }

        public abstract string GetPostFix();
        public abstract int Multiplier();
        public virtual int GetLength()
        {
            int length = GetPostFix()?.Length ?? 0;
           return length + 1;
        }
    }


    //个位表达式
    public sealed class GeExpression : MyExpression
    {
        public override string GetPostFix() => "";
        public override int Multiplier() => 1;
        public override int GetLength() => 1;
    }

    //十位表达式
    public sealed class ShiExpression : MyExpression
    {
        public override string GetPostFix() => "十";
        public override int Multiplier() => 10;
    }

    //百位表达式
    public sealed class BaiExpression : MyExpression
    {
        public override string GetPostFix() => "百";
        public override int Multiplier() => 100;
    }

    //千位表达式
    public sealed class QianExpression : MyExpression
    {
        public override string GetPostFix() => "千";
        public override int Multiplier() => 1000;
    }

    //万位表达式
    public class WanExpression : MyExpression
    {
        public override string GetPostFix() => "万";
        public override int Multiplier() => 10000;

        public override void Interpreter(MyContext context)
        {
            if ((context?.Statement?.Length ?? 0) <= 0)
                return;

            ArrayList tree = new ArrayList();
            tree.Add(new GeExpression());
            tree.Add(new ShiExpression());
            tree.Add(new BaiExpression());
            tree.Add(new QianExpression());

            foreach(var key in table.Keys)
            {
                if (context.Statement.EndsWith(GetPostFix()))
                {
                    int tmp = context.Data;
                    context.Data = 0;

                    context.Statement = context.Statement.Substring(0,context.Statement.Length-1);
                    foreach(var exp in tree)
                    {
                        (exp as MyExpression).Interpreter(context);
                    }

                    context.Data = tmp + context.Data * Multiplier();
                }
            }
        }
    }

    //亿位表达式
    public sealed class YiExpression : WanExpression
    {
        public override string GetPostFix() => "亿";
        public override int Multiplier() => 100_000_000;       
    }









}
