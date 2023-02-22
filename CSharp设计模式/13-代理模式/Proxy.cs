using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //代理模式（结构型）
    //定义：允许通过一个代理对象来控制对另一个对象的访问
    //在代理模式中，代理对象拥有和被代理对象相同的接口，因此可以直接代替被代理对象。
    //例如电脑桌面的快捷方式就是一个代理对象，快捷方式是它所引用的程序的一个代理。
    //优点：
    //1、代理模式能够将调用用于真正被调用的对象隔离，在一定程度上降低了系统的耦合度；
    //2、代理对象在客户端和目标对象之间起到一个中介的作用，这样可以起到对目标对象的保护。代理对象可以在对目标对象发出请求之前进行一个额外的操作，例如权限检查等。
    //缺点：
    //1、由于在客户端和真实主题之间增加了一个代理对象，所以会造成请求的处理速度变慢
    //2、实现代理类也需要额外的工作，从而增加了系统的实现复杂度。
    //使用场景
    //远程代理：当对象位于另一个地址空间时，可以使用代理对象在本地访问该对象。最典型的例子就是——客户端调用Web服务或WCF服务。
    //虚拟代理：当创建一个对象的代价比较大时，可以使用代理对象来延迟对象的实例化，只有在真正需要访问该对象时才进行实例化。
    //安全代理：当需要控制对对象的访问权限时，可以使用代理对象来限制对对象的访问。
    //智能代理：当需要为对象提供额外的功能时，可以使用代理对象来包装该对象，以实现这些额外的功能。比如将对此对象调用的次数记录下来等。

    //示例：在现实生活中，如果有同事出国或者朋友出国的情况下，我们经常会拖这位朋友帮忙带一些电子产品或化妆品等东西。
    //这个场景中，出国的朋友就是一个代理，他（她）是他（她）朋友的一个代理，由于他朋友不能去国外买东西，他却可以，所以朋友们都托他帮忙带一些东西的。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class ProxyExample
    {
        public static void Run()
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.BuyProduct();
        }
    }

    /// <summary>
    /// 抽象主题角色
    /// </summary>
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    /// <summary>
    /// 真实主题角色
    /// </summary>
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个IPhone和一台苹果电脑");
        }
    }

    /// <summary>
    /// 代理角色
    /// </summary>
    public class Friend : Person
    {
        //引用真实主题实例
        RealBuyPerson realSubject;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实实体对象的方法");
            if(realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }
            this.PreBuyProduct();
            // 调用真实主题方法
            realSubject.BuyProduct();
            this.PostBuyProduct();
        }

        // 代理角色执行的一些操作
        public void PreBuyProduct()
        {
            // 可能不知一个朋友叫这位朋友带东西，首先这位出国的朋友要对每一位朋友要带的东西列一个清单等
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }

        // 买完东西之后，代理角色需要针对每位朋友需要的对买来的东西进行分类
        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}
