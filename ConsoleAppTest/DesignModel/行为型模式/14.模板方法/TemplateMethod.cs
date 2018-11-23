using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._14.模板方法
{
    //模板方法
    //定义一个操作中算法的骨架，将一些步骤延迟的子类中实现
    //即定义一个适用的模板骨架，将不变的定义在父类中，有区别的延迟到子类中去实现

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
