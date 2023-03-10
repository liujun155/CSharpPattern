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
            #region 单例模式
            Console.WriteLine("===============单例模式===============");
            SingletonExample.Run();
            #endregion

            #region 简单工厂模式
            Console.WriteLine("\n===============简单工厂模式===============");
            SimpleFactoryExample.Run();
            #endregion

            #region 工厂方法模式
            Console.WriteLine("\n===============工厂方法模式===============");
            FactoryMethodExample.Run();
            #endregion

            #region 抽象工厂模式
            Console.WriteLine("\n===============抽象工厂模式===============");
            AbstractFactoryExample.Run();
            #endregion

            #region 建造者模式
            Console.WriteLine("\n===============建造者模式===============");
            BuilderExample.Run();
            #endregion

            #region 原型模式
            Console.WriteLine("\n===============原型模式===============");
            PrototypeExample.Run();
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

            #region 观察者模式
            Console.WriteLine("\n===============观察者模式===============");
            ObserverExample.Run();
            #endregion

            #region 中介者模式
            Console.WriteLine("\n===============中介者模式===============");
            MediatorExample.Run();
            #endregion

            #region 状态者模式
            Console.WriteLine("\n===============状态者模式===============");
            StateExample.Run();
            #endregion

            #region 策略者模式
            Console.WriteLine("\n===============策略者模式===============");
            StragetyExample.Run();
            #endregion

            #region 责任链模式
            Console.WriteLine("\n===============责任链模式===============");
            ChainOfResponsibilityExample.Run();
            #endregion

            #region 访问者模式
            Console.WriteLine("\n===============访问者模式===============");
            VistorExample.Run();
            #endregion

            #region 备忘录模式
            Console.WriteLine("\n===============备忘录模式===============");
            MementoExample.Run();
            #endregion

            Console.ReadLine();
        }
    }
}
