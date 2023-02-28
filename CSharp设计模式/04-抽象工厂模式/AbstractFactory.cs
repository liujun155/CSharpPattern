using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //抽象工厂模式（创建型）
    //定义：提供了一种将相关或相互依赖对象创建的接口，而无需指定它们具体的类。
    //工厂方法针对的是多个产品系列结构；而抽象工厂模式针对的是多个产品族结构，一个产品族内有多个产品系列
    //即工厂方法模式是一个产品系列一个工厂类，而抽象工厂模式是多个产品系列一个工厂类
    //角色：
    //1、抽象工厂（Abstract Factory）：定义一个抽象的工厂接口，其中包含一组创建产品的方法。
    //2、具体工厂（Concrete Factory）：实现抽象工厂接口中的一组创建产品的方法，每个具体工厂负责创建一组相关的产品。
    //3、抽象产品（Abstract Product）：定义产品的抽象接口，具体产品类实现该接口。
    //4、具体产品（Concrete Product）：实现抽象产品接口，是具体工厂生产的产品。
    //优点：
    //1、符合开闭原则：新增产品族时，只需要添加相应的具体产品和具体工厂类即可，不需要修改抽象工厂类和客户端代码。
    //2、符合单一职责原则：每个具体工厂只负责创建对应的具体产品，职责单一清晰。
    //3、保持了一定的封装性：客户端无需知道创建对象的具体类，而只需要知道所需产品的抽象类。
    //4、更容易实现产品族的扩展：在抽象工厂模式中，可以方便地添加新的产品族，只需要添加相应的具体产品和具体工厂类即可。
    //缺点：
    //1、增加了系统中类的个数，增加了系统的复杂度。
    //2、难以支持新种类的产品。因为抽象工厂接口确定了可以被创建的产品集合，所以难以扩展抽象工厂以生产新种类的产品。
    //3、增加了系统的抽象性和理解难度。
    //使用场景
    //1、当需要创建一组相关或相互依赖的对象时，可以使用抽象工厂模式来封装对象的创建过程。
    //2、当客户端不需要知道创建对象的具体类时，可以使用抽象工厂模式来解耦客户端和具体实现类。
    //3、当系统需要支持多种产品族时，可以使用抽象工厂模式来扩展系统的功能。
    //扩展时需要添加的类：具体工厂、具体产品类

    public static class AbstractFactoryExample
    {
        public static void Run()
        {
            // 奔驰工厂制造奔驰的轿车和SUV
            AbstractFactory benzFactory = new BenzFactory();
            Car benzCar = benzFactory.CreateCar();
            benzCar.Print();
            Suv benzSuv = benzFactory.CreateSuv();
            benzSuv.Print();
            // 宝马工厂制造宝马的轿车和SUV
            AbstractFactory bmwFactory = new BMWFactory();
            Car bmwCar = bmwFactory.CreateCar();
            bmwCar.Print();
            Suv bmwSuv = bmwFactory.CreateSuv();
            bmwSuv.Print();
        }
    }

    /// <summary>
    /// 抽象工厂类，提供创建两个不同厂家的轿车和SUV的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口
        public abstract Car CreateCar();
        public abstract Suv CreateSuv();
    }

    /// <summary>
    /// 奔驰工厂负责制造奔驰的轿车和SUV（具体工厂类）
    /// </summary>
    public class BenzFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new BenzCar();
        }

        public override Suv CreateSuv()
        {
            return new BenzSuv();
        }
    }

    /// <summary>
    /// 宝马工厂负责制造宝马的轿车和SUV（具体工厂类）
    /// </summary>
    public class BMWFactory : AbstractFactory
    {
        public override Car CreateCar()
        {
            return new BMWCar();
        }

        public override Suv CreateSuv()
        {
            return new BMWSuv();
        }
    }

    /// <summary>
    /// 轿车抽象类，供每个厂家的轿车类继承（抽象产品类）
    /// </summary>
    public abstract class Car
    {
        public abstract void Print();
    }

    /// <summary>
    /// SUV抽象类，供每个厂家的SUV类继承（抽象产品类）
    /// </summary>
    public abstract class Suv
    {
        public abstract void Print();
    }

    /// <summary>
    /// 奔驰的轿车类(具体产品实现类，客户端最终想要的结果)
    /// </summary>
    public class BenzCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("奔驰的轿车");
        }
    }

    /// <summary>
    /// 宝马的轿车类(具体产品实现类，客户端最终想要的结果)
    /// </summary>
    public class BMWCar : Car
    {
        public override void Print()
        {
            Console.WriteLine("宝马的轿车");
        }
    }

    /// <summary>
    /// 奔驰的SUV(具体产品实现类，客户端最终想要的结果)
    /// </summary>
    public class BenzSuv : Suv
    {
        public override void Print()
        {
            Console.WriteLine("奔驰的SUV");
        }
    }

    /// <summary>
    /// 宝马的Suv(具体产品实现类，客户端最终想要的结果)
    /// </summary>
    public class BMWSuv : Suv
    {
        public override void Print()
        {
            Console.WriteLine("宝马的SUV");
        }
    }
}
