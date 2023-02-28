using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //建造者模式（创建型）
    //定义：将一个复杂对象的构建过程与其表示分离开来，使得同样的构建过程可以创建不同的表示。
    //主要解决在软件系统中，有时候面临着"一个复杂对象"的创建工作，其通常由各个部分的子对象用一定的算法构成；由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定
    //角色：
    //1、抽象建造者（Builder）：定义了创建产品各个部件的抽象方法和规范，通常包括创建产品的接口、装配产品的方法和返回产品的方法。
    //2、具体建造者（Concrete Builder）：实现了抽象建造者中定义的创建产品的方法和规范，通常包括设置产品属性、组装产品等方法。
    //3、产品（Product）：具体的产品对象，由多个部件组成，具有一些属性和特征。
    //4、指挥者（Director）：负责指导建造者如何构建产品，通常包括一个构建方法，该方法接收一个建造者对象作为参数，并通过建造者对象完成产品的构建过程。
    //优点：
    //1、将复杂对象的创建过程拆分为多个小的对象构建过程，每个小的对象构建过程只负责创建该部分对象的属性和特征，最终通过组合来创建一个完整的对象。
    //2、可以改变产品的内部表示结构，从而使得同样的构建过程可以创建不同的表示形式。
    //3、可以更好地控制产品的创建过程，使得系统更加灵活。
    //4、可以在产品构建过程中增加新的构建步骤或更改构建顺序，而不会对客户端产生影响。
    //缺点：
    //1、建造者模式会增加系统的复杂度和代码量，因为需要创建多个具体建造者类和产品类。
    //2、在构建产品过程中，如果某些组件的创建顺序很重要，就需要客户端来控制，这可能会导致客户端代码的复杂度增加。
    //使用场景
    //1、当需要创建一个复杂对象时，可以使用建造者模式将对象构建过程分解为多个步骤，并让不同的建造者实现每个步骤，从而简化对象的创建过程。
    //2、当需要创建多个具有相似属性但是不同的对象时，可以使用建造者模式来避免重复的代码。
    //3、当需要更加灵活地控制对象的创建过程时，可以使用建造者模式来实现。

    public static class BuilderExample
    {
        public static void Run()
        {
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
        }
    }

    /// <summary>
    /// 指挥创建过程类
    /// </summary>
    public class Director
    {
        // 组装电脑
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    /// <summary>
    /// 电脑类（具体产品类）
    /// </summary>
    public class Computer
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑开始组装......");
            foreach (var part in parts)
            {
                Console.WriteLine($"组件{part}已装好");
            }
            Console.WriteLine("电脑组装好了");
        }
    }

    /// <summary>
    /// 抽象建造者，这个场景下为 "组装人" ，这里也可以定义为接口
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 装CPU
        /// </summary>
        public abstract void BuildPartCPU();
        /// <summary>
        /// 装主板
        /// </summary>
        public abstract void BuildPartMainBoard();

        /// <summary>
        /// 获得组装好的电脑
        /// </summary>
        /// <returns></returns>
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 具体建造者，具体的某个人为具体创建者，例如：装机小王
    /// </summary>
    public class ConcreteBuilder1 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("MainBoard1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 具体建造者，具体的某个人为具体创建者，例如：装机小李
    /// </summary>
    public class ConcreteBuilder2 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("MainBoard2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }
}
