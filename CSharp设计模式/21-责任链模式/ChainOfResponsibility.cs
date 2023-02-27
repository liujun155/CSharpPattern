using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //责任链模式（行为型）
    //定义：允许多个对象都有机会处理请求，从而避免了请求的发送者和接收者之间的耦合关系。
    //该模式将处理请求的对象组成一个链，并将请求沿着链传递，直到有一个对象处理它为止。
    //例如生活中的审批。
    //角色：
    //1、Handler（抽象处理者）：定义处理请求的接口，并持有下一个处理者的引用。
    //2、ConcreteHandler（具体处理者）：实现处理请求的接口，可以处理它所负责的请求，或将请求传递给下一个处理者。
    //优点：
    //1、可以动态地添加或删除处理者，灵活性高。
    //2、可以避免请求的发送者和接收者之间的耦合关系。
    //3、可以对请求的处理顺序进行灵活的控制。
    //4、可以避免使用过多的条件语句。
    //缺点：
    //1、处理者之间的关系可能会变得复杂，增加了系统的复杂度。
    //2、请求可能会被所有处理者都处理一遍，影响系统性能。
    //使用场景：
    //1、当需要避免请求的发送者和接收者之间的耦合关系时，可以使用责任链模式。
    //2、当需要动态地添加或删除处理者时，可以使用责任链模式。
    //3、当有多个对象可以处理同一请求，但处理的顺序不确定时，可以使用责任链模式。
    //4、当需要避免使用过多的条件语句时，可以使用责任链模式。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class ChainOfResponsibilityExample
    {
        public static void Run()
        {
            // 创建处理者对象
            Handler handler1 = new ConcreteHandlerA();
            Handler handler2 = new ConcreteHandlerB();
            Handler handler3 = new ConcreteHandlerC();

            // 设置处理者之间的关系
            handler1.SetNextHandler(handler2);
            handler2.SetNextHandler(handler3);

            // 处理请求
            handler1.HandleRequest(5);
            handler1.HandleRequest(15);
            handler1.HandleRequest(25);
            handler1.HandleRequest(35);
        }
    }

    /// <summary>
    /// 抽象处理者
    /// </summary>
    public abstract class Handler
    {
        // 下一个处理者
        protected Handler NextHandler;

        // 设置下一个处理者
        public void SetNextHandler(Handler handler)
        {
            this.NextHandler = handler;
        }

        // 处理请求的抽象方法
        public abstract void HandleRequest(int request);
    }

    /// <summary>
    /// 具体处理者A
    /// </summary>
    public class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10) // 在A的处理范围内
            {
                Console.WriteLine("{0} 处理了请求 {1}", this.GetType().Name, request);
            }
            else if(NextHandler != null) // 不在A的处理范围内，交给下一个处理者处理
            {
                NextHandler.HandleRequest(request);
            }
            else  // 所有处理者都无法处理该请求
            {
                Console.WriteLine("无法处理该请求");
            }
        }
    }

    /// <summary>
    /// 具体处理者B
    /// </summary>
    public class ConcreteHandlerB : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20) // 在B的处理范围内
            {
                Console.WriteLine("{0} 处理了请求 {1}", this.GetType().Name, request);
            }
            else if (NextHandler != null) // 不在B的处理范围内，交给下一个处理者处理
            {
                NextHandler.HandleRequest(request);
            }
            else  // 所有处理者都无法处理该请求
            {
                Console.WriteLine("无法处理该请求");
            }
        }
    }

    /// <summary>
    /// 具体处理者C
    /// </summary>
    public class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30) // 在C的处理范围内
            {
                Console.WriteLine("{0} 处理了请求 {1}", this.GetType().Name, request);
            }
            else if (NextHandler != null) // 不在C的处理范围内，交给下一个处理者处理
            {
                NextHandler.HandleRequest(request);
            }
            else  // 所有处理者都无法处理该请求
            {
                Console.WriteLine("无法处理该请求");
            }
        }
    }
}
