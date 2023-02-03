using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //简单工厂模式（创建型）
    //简单工厂模式是由一个工厂对象决定创建出哪一种产品类的实例
    //使用场景
    //1.工厂类负责创建的对象比较少；
    //2.客户只知道传入工厂类的参数，对于如何创建对象（逻辑）不关心；
    //3.由于简单工厂很容易违反高内聚责任分配原则，因此一般只在很简单的情况下应用。
    //缺点：①由于工厂类集中了所有实例的创建逻辑，违反了高内聚责任分配原则，将全部创建逻辑集中到了一个工厂类中；它所能创建的类只能是事先考虑到的，如果需要添加新的类，则就需要改变工厂类了；②当系统中的具体产品类不断增多时候，可能会出现要求工厂类根据不同条件创建不同实例的需求．这种对条件的判断和对具体产品类型的判断交错在一起，很难避免模块功能的蔓延，对系统的维护和扩展非常不利

    /// <summary>
    /// 菜 抽象类
    /// </summary>
    public abstract class Food
    {
        public abstract void Print();
    }

    /// <summary>
    /// 西红柿炒蛋菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份西红柿炒蛋！");
        }
    }

    /// <summary>
    /// 土豆肉丝菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("一份土豆肉丝！");
        }
    }

    /// <summary>
    /// 简单工厂类，负责炒菜
    /// </summary>
    public class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type == "西红柿炒蛋")
            {
                food = new TomatoScrambledEggs();
            }
            else if (type == "土豆肉丝")
            {
                food = new ShreddedPorkWithPotatoes();
            }
            return food;
        }
    }
}
