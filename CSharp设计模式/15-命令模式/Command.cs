using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //命令模式（行为型）
    //定义：请求以命令的形式包裹在对象中，并传给调用对象。调用对象寻找可以处理该命令的合适的对象，并把该命令传给相应的对象，该对象执行命令。
    //角色：
    //1、抽象命令（Command）角色：定义了一个命令的接口，包含了命令的执行和撤销方法。
    //2、具体命令（ConcreteCommand）角色：具体命令类实现了抽象命令接口，包含了执行和撤销具体操作的方法。
    //3、命令调用者（Invoker）角色：命令调用者类包含了一个命令对象，并在需要的时候调用命令对象的方法。
    //4、命令接收者（Receiver）角色：命令接收者类包含了实际执行操作的方法，是具体命令类的实际操作对象。
    //使用场景：
    //1、需要将请求发送者与请求接收者解耦的情况，以便在不影响客户端的情况下更改或新增请求接收者。
    //2、需要支持撤销操作的情况，可以通过在命令对象中实现撤销操作，让客户端可以取消已执行的操作。
    //3、需要支持执行请求前进行参数化配置的情况，可以通过在命令对象中设置参数来达到这个目的。
    //4、需要将多个操作组合在一起执行的情况，可以通过将多个命令对象组合成一个复合命令对象，然后一次性执行所有命令。
    //优点：
    //1、降低系统的耦合度：命令模式将请求发送者和接收者解耦，使得对象之间的交互更加灵活。
    //2、可扩展性强：可以方便地增加新的命令和处理方法。
    //3、可以实现命令的排队和记录：命令模式可以将命令保存在队列中，从而可以实现对命令的排队和记录。
    //4、可以实现命令的撤销和恢复：命令模式可以记录命令的历史，从而可以实现命令的撤销和恢复。
    //缺点：
    //1、命令的数量会增加：如果系统中有很多的命令，那么就需要创建很多的具体命令类，从而导致系统复杂度的增加。
    //2、系统的性能有一定影响：在使用命令模式时，会在发送者和接收者之间增加一层间接层，从而会影响到系统的性能。
    //比如在 WPF 中，RoutedCommand 类就是一种基于命令模式实现的命令对象，它封装了一些常见的命令，例如 Copy、Paste、Undo 等，可以方便地处理命令的执行、撤销和重做等操作。

    //例子：开学了，院领导说计算机学院要进行军训，计算机学院的学生要跑1000米
    /*
     * 军训场景中，具体的命令即是学生跑1000米，这里学生是命令的接收者，教官是命令的请求者，院领导是命令的发出者，即客户端角色。要实现命令模式，则必须需要一个抽象命令角色来声明约定，这里以抽象类来来表示。命令的传达流程是：
       命令的发出者必须知道具体的命令、接受者和传达命令的请求者，对应于程序也就是在客户端角色中需要实例化三个角色的实例对象了。
       命令的请求者负责调用命令对象的方法来保证命令的执行，对应于程序也就是请求者对象需要有命令对象的成员，并在请求者对象的方法内执行命令。
       具体命令就是跑1000米，这自然属于学生的责任，所以是具体命令角色的成员方法，而抽象命令类定义这个命令的抽象接口。
     */

    /// <summary>
    /// 客户端调用（命令发出者）
    /// </summary>
    public static class CommandExample
    {
        public static void Run()
        {
            //Receiver receiver = new Receiver();
            //Command command = new ConcreteCommand(receiver);
            //Invoke invoke = new Invoke(command);
            ////发出命令
            //invoke.ExecuteCommand();

            var light = new Light();
            var onCommand = new LightOnCommand(light);
            var offCommand = new LightOffCommand(light);

            var invoker = new CommandInvoker(onCommand, offCommand);

            invoker.TurnOn();
            invoker.TurnOff();
            invoker.Undo();
        }
    }

    /// <summary>
    /// 教官，负责调用命令对象执行请求
    /// </summary>
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    /// <summary>
    /// 命令抽象类
    /// </summary>
    public abstract class Command
    {
        //命令应该知道接收者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            _receiver = receiver;
        }

        //命令执行方法
        public abstract void Action();
    }

    /// <summary>
    /// 具体命令
    /// </summary>
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {

        }

        public override void Action()
        {
            //调用接收的方法，因为执行命令的是学生
            _receiver.Run1000Meters();
        }
    }

    /// <summary>
    /// 命令接收者——学生
    /// </summary>
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }


    #region 示例电灯命令
    /// <summary>
    /// 电灯对象
    /// </summary>
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("打开电灯");
        }

        public void TurnOff()
        {
            Console.WriteLine("关闭电灯");
        }
    }

    /// <summary>
    /// 命令接口
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    /// <summary>
    /// 具体命令类--打开电灯
    /// </summary>
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    /// <summary>
    /// 具体命令类--关闭电灯
    /// </summary>
    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    public class CommandInvoker
    {
        private readonly ICommand _onCommand;
        private readonly ICommand _offCommand;

        public CommandInvoker(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void TurnOn()
        {
            _onCommand.Execute();
        }

        public void TurnOff()
        {
            _offCommand.Execute();
        }

        public void Undo()
        {
            _onCommand.Undo();
            _offCommand.Undo();
        }
    }
    #endregion
}
