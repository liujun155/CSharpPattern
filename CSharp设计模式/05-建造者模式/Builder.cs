using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //建造者模式（创建型）
    //定义：将一个复杂对象分解成多个相对简单的部分，然后根据不同需要分别创建它们，最后构建成该复杂对象
    //优点：1.建造者独立，易扩展。 2.便于控制细节风险。
    //缺点：1.产品必须有共同点，范围有限制。 2.如内部变化复杂，会有很多的建造类。
    //使用场景
    //1.需要生成的对象具有复杂的内部结构
    //2.需要生成的对象内部属性本身相互依赖

    /// <summary>
    /// 指挥创建过程类
    /// </summary>
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    /// <summary>
    /// 电脑类
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
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小王
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
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小李
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
