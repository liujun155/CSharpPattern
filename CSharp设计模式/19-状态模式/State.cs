using System;
namespace CSharp设计模式
{
    //状态者模式（行为型）
    //定义：允许对象在其内部状态发生改变时，改变其行为。
    //在状态模式中，一个对象的行为取决于它的状态，并且它可以在运行时改变其状态，从而改变其行为。
    //角色：
    //1、Context（环境类）：它是定义客户端所需的接口，并且维护一个当前状态对象的引用。它会将状态的处理委托给当前状态对象来处理。
    //2、State（抽象状态类）：它是状态对象的抽象基类，它定义了一个接口，用于处理与上下文相关的行为，并且可以根据需要将自身与上下文对象进行关联。
    //3、ConcreteState（具体状态类）：它是抽象状态类的具体实现，它实现了处理与上下文相关的行为的方法，并且根据需要可以修改上下文对象的状态。
    //优点：
    //1、通过将状态封装成独立的状态对象，将状态转换规则与对象行为进行了解耦，使得状态转换可以独立于对象而变化，从而使得对象的设计更加灵活。
    //2、将状态对象之间的转换规则封装在具体状态类中，使得状态转换规则更加容易扩展和维护，且减少了代码冗余。
    //3、将对象的状态封装在状态对象中，使得对象状态变化更加明确和清晰，易于理解和维护。
    //4、在状态模式中，通常通过增加新的状态类来扩展对象的状态，而不是修改现有的状态类，从而符合开闭原则。
    //缺点：
    //1、当状态对象数量较多时，将会增加系统的复杂度，且可能导致状态转换规则的复杂化和混乱。
    //2、状态模式要求定义许多状态类和状态转换规则，可能会增加系统的开销和内存消耗。
    //使用场景
    //1、对象的行为取决于它的状态，且在运行时可以动态地改变其状态，从而改变其行为。
    //2、对象的状态转换规则比较复杂，且需要在运行时进行动态管理和修改。
    //3、对象的状态变化较少，但其行为随状态变化而变化的情况，可以通过状态模式来封装状态和行为的关联。
    //4、当需要避免使用过多的 if-else 或 switch 语句来处理对象状态转换时，可以考虑使用状态模式。

    //例子：假设有一个文本编辑器，它有三种状态：只读、编辑和选中。当文本编辑器处于不同的状态时，它的行为也应该不同。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class StateExample
    {
        public static void Run()
        {
            // 创建文本编辑器对象
            TextEditor editor = new TextEditor();

            // 设置只读状态
            editor.SetState(new ReadOnlyState());
            editor.Edit();
            editor.Select();

            // 设置编辑状态
            editor.SetState(new EditState());
            editor.Edit();
            editor.Select();

            // 设置选中状态
            editor.SetState(new SelectedState());
            editor.Edit();
            editor.Select();
        }
    }

    /// <summary>
    /// 定义状态接口，包含状态的共同行为
    /// </summary>
    public interface IState
    {
        void Handle();
    }

    // 只读状态
    public class ReadOnlyState : IState
    {
        public void Handle()
        {
            Console.WriteLine("当前处于只读状态，无法进行编辑和选中操作。");
        }
    }

    // 编辑状态
    public class EditState : IState
    {
        public void Handle()
        {
            Console.WriteLine("当前处于编辑状态，可以进行编辑操作，但无法进行选中操作。");
        }
    }

    // 选中状态
    public class SelectedState : IState
    {
        public void Handle()
        {
            Console.WriteLine("当前处于选中状态，可以进行选中和编辑操作。");
        }
    }

    /// <summary>
    /// 定义文本编辑器类
    /// </summary>
    public class TextEditor
    {
        // 当前状态
        private IState state;

        // 设置状态
        public void SetState(IState state)
        {
            this.state = state;
        }

        // 编辑操作
        public void Edit()
        {
            this.state.Handle();
        }

        // 选中操作
        public void Select()
        {
            this.state.Handle();
        }
    }
}

