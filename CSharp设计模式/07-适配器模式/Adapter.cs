using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //适配器模式（结构型）
    //定义：把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作
    //两种形式：类的适配器模式和对象的适配器模式
    //使用场景
    //1.系统需要复用现有类，而该类的接口不符合系统的需求
    //2.想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作
    //3.对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际

    // 这里以插座和插头的例子来诠释适配器模式
    // 现在我们买的电器插头是2个孔，但是我们买的插座只有3个孔的
    // 这时我们想把电器插在插座上的话就需要一个电适配器
    #region 类的适配器模式
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public abstract class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("类的适配器：我是两个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，接口要放在类的后面
    /// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
    /// </summary>
    public class PowerAdapter : TwoHole, IThreeHole
    {
        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public void Request()
        {
            // 调用两个孔插头方法
            this.SpecificRequest();
        }
    }
    #endregion

    #region 对象的适配器模式
    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标(Target)角色
    /// </summary>
    public class ThreeHole2
    {
        public virtual void Request()
        {
            // TODO
        }
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public class TwoHole2
    {
        public void SpecificRequest()
        {
            Console.WriteLine("对象的适配器：我是两个孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，这里适配器类没有继承TwoHole类，而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class PowerAdapter2 : ThreeHole2
    {
        // 引用两个孔插头的实例,从而将客户端与TwoHole联系起来
        TwoHole2 twoHole = new TwoHole2();

        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public override void Request()
        {
            twoHole.SpecificRequest();
        }
    }
    #endregion
}
