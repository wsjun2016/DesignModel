using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._14.模板方法 {
    //模板方法
    //定义一个操作中算法的骨架，将一些步骤延迟到子类中实现
    //即定义一个适用的模板骨架，将不变的定义在父类中，有区别的延迟到子类中去实现
    //模板方法模式建议将算法分解为一系列步骤，然后将这些步骤改写为方法， 最后在“模板方法”中依次调用这些方法。步骤可以是 抽象 的，也可以有一些默认的实现。为了能够使用算法，客户端需要自行提供子类并实现所有的抽象步骤。如有必要还需重写一些步骤（但这一步中不包括模板方法自身）

    //角色
    //抽象类（AbstractClass） 会声明作为算法步骤的方法， 以及依次调用它们的实际模板方法。 算法步骤可以被声明为抽象 类型，也可以提供一些默认实现。
    //具体类（ConcreteClass）可以重写所有步骤，但不能重写模板方法自身。

    //应用场景
    //当你只希望客户端扩展某个特定算法步骤，而不是整个算法或其结构时，可使用模板方法模式。
    //  模板方法将整个算法转换为一系列独立的步骤，以便子类能对其进行扩展，同时还可让超类中所定义的结构保持完整。
    //当多个类的算法除一些细微不同之外几乎完全一样时，你可使用该模式。但其后果就是，只要算法发生变化，你就可能需要修改所有的类。
    //  在将算法转换为模板方法时，你可将相似的实现步骤提取到超类中以去除重复代码。子类间各不同的代码可继续保留在子类中。

    //实现方式
    //1.分析目标算法，确定能否将其分解为多个步骤。从所有子类的角度出发，考虑哪些步骤能够通用，哪些步骤各不相同。
    //2.创建抽象基类并声明一个模板方法和代表算法步骤的一系列抽象方法。 在模板方法中根据算法结构依次调用相应步骤。可用 final 最终 修饰模板方法以防止子类对其进行重写。
    //3.虽然可将所有步骤全都设为抽象类型，但默认实现可能会给部分步骤带来好处，因为子类无需实现那些方法。
    //4.可考虑在算法的关键步骤之间添加钩子。
    //5.为每个算法变体新建一个具体子类，它必须实现所有的抽象步骤，也可以重写部分可选步骤。

    //如 调用接口的实现过程
    public abstract class HandlerBase<TInputEntity,TOutputEntity>
    {     
        //进行模型绑定
        protected virtual TInputEntity ModelBinder(string json) {
            return JsonConvert.DeserializeObject<TInputEntity>(json);
        }

        //对model进行数据合法性验证
        protected virtual bool Validation(TInputEntity model) {          
            //暂时返回true
            return true;
        }

        //需要延迟到子类中实现的方法
        protected abstract TOutputEntity OnWork(TInputEntity input);

        //算法骨架方法，即模板方法
        public virtual TOutputEntity Process(string json)
        {
            var model = ModelBinder(json);
            return Validation(model) ? OnWork(model) : throw new ArgumentException();     
        }
    }


    public class StudentHandler : HandlerBase<Student, AjaxResult>
    {
        protected override AjaxResult OnWork(Student input)
        {
            return new AjaxResult { Code = 1, Message = "成功！", Result = input };
        }
    }

    public class TeacherHandler : HandlerBase<Teacher, AjaxResult>
    {
        protected override AjaxResult OnWork(Teacher input)
        {
            return new AjaxResult { Code = 2, Message = "成功！", Result = input };
        }
    }


    #region 基础类型


    public class Student
    {
        public string SName { get; set; }
        public int SAge { get; set; }

        public override string ToString()
        {
            return $"{SName} {SAge}";
        }
    }

    public class Teacher
    {
        public string TName { get; set; }
        public string TAge { get; set; }
    }


    public class AjaxResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public static AjaxResult Null => new AjaxResult();
    }



    #endregion

}
