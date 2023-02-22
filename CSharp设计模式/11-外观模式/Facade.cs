using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //外观模式（结构型）
    //定义：隐藏系统的复杂性，并向客户端提供了一个客户端可以访问系统的接口
    //优点： 1、减少系统相互依赖。 2、提高灵活性。 3、提高了安全性
    //缺点：不符合开闭原则，如果要改东西很麻烦，继承重写都不合适

    // 以学生选课系统为例子演示外观模式的使用
    // 学生选课模块包括功能有：
    // 验证选课的人数是否已满
    // 通知用户课程选择成功与否

    /// <summary>
    /// 外观类
    /// </summary>
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStudent;

        public RegistrationFacade()
        {
            registerCourse= new RegisterCourse();
            notifyStudent= new NotifyStudent();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
                return false;
            return notifyStudent.Notify(studentName);
        }
    }

    #region 子系统
    /// <summary>
    /// 注册课程子系统
    /// </summary>
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0} 是否人数已满", courseName);
            return true;
        }
    }

    /// <summary>
    /// 通知子系统
    /// </summary>
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向 {0} 发生通知", studentName);
            return true;
        }
    }
    #endregion
}
