using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //策略者模式（行为型）
    //定义：一个类的行为或其算法可以在运行时更改。
    //该模式将一组算法封装在独立的策略类中，使得它们可以相互替换，而不会影响到客户端代码。这使得算法的选择可以根据客户端需求或者运行时环境的变化而动态地进行。
    //角色：
    //1、Context（上下文）：持有一个策略类的引用，并调用其算法进行处理。
    //2、Strategy（抽象策略）：定义一组算法接口，并封装了具体的算法实现。
    //3、ConcreteStrategy（具体策略）：实现策略接口，提供具体的算法实现。
    //优点：
    //1、可以在运行时动态地选择算法，而不需要修改客户端代码。
    //2、可以将算法实现从客户端代码中分离出来，提高代码的复用性和可维护性。
    //3、可以避免使用大量的条件语句，使得代码更加清晰。
    //缺点：
    //1、增加了类的数量，可能会增加系统的复杂度。
    //2、客户端需要了解所有可用的策略类，才能选择合适的策略。
    //使用场景：
    //1、当需要根据不同的条件选择不同的算法时，可以使用策略者模式。
    //2、当需要在运行时动态地切换算法时，可以使用策略者模式。
    //3、当有多个类具有相似的行为，可以将它们抽象成一个策略接口，然后针对不同的类实现具体的策略类。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class StragetyExample
    {
        public static void Run()
        {
            // 创建三个具体的策略实现类
            ConcreteStrategyA strategyA = new ConcreteStrategyA();
            ConcreteStrategyB strategyB = new ConcreteStrategyB();
            ConcreteStrategyC strategyC = new ConcreteStrategyC();

            // 使用具体的策略实现类创建三个上下文对象
            Context contextA = new Context(strategyA);
            Context contextB = new Context(strategyB);
            Context contextC = new Context(strategyC);

            // 调用上下文对象的 Calculate 方法进行计算，并输出结果
            int resultA = contextA.Calculate(10, 5);
            Console.WriteLine("Result A: " + resultA);

            int resultB = contextB.Calculate(10, 5);
            Console.WriteLine("Result B: " + resultB);

            int resultC = contextC.Calculate(10, 5);
            Console.WriteLine("Result C: " + resultC);
        }
    }

    /// <summary>
    /// 策略接口，定义了所有算法的通用接口
    /// </summary>
    public interface IStrategy
    {
        int Calculate(int a, int b);
    }

    /// <summary>
    /// 策略实现类A，实现了算法A的具体实现
    /// </summary>
    public class ConcreteStrategyA : IStrategy
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// 策略实现类B，实现了算法B的具体实现
    /// </summary>
    public class ConcreteStrategyB : IStrategy
    {
        public int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    /// <summary>
    /// 策略实现类C，实现了算法C的具体实现
    /// </summary>
    public class ConcreteStrategyC : IStrategy
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }

    /// <summary>
    /// 上下文类，使用策略接口进行算法的调用
    /// </summary>
    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // 调用策略接口的 Calculate 方法进行计算
        public int Calculate(int a, int b)
        {
            return _strategy.Calculate(a, b);
        }
    }
}
