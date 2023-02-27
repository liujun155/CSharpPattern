using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //访问者模式（行为型）
    //定义：能够在不修改被访问对象的前提下，定义作用于这些对象的新操作。
    //角色：
    //1、抽象访问者（Visitor）：定义了对每个具体元素要执行的操作。
    //2、具体访问者（ConcreteVisitor）：实现了访问者接口中定义的操作，每个操作实现了对应元素的操作。
    //3、抽象元素（Element）：定义了接受访问者的接口。
    //4、具体元素（ConcreteElement）：实现了接受访问者的接口，具体实现了对应的操作。
    //5、对象结构（Object Structure）：包含元素的容器，提供了遍历元素的方法。
    //优点：
    //1、增加新的操作很容易，由于所有的操作都在访问者中定义，因此只需要增加一个新的具体访问者就可以了。
    //2、符合单一职责原则，访问者可以根据需要分别定义具体的操作，而不是将所有的操作都放在一个类中。
    //3、访问者可以通过遍历整个对象结构，对其中的元素进行操作。
    //缺点：
    //1、增加新的元素比较困难，因为需要修改所有的具体访问者。
    //2、具体元素对访问者公开了细节，破坏了封装性。
    //使用场景：
    //1、当一个对象结构包含很多类对象，而且这些类对象的类别比较稳定，但是它们的操作却经常变化时，可以使用访问者模式，将这些变化封装到访问者中。
    //2、当需要对一个对象结构中的对象进行很多不同的且不相关的操作时，可以使用访问者模式，将这些操作分离到不同的访问者中。
    //3、当一个对象需要访问一个对象结构中的对象，而且要根据对象的具体类型进行不同的操作时，可以使用访问者模式，将这些操作封装到访问者中。

    //示例：对不同种类的动物进行不同的操作，如计算它们的体重、统计它们的数量等。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class VistorExample
    {
        public static void Run()
        {

        }
    }

    /// <summary>
    /// 抽象元素
    /// </summary>
    public abstract class Animal
    {
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// 具体元素Lion
    /// </summary>
    public class Lion : Animal
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLion(this);
        }
    }

    /// <summary>
    /// 具体元素Elephant
    /// </summary>
    public class Elephant : Animal
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElephant(this);
        }
    }

    /// <summary>
    /// 抽象访问者
    /// </summary>
    public interface IVisitor
    {
        void VisitLion(Lion lion);
        void VisitElephant(Elephant elephant);
    }

    /// <summary>
    /// 计算体重（具体访问者）
    /// </summary>
    public class WeightVisitor : IVisitor
    {
        public void VisitLion(Lion lion)
        {
            throw new NotImplementedException();
        }

        public void VisitElephant(Elephant elephant)
        {
            throw new NotImplementedException();
        }
    }
}
