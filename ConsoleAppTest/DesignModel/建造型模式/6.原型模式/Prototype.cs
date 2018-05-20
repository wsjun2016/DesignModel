using DesignModel.建造型模式._2.简单工厂;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignModel.建造型模式._6.原型模式
{
    //原型模式
    //对象可以复制自己

    public interface IClone<TEntity>
    {
        //深拷贝
        TEntity DeepClone();
        //浅拷贝
        TEntity WiseClone();
    }

    [Serializable]
    public abstract class PrototypeBase : IClone<PrototypeBase>
    {
        public PrototypeBase DeepClone()
        {
            PrototypeBase rc = null;
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(stream, this);
                stream.Position = 0;
                rc = binary.Deserialize(stream) as PrototypeBase;
            }
            return rc;
        }

        
        public PrototypeBase WiseClone()
        {
            return this.MemberwiseClone() as PrototypeBase;
        }       
    }

    [Serializable]
    public class PrototypeA : PrototypeBase
    {
        public Car DaZhong { get; set; }
        public string Name { get; set; }
    }
}
