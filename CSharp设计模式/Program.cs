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
            Console.WriteLine("===============简单工厂模式===============");
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒蛋");
            food1.Print();
            Food food2 = FoodSimpleFactory.CreateFood("土豆肉丝");
            food2.Print();
            #endregion

            #region 工厂方法模式
            Console.WriteLine("\n===============工厂方法模式===============");
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
            Console.WriteLine("\n===============抽象工厂模式===============");
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
            Console.WriteLine("\n===============建造者模式===============");
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
            Console.WriteLine("\n===============原型模式===============");
            // 孙悟空原型
            MonkeyKingPrototype monkeyKingPrototype = new ConcretePrototype("MonkeyKing");

            // 克隆一个
            MonkeyKingPrototype cloneMonkeyKing1 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing1.Id}");
            // 克隆两个
            MonkeyKingPrototype cloneMonkeyKing2 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing2.Id}");
            #endregion

            #region 适配器模式
            Console.WriteLine("\n===============适配器模式===============");
            //类的适配器模式
            IThreeHole threeHole = new PowerAdapter();
            threeHole.Request();
            //对象的适配器模式
            ThreeHole2 threeHole2 = new PowerAdapter2();
            threeHole2.Request();
            #endregion

            #region 桥接模式
            Console.WriteLine("\n===============桥接模式===============");
            RemoteControl remoteControl = new ConcreteRemote();
            //长虹电视
            remoteControl.Implementor = new ChangHong();
            remoteControl.On();
            remoteControl.Off();
            remoteControl.TurnChannel();
            //三星电视
            remoteControl.Implementor = new Samsung();
            remoteControl.On();
            remoteControl.Off();
            remoteControl.TurnChannel();
            #endregion

            #region 装饰者模式
            Console.WriteLine("\n===============装饰者模式===============");
            //一个苹果手机
            Phone phone = new ApplePhone();
            //现在贴膜
            Decorator applePhoneWithSticker = new Sticker(phone);
            //扩展贴膜行为
            applePhoneWithSticker.Print();
            Console.WriteLine("----------------------\n");

            //现在有个手机挂件
            Decorator applePhoneWithAccessories = new Accessories(phone);
            //扩展手机挂件行为
            applePhoneWithAccessories.Print();
            Console.WriteLine("----------------------\n");

            //同时有贴膜和手机挂件
            Sticker sticker = new Sticker(phone);
            Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
            applePhoneWithAccessoriesAndSticker.Print();
            #endregion

            #region 组合模式
            Console.WriteLine("\n===============组合模式===============");
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics compositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            compositeCG.Add(new Circle("圆"));
            compositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(compositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);

            // 显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");

            // 移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            #endregion

            #region 外观模式
            Console.WriteLine("\n===============外观模式===============");
            RegistrationFacade facade = new RegistrationFacade();
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }
            #endregion

            #region 享元模式
            Console.WriteLine("\n===============享元模式===============");
            FlyWeightExample.Run();
            #endregion

            #region 代理模式
            Console.WriteLine("\n===============代理模式===============");
            ProxyExample.Run();
            #endregion

            #region 模板方法模式
            Console.WriteLine("\n===============模板方法模式===============");
            TemplateMethodExample.Run();
            #endregion

            #region 命令模式
            Console.WriteLine("\n===============命令模式===============");
            CommandExample.Run();
            #endregion

            #region 迭代器模式
            Console.WriteLine("\n===============迭代器模式===============");
            IteratorExample.Run();
            #endregion

            Console.ReadLine();
        }
    }
}
