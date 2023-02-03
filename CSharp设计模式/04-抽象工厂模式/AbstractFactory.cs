using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //抽象工厂模式（创建型）
    //工厂方法针对的是多个产品系列结构；而抽象工厂模式针对的是多个产品族结构，一个产品族内有多个产品系列
    //即工厂方法模式是一个产品系列一个工厂类，而抽象工厂模式是多个产品系列一个工厂类
    //包含四个角色：抽象工厂角色，具体工厂角色，抽象产品角色，具体产品角色
    //使用场景
    //1.一个系统要独立于它的产品的创建、组合和表示时
    //2.一个系统要由多个产品系列中的一个来配置时
    //3.需要强调一系列相关的产品对象的设计以便进行联合使用时
    //4.提供一个产品类库，而只想显示它们的接口而不是实现时
    //缺点：难以支持新种类的产品。因为抽象工厂接口确定了可以被创建的产品集合，所以难以扩展抽象工厂以生产新种类的产品
    //扩展时需要添加的类：具体工厂类、具体产品实现类

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
