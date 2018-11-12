using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._09.组合模式
{
    //组合模式
    //针对某一个类型的处理，可以将 一对多 的关系 转化为 一对一 的关系
    //如何将 多 转换为 一，用集合
    //单个对象和多个对象的处理方式一样，那么就证明 多个对象所属的集合中的类型和单个对象的类型一致
    //即单个对象是Component，那么这个对象中的集合就是IList<Component>，这样才能一致性处理


    public abstract class Component
    {
        protected string _name;

        public Component(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);
        public abstract int Add(Component obj);
        public abstract int Remove(Component obj);
        public abstract Component GetChild(int index);
    }

    //叶子节点
    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String( ' ',depth)+_name);
        }

        public override int Add(Component obj)
        {
            throw new NotImplementedException();
        }

        public override int Remove(Component obj)
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }

    //复合类型
    public class ComplexComponent : Component
    {
        protected IList<Component> _items;
        public ComplexComponent(string name) : base(name)
        {
            _items=new List<Component>();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + _name);
            foreach (var item in _items)
            {
               item.Display(depth+2);
            }
        }

        public override int Add(Component obj)
        {
            if(obj!=null)
                _items.Add(obj);
            return _items.Count;
        }

        public override int Remove(Component obj)
        {
            if (obj != null)
                _items.Remove(obj);
            return _items.Count;
        }

        public override Component GetChild(int index)
        {
            if (index > -1 && index < _items.Count)
                return _items[index];
            else throw new IndexOutOfRangeException("index is out of range!");
        }
    }

}
