﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp设计模式
{
    //原型模式（创建型）
    //定义：用于创建重复的对象，同时又能保证性能
    //优点： 1、性能提高。 2、逃避构造函数的约束。
    //缺点： 1、配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。 2、必须实现 ICloneable 接口
    //使用场景
    //1、资源优化场景
    //2、类初始化需要消化非常多的资源，这个资源包括数据、硬件资源等
    //3、性能和安全要求的场景
    //4、通过 new 产生一个对象需要非常繁琐的数据准备或访问权限，则可以使用原型模式
    //5、一个对象多个修改者的场景
    //6、一个对象需要提供给其他对象访问，而且各个调用者可能都需要修改其值时，可以考虑使用原型模式拷贝多个对象供调用者使用
    //7、在实际项目中，原型模式很少单独出现，一般是和工厂方法模式一起出现，通过 clone 的方法创建一个对象，然后由工厂方法提供给调用者

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
