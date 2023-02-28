using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //原型模式（创建型）
    //定义：使用原型实例指定创建对象的种类，并通过克隆这些原型来创建新的对象。
    //角色：
    //1、原型接口(Prototype Interface) : 声明克隆方法，该方法将用于克隆现有的对象。通常情况下，该接口只包含一个克隆方法。
    //2、具体原型类(Concrete Prototype) : 实现原型接口，提供一个方法来克隆自身。
    //3、客户端(Client) : 使用原型接口来克隆现有的对象并创建新的对象。
    //优点：
    //1、减少了创建对象的开销：使用原型模式可以通过克隆现有对象来创建新对象，而无需重新创建新对象，从而减少了创建对象的开销。
    //2、更加灵活：使用原型模式，可以在运行时动态地添加或删除对象。
    //3、简化了对象的创建：原型模式可以帮助我们避免复杂的构造函数，简化了对象的创建过程。
    //缺点：
    //1、需要为每个类都实现克隆方法：对于每个需要克隆的类，都需要实现一个克隆方法，这可能会导致代码的冗余。
    //2、克隆方法的实现可能比较复杂：对于某些对象，克隆方法可能比较复杂，这可能会导致性能问题。
    //使用场景：
    //1、创建对象的过程比较复杂，且新对象的创建成本较高时，可以使用原型模式。
    //2、需要避免使用构造函数来创建对象时，可以使用原型模式。
    //3、需要动态地创建对象，并且需要能够在运行时添加或删除对象时，可以使用原型模式。
    //4、需要生成与当前对象完全相同的副本时，可以使用原型模式。

    public static class PrototypeExample
    {
        public static void Run()
        {
            // 孙悟空原型
            MonkeyKingPrototype monkeyKingPrototype = new ConcretePrototype("MonkeyKing");
            // 克隆一个
            MonkeyKingPrototype cloneMonkeyKing1 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing1.Id}");
            // 克隆两个
            MonkeyKingPrototype cloneMonkeyKing2 = monkeyKingPrototype.Clone() as ConcretePrototype;
            Console.WriteLine($"Cloned: {cloneMonkeyKing2.Id}");
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }

        public MonkeyKingPrototype(string id)
        {
            Id = id;
        }

        // 克隆方法
        public abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id) : base(id)
        { }

        /// <summary>
        /// 浅拷贝（执行浅拷贝创建的新对象与原来对象共享成员，改变一个对象，另外一个对象的成员也会改变）
        /// </summary>
        /// <returns></returns>
        public override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }
}
