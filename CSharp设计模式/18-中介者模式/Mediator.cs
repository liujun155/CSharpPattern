using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //中介者模式（行为型）
    //定义：用一个中介对象来封装一系列的对象交互，中介者使各对象不需要显式地相互引用，从而使其耦合松散，而且可以独立地改变它们之间的交互。
    //角色：
    //1、抽象中介者（Mediator）：定义中介者对象的接口，它封装了对象之间的通信和协作逻辑。
    //2、具体中介者（ConcreteMediator）：实现抽象中介者接口，负责协调各个对象之间的通信和协作，从而实现各个对象之间的解耦。
    //3、抽象同事类（Colleague）：定义同事对象的接口，它封装了同事对象之间的通信和协作逻辑。
    //4、具体同事类（ConcreteColleague）：实现抽象同事类接口，它是各个同事对象的具体实现，负责与其他同事对象通信和协作。在需要与其他同事对象进行通信时，会向中介者对象发送请求。
    //使用场景：
    //1、系统中对象之间的交互复杂且难以维护时，可以使用中介者模式来简化交互逻辑，提高系统的可维护性和可扩展性。
    //2、系统中对象之间的通信需要经过多个对象时，可以使用中介者模式来集中管理通信，从而提高系统的性能和可维护性。
    //3、系统中有多个对象需要协同工作，但是彼此之间不能直接引用时，可以使用中介者模式来实现对象之间的协作。
    //优点：
    //1、减少了对象之间的耦合性，使得它们可以独立地变化和复用。
    //2、通过将通信和协作集中在一个中介者对象中，简化了对象之间的交互逻辑，使得系统更易于维护和扩展。
    //3、可以将复杂的系统拆分成多个简单的模块，每个模块都由一个中介者对象负责协调，从而提高了系统的可维护性和可扩展性。
    //缺点：
    //1、中介者对象可能会变得非常复杂，尤其是在大型系统中。这可能会使得维护和修改中介者对象变得困难。
    //2、中介者模式可能会导致系统的性能下降，因为所有的通信都必须通过中介者对象进行转发，可能会增加系统的延迟和负载。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class MediatorExample
    {
        public static void Run()
        {
            ConcreteMediator mediator = new ConcreteMediator(); // 创建中介者对象
            ConcreteColleagueA colleagueA = new ConcreteColleagueA(mediator); // 创建同事对象A
            ConcreteColleagueB colleagueB = new ConcreteColleagueB(mediator); // 创建同事
            mediator.RegisterColleagueA(colleagueA); // 注册同事对象A
            mediator.RegisterColleagueB(colleagueB); // 注册同事对象B

            colleagueA.Send("Hello, colleague B!"); // 同事对象A发送消息给同事对象B
            colleagueB.Send("Hi, colleague A!"); // 同事对象B发送消息给同事对象A
        }
    }

    /// <summary>
    /// 抽象中介者
    /// </summary>
    public abstract class Mediator
    {
        // 定义中介者对象的接口，它封装了对象之间的通信和协作逻辑
        public abstract void Send(string message, Colleague colleague);
    }

    /// <summary>
    /// 具体中介者
    /// </summary>
    public class ConcreteMediator : Mediator
    {
        private ConcreteColleagueA colleagueA; // 同事对象A
        private ConcreteColleagueB colleagueB; // 同事对象B

        // 注册同事对象A
        public void RegisterColleagueA(ConcreteColleagueA colleagueA)
        {
            this.colleagueA = colleagueA;
        }

        // 注册同事对象B
        public void RegisterColleagueB(ConcreteColleagueB colleagueB)
        {
            this.colleagueB = colleagueB;
        }

        // 实现抽象中介者接口，负责协调各个对象之间的通信和协作
        public override void Send(string message, Colleague colleague)
        {
            if(colleague == colleagueA) // 如果是同事对象A发送的消息
            {
                colleagueB.Notify(message);  // 通知同事对象B 
            }
            else if(colleague == colleagueB) // 如果是同事对象B发送的消息
            {
                colleagueA.Notify(message); // 通知同事对象A
            }
        }
    }

    /// <summary>
    /// 抽象同事类
    /// </summary>
    public abstract class Colleague
    {
        protected Mediator mediator; // 中介者对象

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        // 定义同事对象的接口，封装了同事对象之间的通信和协作逻辑
        public abstract void Notify(string message);
    }

    /// <summary>
    /// 具体同事A
    /// </summary>
    public class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(Mediator mediator) : base(mediator)
        {
        }

        public override void Notify(string message)
        {
            Console.WriteLine("同事A已收到消息：" + message);
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }
    }

    /// <summary>
    /// 具体同事B
    /// </summary>
    public class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(Mediator mediator) : base(mediator)
        {
        }

        // 实现抽象同事类接口，负责与其他同事对象通信和协作
        public override void Notify(string message)
        {
            Console.WriteLine("同事B已收到消息: " + message);
        }

        // 发送消息给中介者对象
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
    }
}
