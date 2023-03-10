# C#设计模式

### 设计模式六大原则
1.**单一职责原则（Single Responsibility Principle，SRP）**：一个类只负责单一的职责，避免出现功能耦合和代码臃肿的问题。<br/>
2.**开放封闭原则（Open-Closed Principle，OCP）**：对扩展开放，对修改关闭。即，应该通过扩展而不是修改来增加代码的功能。<br/>
3.**里氏替换原则（Liskov Substitution Principle，LSP）**：子类可以替换其父类并保持程序的正确性。即，父类出现的地方，子类也应该可以出现。<br/>
4.**接口隔离原则（Interface Segregation Principle，ISP）**：应该根据需要将接口拆分成较小和更具体的接口。这样，客户端只需要知道他们感兴趣的方法即可，而无需了解整个接口。<br/>
5.**依赖倒置原则（Dependency Inversion Principle，DIP）**：高层模块不应该依赖于低层模块。两者都应该依赖于抽象。抽象不应该依赖于具体实现，具体实现应该依赖于抽象。<br/>
6.**迪米特法则（Law of Demeter，LoD）**：也称为最少知识原则（Least Knowledge Principle，LKP），即一个对象应该对其他对象保持最少的了解。不应该了解太多其他类的内部信息，只与那些与它有直接关系的类进行通信。

### 创建型：
     1. 单例模式(Singleton Pattern) ：确保一个类只有一个实例，并提供一个访问它的全局访问点。
     2. 简单工厂模式（Simple Factory Pattern）：通过一个工厂类，根据不同的输入参数来创建不同的产品对象。
     3. 工厂方法模式（Factory Method) ：提供一个接口，让子类决定实例化哪个类。
     4. 抽象工厂（Abstract Factory） ：提供了一种将相关或相互依赖对象创建的接口，而无需指定它们具体的类。
     5. 建造者模式(Builder) ：将一个复杂对象的构建过程与其表示分离开来，使得同样的构建过程可以创建不同的表示。
     6. 原型模式(Prototype) ：使用原型实例指定创建对象的种类，并通过克隆这些原型来创建新的对象。
### 结构型：
     7. 适配器模式（Adapter Pattern) ：将一个类的接口转换成客户端所期望的另一个接口，从而使得原本由于接口不兼容而无法一起工作的类能够协同工作。
     8. 桥接模式（Bridge Pattern) ：将抽象部分与它的实现部分分离，从而使它们都可以独立地变化。
     9. 装饰者模式(Decorator Pattern) ：动态地给一个对象添加一些额外的职责，而不需要修改它的代码。
    10. 组合模式(Composite Pattern) ：将对象组合成树形结构，以表示“部分-整体”的层次结构。
    11. 外观模式（Facade Pattern) ：为子系统中的一组接口提供一个统一的接口，从而简化了子系统的使用。
    12. 享元模式(Flyweight Pattern) ：运用共享技术来有效地支持大量细粒度对象的复用。
    13. 代理模式(Proxy Pattern) ：为其他对象提供一种代理以控制对这个对象的访问。
### 行为型：
    14. 模板方法模式(Template Method) ：定义了一个操作中的算法框架，而将一些步骤延迟到子类中，从而使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。
    15. 命令模式(Command Pattern) ：将一个请求封装成一个对象，从而使得可以用不同的请求对客户进行参数化，同时支持请求的排队和记录日志等功能。
    16. 迭代器模式(Iterator Pattern) ：提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示。
    17. 观察者模式(Observer Pattern） ：定义了一种一对多的依赖关系，当一个对象的状态发生改变时，所有依赖它的对象都将得到通知并自动更新。
    18. 中介者模式(Mediator Pattern) ：用一个中介对象来封装一系列的对象交互，从而使各对象不需要显示它们的相互依赖。
    19. 状态模式(State Pattern) ：允许对象在其内部状态发生改变时改变它的行为，看起来就像改变了它的类。
    20. 策略模式(Strategy Pattern) ：定义了一系列算法，并将每个算法封装起来，从而使它们可以互换。
    21. 责任链模式(Chain of Responsibility Pattern) ：将请求的发送者和接收者解耦，从而使多个对象都有机会处理这个请求。
    22. 访问者模式(Visitor Pattern) ：表示一个作用于某对象结构中的各个元素的操作，它使你可以在不改变各元素类的前提下定义作用于这些元素的新操作。
    23. 备忘录模式(Memento Pattern) ：在不破坏封装的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态，从而可以在以后将对象恢复到原先保存的状态。
