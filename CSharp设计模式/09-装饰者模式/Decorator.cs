using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //装饰者模式（结构型）
    //定义：允许向一个现有的对象添加新的功能，同时又不改变其结构
    //主要解决：一般的，我们为了扩展一个类经常使用继承方式实现，由于继承为类引入静态特征，并且随着扩展功能的增多，子类会很膨胀
    //何时使用：在不想增加很多子类的情况下扩展类
    //优点：装饰类和被装饰类可以独立发展，不会相互耦合，装饰模式是继承的一个替代模式，装饰模式可以动态扩展一个实现类的功能
    //缺点：多层装饰比较复杂
    //使用场景： 1、扩展一个类的功能；2、动态增加功能，动态撤销

    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }

    /// <summary>
    /// 苹果手机，即装饰着模式中的具体组件类
    /// </summary>
    public class ApplePhone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("开始执行具体的对象——苹果手机");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Phone
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone phone;

        public Decorator(Phone p)
        {
            this.phone = p;
        }

        public override void Print()
        {
            if (phone != null) { phone.Print(); }
        }
    }

    /// <summary>
    /// 贴膜（具体装饰者）
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone p) : base(p)
        {
        }

        public override void Print()
        {
            base.Print();
            // 添加新的行为
            AddSticker();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddSticker()
        {
            Console.WriteLine("现在苹果手机有贴膜了");
        }
    }

    /// <summary>
    /// 手机挂件（具体装饰者）
    /// </summary>
    public class Accessories : Decorator
    {
        public Accessories(Phone p) : base(p)
        {
        }

        public override void Print()
        {
            base.Print();
            // 添加新的行为
            AddAccessories();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void AddAccessories()
        {
            Console.WriteLine("现在苹果手机有漂亮的挂件了");
        }
    }
}
