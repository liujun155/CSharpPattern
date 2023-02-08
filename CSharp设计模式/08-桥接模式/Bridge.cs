using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //桥接模式（结构型）
    //定义：用于把抽象化与实现化解耦，使得二者可以独立变化
    //优点：1.把抽象接口与其实现解耦；2.抽象和实现可以独立扩展，不会影响到对方；3.实现细节对客户透明，对用于隐藏了具体实现细节
    //缺点：增加了系统的复杂度
    //使用场景：
    //1、如果一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性，避免在两个层次之间建立静态的继承联系，通过桥接模式可以使它们在抽象层建立一个关联关系
    //2、对于那些不希望使用继承或因为多层次继承导致系统类的个数急剧增加的系统，桥接模式尤为适用
    //3、一个类存在两个独立变化的维度，且这两个维度都需要进行扩展

    #region 遥控器类
    /// <summary>
    /// 抽象概念中的遥控器，扮演抽象化角色
    /// </summary>
    public class RemoteControl
    {
        private TV implementor;

        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        /// <summary>
        /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
        /// </summary>
        public virtual void On()
        {
            implementor.On();
        }

        /// <summary>
        /// 关电视机
        /// </summary>
        public virtual void Off()
        {
            implementor.Off();
        }

        /// <summary>
        /// 换频道
        /// </summary>
        public virtual void TurnChannel()
        {
            implementor.TurnChannel();
        }
    }

    /// <summary>
    /// 具体遥控器类
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void TurnChannel()
        {
            Console.WriteLine("--------------------");
            base.TurnChannel();
            Console.WriteLine("--------------------");
        }
    }
    #endregion

    #region 电视机类
    /// <summary>
    /// 电视机类，提供抽象方法
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();
    }

    /// <summary>
    /// 长虹牌电视机，电视机具体实现类
    /// </summary>
    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关闭了");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    /// <summary>
    /// 三星牌电视机，电视机具体实现类
    /// </summary>
    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关闭了");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }
    #endregion
}
