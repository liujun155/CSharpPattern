using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //工厂方法模式（创建型）
    //定义：提供一个接口，让子类决定实例化哪个类。
    //即在不知道具体实现类的情况下，定义一个用于创建对象的接口，让子类去实现。
    //解决简单工厂模式难以扩展的缺点
    //角色：
    //1、抽象工厂（Creator）：定义一个抽象的工厂接口，其中包含一个创建产品的方法。
    //2、具体工厂（Concrete Creator）：实现抽象工厂接口中的创建产品方法，具体工厂负责创建具体的产品。
    //3、抽象产品（Product）：定义产品的抽象接口，具体产品类实现该接口。
    //4、具体产品（Concrete Product）：实现抽象产品接口，是具体工厂生产的产品。
    //优点：
    //1、符合开闭原则：新增产品时，只需要添加相应的具体产品和具体工厂类即可，不需要修改抽象工厂类和客户端代码。
    //2、符合单一职责原则：每个具体工厂只负责创建对应的具体产品，职责单一清晰。
    //3、代码结构清晰，易于扩展和维护。
    //缺点：
    //1、增加了系统中类的个数，增加了系统的复杂度。
    //2、增加了系统的抽象性和理解难度。
    //使用场景：
    //1、当需要创建的对象具有共同的接口时，可以使用工厂方法模式来封装对象的创建过程。
    //2、当客户端不需要知道创建对象的具体类时，可以使用工厂方法模式来解耦客户端和具体实现类。
    //3、当系统需要支持多种具体产品时，可以使用工厂方法模式来扩展系统的功能。

    public static class FactoryMethodExample
    {
        public static void Run()
        {
            // 初始化做菜的两个工厂
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            // 开始做西红柿炒蛋
            Food food21 = tomatoScrambledEggsFactory.CreateFoodFactory();
            food21.Print();
            // 开始做土豆肉丝
            Food food22 = shreddedPorkWithPotatoesFactory.CreateFoodFactory();
            food22.Print();
        }
    }

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        public abstract Food CreateFoodFactory();
    }

    /// <summary>
    /// 西红柿炒蛋具体工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }

    /// <summary>
    /// 土豆肉丝具体工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }
}
