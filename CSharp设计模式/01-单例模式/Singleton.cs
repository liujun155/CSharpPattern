using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //单例模式（创建型）
    //定义：确保一个类只有一个实例，并提供一个访问它的全局访问点。
    //角色：
    //1、单例类：负责创建和管理单例实例。
    //2、客户端：使用单例实例的代码。
    //优点：
    //1、提供了对唯一实例的严格访问控制，避免了多个实例之间的竞争和冲突。
    //2、减少了内存开销和系统资源的浪费，因为只有一个实例。
    //3、提供了一个全局访问点，方便了代码的编写和维护。
    //缺点：
    //1、单例模式可能会破坏单一职责原则，因为单例类既负责创建实例，又负责管理实例。
    //2、单例模式可能会引起单点故障问题，如果单例实例出现问题，整个应用程序将受到影响。
    //3、单例模式可能会导致代码的可测试性和可扩展性降低，因为代码可能会对单例实例进行直接引用。
    //使用场景：
    //1、当一个类的实例化需要消耗大量资源时，例如文件系统或数据库连接等，可以使用单例模式来避免资源的浪费。
    //2、当多个对象需要共享某些数据时，可以使用单例模式来保证数据的一致性。
    //3、当需要在整个系统中提供一个唯一的访问点来访问某个对象时，可以使用单例模式来实现全局访问点。
    //4、当需要控制一个类的实例只能创建一次时，可以使用单例模式。
    //实际应用场景：
    //1、数据库连接池：在一个应用程序中，需要多次连接同一个数据库，但是每次连接都需要消耗大量资源，包括内存和CPU等。使用单例模式可以实现数据库连接池，确保只有一个数据库连接实例，并且可以被多个线程共享，避免了多个线程之间的资源竞争和冲突。
    //2、配置管理器：在一个应用程序中，需要读取和管理多个配置文件，包括应用程序配置文件、用户配置文件等。使用单例模式可以实现配置管理器，确保只有一个配置管理器实例，并且可以被多个模块和组件共享，避免了多个模块之间的配置冲突和混乱。
    //3、日志管理器：在一个应用程序中，需要记录和管理多个日志文件，包括系统日志、应用程序日志、错误日志等。使用单例模式可以实现日志管理器，确保只有一个日志管理器实例，并且可以被多个模块和组件共享，避免了多个模块之间的日志记录冲突和混乱。
    //4、缓存管理器：在一个应用程序中，需要缓存和管理多个数据对象，包括图片、文本、文件等。使用单例模式可以实现缓存管理器，确保只有一个缓存管理器实例，并且可以被多个模块和组件共享，避免了多个模块之间的缓存竞争和冲突。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class SingletonExample
    {
        public static void Run()
        {
            Console.WriteLine("单线程单例：");
            // 获取唯一的实例
            Singleton instance1 = Singleton.GetSingleton();
            // 调用单例类的功能
            instance1.DoSomething();
            // 再次获取唯一的实例
            Singleton instance2 = Singleton.GetSingleton();
            // 判断两个实例是否相同
            if (instance1 == instance2)
            {
                Console.WriteLine("两个实例是相同的");
            }


            Console.WriteLine("多线程单例：");
            // 创建两个线程，同时获取唯一的实例
            Thread t1 = new Thread(GetInstance);
            Thread t2 = new Thread(GetInstance);
            // 启动两个线程
            t1.Start();
            t2.Start();
            // 等待两个线程结束
            t1.Join();
            t2.Join();
            Console.WriteLine("在不同的线程中获取的实例哈希值是相同的，说明单例模式中只有一个实例，确保了线程安全。");
        }

        static void GetInstance()
        {
            // 获取唯一的实例
            MultiThreadSingleton instance = MultiThreadSingleton.GetSingletone();
            // 输出当前线程和实例的哈希值
            Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}, Instance HashCode: {instance.GetHashCode()}");
        }
    }

    /// <summary>
    /// 单例类（适合单线程）
    /// </summary>
    public class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueSingleton;

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton() { }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetSingleton()
        {
            if (uniqueSingleton == null)
                uniqueSingleton = new Singleton();
            return uniqueSingleton;
        }

        public void DoSomething()
        {
            // ...TODO
        }
    }

    /// <summary>
    /// 单例类（适合多线程）
    /// </summary>
    public class MultiThreadSingleton
    {
        private static MultiThreadSingleton uniqueSingleton;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        private MultiThreadSingleton() { }

        public static MultiThreadSingleton GetSingletone()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueSingleton == null)
            {
                lock (locker)
                {
                    if (uniqueSingleton == null)
                        uniqueSingleton = new MultiThreadSingleton();
                }
            }
            return uniqueSingleton;
        }
    }
}
