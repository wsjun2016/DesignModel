using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.结构型模式._7.适配器模式
{
    //适配器模式
    //适配器模式注重转换
    //将已经存在且不适应当前系统的接口或方法 转换为 适应当前系统的接口或方法
    //适配器模式 包含 类适配器模式(继承目标接口 和 源接口) 和 对象适配器模式(继承目标接口，组合源接口)

    //源抽象接口 两插孔的插头
    public abstract class TwoHole
    {
        public abstract void TwoHoleRequest();
    }

    //A品牌的 源接口
    public class ATwoHole : TwoHole
    {
        public override void TwoHoleRequest()
        {
            Console.WriteLine("A品牌的两个插孔的插头！");
        }
    }

    //B品牌的 源接口
    public class BTwoHole : TwoHole
    {
        public override void TwoHoleRequest()
        {
            Console.WriteLine("B品牌的两个插孔的插头！");
        }
    }

    //一般将目标接口 定义为 interface形式
    //三个插孔的插头
    public interface IThreeHole
    {
        void ThreeHoleRequest();
    }

    //类适配器模式
    //适配器继承 源接口 和 目标接口
    //因为是单继承，类适配器模式 只能实现 一种 源接口
    //实现A品牌的三个插孔的插头
    public class AClassAdapter : ATwoHole, IThreeHole
    {
        public void ThreeHoleRequest()
        {
            TwoHoleRequest();
        }     
    }

    //类适配器模式
    //适配器继承 源接口 和 目标接口
    //因为是单继承，类适配器模式 只能实现 一种 源接口
    //实现B品牌的三个插孔的插头
    public class BClassAdapter : BTwoHole, IThreeHole
    {
        public void ThreeHoleRequest()
        {
            TwoHoleRequest();
        }
    }

    //对象适配器模式
    //适配器 继承 目标接口，组合 源接口
    //一般在用适配器模式的时候，对象适配器模式 用的次数 更多，因为对象适配器模式可以组合N个源接口
    //而 类适配器模式只能继承一个源接口
    public class ObjectAdapter : IThreeHole
    {
        //适配多个品牌的源接口，也可以适配一个品牌的源接口
        protected TwoHole ATwoHole;
        protected TwoHole BTwoHole;
        public ObjectAdapter(TwoHole aTwoHole,TwoHole bTwoHole)
        {
            ATwoHole = aTwoHole;
            BTwoHole = bTwoHole;
        }
        public void ThreeHoleRequest()
        {
            ATwoHole.TwoHoleRequest();
            BTwoHole.TwoHoleRequest();
        }
    }


}
