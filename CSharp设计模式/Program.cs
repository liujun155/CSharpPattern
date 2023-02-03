using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 简单工厂模式
            Console.WriteLine("==========简单工厂模式==========");
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
            food1.Print();
            Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
            food2.Print();
            #endregion

            #region 工厂方法模式
            Console.WriteLine("==========工厂方法模式==========");
            // 初始化做菜的两个工厂
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            // 开始做西红柿炒蛋
            Food food21 = tomatoScrambledEggsFactory.CreateFoodFactory();
            food21.Print();
            // 开始做土豆肉丝
            Food food22 = shreddedPorkWithPotatoesFactory.CreateFoodFactory();
            food22.Print();
            #endregion

            #region 抽象工厂模式
            Console.WriteLine("==========抽象工厂模式==========");
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
            #endregion

            #region 建造者模式
            Console.WriteLine("==========建造者模式==========");
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            // 老板叫员工去组装第一台电脑
            director.Construct(b1);
            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();
            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();
            #endregion

            #region 原型模式
            Console.WriteLine("==========原型模式==========");
            // 孙悟空原型
            MonkeyKingPrototype monkeyKingPrototype = new ConcretePrototype("MonkeyKing");

            // 克隆一个
            MonkeyKingPrototype cloneMonkeyKing1 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing1.Id}");
            // 克隆两个
            MonkeyKingPrototype cloneMonkeyKing2 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing2.Id}");
            #endregion

            Console.ReadLine();
        }
    }
}
