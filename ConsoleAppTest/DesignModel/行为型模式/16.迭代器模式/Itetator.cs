using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._16.迭代器模式
{
    //迭代器模式
    //提供一种方法顺序的访问聚合对象中的各个元素，而又不暴露该聚合对象的内部表示。

    //首先由一个抽象聚合和一个抽象迭代器
    //抽象聚合
    public interface IMyList
    {
        //返回一个抽象迭代器
        IMyIterator GetIterator();
        int Length { get; }
        int Capacity { get; }
        object GetElement(int index);
        int Add(object entity);
    }

    //抽象迭代器
    public interface IMyIterator
    {
        bool MoveNext();
        void First();
        void Next();
        object CurrentItem();
    }

    public class MyList :IMyList{
        private int _length = 0;
        private int _capacity = 0;
        object[] _array;
        public int Capacity => _capacity;
        public int Length => _length;
       
        public MyList()
        {
            _array = new object[Capacity];
        }
        public int Add(object entity)
        {
            if(_length<Capacity)
                _array[_length++] = entity;
            else
            {
                _capacity += 10;
                object[] tempArray = new object[_capacity];
                _array.CopyTo(tempArray, 0);
                _array = tempArray;
                Add(entity);
            }
            return _length;
        }

        public object GetElement(int index) => index < _length ? _array[index] : throw new IndexOutOfRangeException();

        public IMyIterator GetIterator() => new MyIterator(this);

    }

    public class MyIterator : IMyIterator
    {
        IMyList _list;
        private int _index = 0;
        public MyIterator(IMyList list) => _list = list;

        public bool MoveNext() => _index < _list.Length;

        public void First() => _index = 0;

        public void Next()
        {
            if (_index < _list.Length)
                _index++;
        }

        public object CurrentItem() => _list.GetElement(_index);

    }





}
