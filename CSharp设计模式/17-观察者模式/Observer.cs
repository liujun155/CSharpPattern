using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //观察者模式（行为型）
    //定义：定义了一种一对多的关系，让多个观察者对象同时监听某一个主题对象，当这个主题对象的状态发生变化时，会通知所有的观察者对象，使它们能够自动更新自己的状态。
    //角色：
    //1、抽象主题（Subject）：提供一个接口，用于添加、删除和通知观察者对象。
    //2、具体主题（ConcreteSubject）：继承抽象主题，实现添加、删除和通知观察者的方法。具体主题通常包含观察者列表，用于维护所有观察者对象。
    //3、抽象观察者（Observer）：定义一个更新接口，使得具体观察者对象能够接收到主题状态的改变。
    //4、具体观察者（ConcreteObserver）：实现抽象观察者定义的更新接口，以便在接收到主题状态改变时更新自身状态。
    //使用场景：
    //1、当一个对象的改变需要同时改变其他对象的时候，可以考虑使用观察者模式
    //2、当系统中某些对象之间的关系较为复杂，不希望通过直接调用方式进行通信时，可以考虑使用观察者模式
    //3、当系统需要将一个对象的改变通知其他多个对象时，可以考虑使用观察者模式
    //优点：
    //1、降低了主题对象和观察者对象之间的耦合性，主题对象和观察者对象之间只是简单的依赖关系，符合“高内聚、低耦合”的设计原则
    //2、主题对象和观察者对象之间可以动态的建立关系，使得系统更加灵活
    //3、观察者模式符合“开闭原则”，在不修改主题对象和观察者对象的情况下，可以增加新的观察者对象和主题对象
    //缺点
    //1、如果观察者对象较多或者观察者对象之间存在复杂的依赖关系，容易引起混乱，增加维护难度
    //2、如果观察者对象的更新操作比较复杂，会影响到主题对象的性能

    //委托是否属于观察者模式？
    //可以说委托包含了观察者模式的思想，但并不是完整的观察者模式。委托可以实现订阅者（观察者）向发布者（主题）订阅事件的功能，当事件触发时，发布者会调用所有订阅者注册的委托函数。这与观察者模式中的订阅者接收主题状态变化的通知并进行相应处理的过程是类似的。但是，观察者模式还包括了抽象主题、具体主题、抽象观察者、具体观察者等角色，而委托并不涉及这些角色。因此，可以说委托包含了部分观察者模式的思想，但并不是完整的观察者模式。

    public static class ObserverExample
    {
        public static void Run()
        {
            ConcreteSubject subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver("A", subject));
            subject.Attach(new ConcreteObserver("B", subject));
            subject.Attach(new ConcreteObserver("C", subject));

            subject.State = "Ready";
            subject.Notify();
        }
    }

    /// <summary>
    /// 抽象主题
    /// </summary>
    public abstract class Subject
    {
        // 观察者列表
        private List<Observer> observers = new List<Observer>();

        // 添加观察者
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        // 移除观察者
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        // 通知观察者
        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }

    /// <summary>
    /// 具体主题
    /// </summary>
    public class ConcreteSubject : Subject
    {
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

    }

    /// <summary>
    /// 抽象观察者
    /// </summary>
    public abstract class Observer
    {
        // 更新方法
        public abstract void Update();
    }

    /// <summary>
    /// 具体观察者
    /// </summary>
    public class ConcreteObserver : Observer
    {
        private string name;
        private ConcreteSubject subject;

        public ConcreteObserver(string name, ConcreteSubject subject)
        {
            this.name = name;
            this.subject = subject;
        }

        public override void Update()
        {
            Console.WriteLine("Observer {0}'s new state is {1}", name, subject.State);
        }
    }
}
