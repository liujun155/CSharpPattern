using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //迭代器模式（行为型）
    //定义：提供一种方法顺序访问一个聚合对象中各个元素, 而又无须暴露该对象的内部表示。
    //迭代器模式将集合对象和遍历算法进行了分离，使得集合对象和遍历算法可以独立地变化而互不影响。
    //角色：
    //1、抽象迭代器（Iterator）角色：定义访问和遍历聚合对象元素的接口，通常包含 hasNext()、next()、remove() 等方法。
    //2、具体迭代器（Concrete Iterator）角色：实现抽象迭代器角色定义的接口，完成对聚合对象元素的遍历。
    //3、抽象聚合（Aggregate）角色：定义创建迭代器对象的接口，通常包含 createIterator() 等方法。
    //4、具体聚合（Concrete Aggregate）角色：实现抽象聚合角色定义的接口，创建对应的具体迭代器对象。
    //使用场景：
    //1、需要遍历一个复杂的集合对象，而又不想暴露其内部结构的情况。
    //2、需要支持多种遍历方式的情况。
    //3、需要逐步访问集合对象元素的情况。
    //优点：
    //1、简化了集合对象的接口：迭代器模式将遍历集合对象的方法封装在迭代器对象中，可以隐藏集合对象的内部实现细节，简化了集合对象的接口，同时也使得集合对象的实现更加灵活。
    //2、支持多种遍历方式：迭代器模式支持不同的遍历方式，如顺序遍历、逆序遍历等，可以根据实际需要灵活选择。
    //3、提供了一种通用的访问方式：迭代器模式提供了一种通用的访问集合对象元素的方式，无需关心集合对象内部的实现细节，从而使得代码更加简洁、可读性更高。
    //4、支持逐步访问集合对象：迭代器模式支持逐步访问集合对象的元素，可以逐个访问，也可以跳过某些元素，从而更加灵活地处理集合对象中的元素。
    //缺点：
    //1、由于迭代器模式需要额外定义迭代器类，因此会增加代码量和工作量。
    //2、迭代器模式对于一些简单的集合对象来说，使用迭代器模式可能会过于复杂，不如直接使用集合对象的内部遍历方法。

    //可以继承IEnumerable接口快捷实现迭代器

    /// <summary>
    /// 客户端调用
    /// </summary>
    public abstract class IteratorExample
    {
        public static void Run()
        {
            ConcreteAggregate aggregate = new ConcreteAggregate(3);
            aggregate[0] = "Hellow";
            aggregate[1] = "World";
            aggregate[2] = "Iterator";

            Iterator iterator = aggregate.GetIterator();
            while(iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }

    /// <summary>
    /// 抽象迭代器
    /// </summary>
    public interface Iterator
    {
        bool HasNext();
        object Next();
    }

    /// <summary>
    /// 具体迭代器
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        // 具体集合
        ConcreteAggregate aggregate;
        // 索引
        int index = 0;

        public ConcreteIterator(ConcreteAggregate concreteAggregate)
        {
            this.aggregate = concreteAggregate;
        }

        // 判断集合是否还有下一条
        public bool HasNext()
        {
            return index < aggregate.Length;
        }

        // 下一条
        public object Next()
        {
            if(HasNext())
                return aggregate[index++];
            else
                return null;
        }
    }

    /// <summary>
    /// 抽象聚合类
    /// </summary>
    public interface Aggregate
    {
        Iterator GetIterator();
    }

    /// <summary>
    /// 具体聚合类
    /// </summary>
    public class ConcreteAggregate : Aggregate
    {
        private object[] items;

        public ConcreteAggregate(int size)
        {
            items = new object[size];
        }

        public int Length
        {
            get { return items.Length; }
        }

        // 索引器
        public object this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        // 获取迭代器
        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }
    }


    #region 使用IEnumerable快速实现

    #endregion
}
