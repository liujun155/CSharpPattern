using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //模板方法模式（行为型）
    //定义：定义了一个操作中的算法骨架，而将一些步骤延迟到子类中实现。
    //模板方法模式使得子类可以在不改变算法结构的情况下，重新定义算法中的某些步骤。
    //实现思路：把相同的部分抽象出来到抽象类中去定义，具体子类来实现具体的不同部分。
    //优点： 1、封装不变部分，扩展可变部分。 2、提取公共代码，便于维护。 3、行为由父类控制，子类实现。
    //缺点：每一个不同的实现都需要一个子类来实现，导致类的个数增加，使得系统更加庞大。
    //使用场景： 1、有多个子类共有的方法，且逻辑相同。 2、重要的、复杂的方法，可以考虑作为模板方法。
    //模板方法模式实际是基于继承的一种实现代码复用的技术

    //示例：在现实生活中，做蔬菜的步骤都大致相同，如果我们针对每种蔬菜类定义一个烧的方法，这样在每个类中都有很多相同的代码

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class TemplateMethodExample
    {
        public static void Run()
        {
            Vegetabel spinach = new Spinach();
            spinach.CookVegetabel();
            Vegetabel chineseCabbage = new ChineseCabbage();
            chineseCabbage.CookVegetabel();
        }
    }

    /// <summary>
    /// 抽象蔬菜类
    /// </summary>
    public abstract class Vegetabel
    {
        // 模板方法，不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }

        // 第一步倒油
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }

        // 把油烧热
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }

        // 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetable();

        // 开发翻炒蔬菜
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }

    // 菠菜
    public class Spinach : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    // 大白菜
    public class ChineseCabbage : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}
