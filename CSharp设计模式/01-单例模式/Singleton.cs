using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //单例模式（创建型）
    //定义：确保一个类只有一个实例,并提供一个访问它的全局访问点

    /// <summary>
    /// 单例模式的实现（适合单线程）
    /// </summary>
    public class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueSingleton;

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton()
        {
        }

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
    }

    /// <summary>
    /// 单例模式的实现（适合多线程）
    /// </summary>
    public class Singleton2
    {
        private static Singleton2 uniqueSingleton;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        private Singleton2()
        {

        }

        public static Singleton2 GetSingletone()
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
                        uniqueSingleton = new Singleton2();
                }
            }
            return uniqueSingleton;
        }
    }
}
