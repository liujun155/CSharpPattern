using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //简单工厂模式（创建型）
    //定义：通过一个工厂类，根据不同的输入参数来创建不同的产品对象。
    //角色：
    //1、工厂类（Factory）：负责创建产品对象的工厂类，一般包含一个静态的工厂方法，根据传入的参数不同，返回不同的产品对象。
    //2、抽象产品类（Product）：定义了产品对象的共性，抽象出产品对象的公共接口和抽象方法。
    //3、具体产品类（Concrete Product）：实现了抽象产品类中的抽象方法，具体产品类由工厂类根据传入的参数来创建。
    //优点：
    //1、客户端代码与产品对象的创建过程分离，客户端只需要知道所需产品的类型，无需关心创建过程。
    //2、工厂类中包含了所有产品对象的创建逻辑，可以集中管理，便于维护和扩展。
    //3、可以通过工厂类来控制产品对象的创建过程，例如添加一些额外的校验或者日志功能。
    //缺点：
    //1、工厂类中包含了所有产品对象的创建逻辑，如果产品对象较多，工厂类会变得非常复杂，不易维护和扩展。
    //2、新增产品对象时需要修改工厂类的代码，违反了开闭原则（对扩展开放，对修改关闭）。
    //使用场景：
    //1、客户端只需要知道所需产品的类型，无需关心创建过程。
    //2、产品对象较少，不会频繁添加或修改。
    //3、工厂类不需要扩展，即产品对象的创建逻辑不需要改变。
    //实际应用场景：
    //1、数据库连接：比如说你的程序要访问数据库，但是你不知道要访问那种，或者支持多种，就可以把访问的具体方法都定义为接口，实例化的时候，根据不同的参数，通过工厂模式，实例化不同类型的数据访问类。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class SimpleFactoryExample
    {
        public static void Run()
        {
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
            food1.Print();
            Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
            food2.Print();
        }
    }

    /// <summary>
    /// 菜 抽象类
    /// </summary>
    public abstract class Food
    {
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒蛋菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋！");
        }
    }

    /// <summary>
    /// 土豆肉丝菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份土豆肉丝！");
        }
    }

    /// <summary>
    /// 简单工厂类，负责炒菜
    /// </summary>
    public class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type == "西红柿炒蛋")
            {
                food = new TomatoScrambledEggs();
            }
            else if (type == "土豆肉丝")
            {
                food = new ShreddedPorkWithPotatoes();
            }
            return food;
        }
    }
}
