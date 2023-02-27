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
            var zoo = new Zoo();

            var lion1 = new Lion { Name = "Simba", Weight = 150 };
            var lion2 = new Lion { Name = "Mufasa", Weight = 200 };
            var elephant1 = new Elephant { Name = "Dumbo", Weight = 500 };
            var elephant2 = new Elephant { Name = "Jumbo", Weight = 800 };

            zoo.AddAnimal(lion1);
            zoo.AddAnimal(lion2);
            zoo.AddAnimal(elephant1);
            zoo.AddAnimal(elephant2);

            WeightVisitor weightVisitor = new WeightVisitor();
            zoo.Operate(weightVisitor);
            Console.WriteLine($"Total weight: {weightVisitor.TotalWeight}");

            CountVisitor countVisitor = new CountVisitor();
            zoo.Operate(countVisitor);
            Console.WriteLine($"Lion count: {countVisitor.LionCount}");
            Console.WriteLine($"Elephant count: {countVisitor.ElephantCount}");
        }
    }

    /// <summary>
    /// 抽象元素类，定义元素所拥有的方法和属性，提供接受访问者访问的抽象方法
    /// </summary>
    public abstract class Animal
    {
        // 名称
        public string Name { get; set; }
        // 体重
        public double Weight { get; set; }

        // 接受访问者访问的抽象方法
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// 具体元素Lion，实现抽象元素所定义的接口，提供Accept方法用于接受访问者的访问
    /// </summary>
    public class Lion : Animal
    {
        public override void Accept(IVisitor visitor)
        {
            // 调用访问者的VisitLion方法
            visitor.VisitLion(this);
        }
    }

    /// <summary>
    /// 具体元素Elephant，实现抽象元素所定义的接口，提供Accept方法用于接受访问者的访问
    /// </summary>
    public class Elephant : Animal
    {
        public override void Accept(IVisitor visitor)
        {
            // 调用访问者的VisitElephant方法
            visitor.VisitElephant(this);
        }
    }

    /// <summary>
    /// 抽象访问者类，定义访问者所拥有的方法，用于对元素进行操作
    /// </summary>
    public interface IVisitor
    {
        // 访问Lion元素的方法
        void VisitLion(Lion lion);

        // 访问Elephant元素的方法
        void VisitElephant(Elephant elephant);
    }

    /// <summary>
    /// 计算体重（具体访问者类，实现IVisitor接口，对元素进行具体的操作）
    /// </summary>
    public class WeightVisitor : IVisitor
    {
        public double TotalWeight { get; private set; }

        // 访问Lion元素的方法
        public void VisitLion(Lion lion)
        {
            TotalWeight += lion.Weight;
        }

        // 访问Elephant元素的方法
        public void VisitElephant(Elephant elephant)
        {
            TotalWeight += elephant.Weight;
        }
    }

    /// <summary>
    /// 计算数量（具体访问者类，实现IVisitor接口，对元素进行具体的操作）
    /// </summary>
    public class CountVisitor : IVisitor
    {
        // 狮子数量
        public int LionCount { get; private set; }
        // 大象数量
        public int ElephantCount { get; private set; }

        // 访问Lion元素的方法
        public void VisitLion(Lion lion)
        {
            LionCount++;
        }

        // 访问Elephant元素的方法
        public void VisitElephant(Elephant elephant)
        {
            ElephantCount++;
        }
    }

    /// <summary>
    /// 对象结构类，用于存储元素，并提供对元素进行操作的方法
    /// </summary>
    public class Zoo
    {
        private List<Animal> Animals { get; } = new List<Animal>();

        // 添加动物
        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        // 移除动物
        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }

        // 对动物进行操作，接受访问者的访问
        public void Operate(IVisitor visitor)
        {
            foreach (var animal in Animals)
            {
                animal.Accept(visitor);
            }
        }
    }
}
