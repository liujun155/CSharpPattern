using System;
using System.Collections.Generic;

namespace CSharp设计模式
{
    //备忘录模式（行为型）
    //定义：允许在不破坏对象封装性的情况下捕获和恢复其内部状态。
    //该模式的核心是将对象的状态保存在一个备忘录对象中，并将该备忘录对象保存在一个管理器对象中，以便将来恢复对象的状态。
    //角色：
    //1、发起人（Originator）：负责创建备忘录对象并记录当前状态。
    //2、备忘录（Memento）：用于存储发起人的内部状态。
    //3、管理器（Caretaker）：负责保存备忘录对象，并在需要时将其返回给发起人。
    //优点：
    //1、可以方便地恢复对象的状态，因为备忘录对象保存了发起人的内部状态。
    //2、发起人对象不需要暴露其内部状态，从而保护其封装性。
    //3、备忘录模式可以与命令模式一起使用，使得可以轻松地回滚操作。
    //缺点：
    //1、如果备忘录对象保存了大量的状态数据，可能会占用过多的内存。
    //2、如果备忘录对象的状态数据是私密数据，那么在将备忘录对象传递给管理器对象时，需要确保数据的安全性。
    //使用场景：
    //1、当需要保存一个对象在某一时刻的状态，并且需要在将来的某个时候将其恢复到该状态时。
    //2、当需要实现撤销/重做操作时，备忘录模式可以与命令模式一起使用。
    //3、当发起人对象的状态需要保护封装性时，备忘录模式可以帮助实现这一点。
    //实际应用场景：
    //1、撤销和重做操作：在文本编辑器、图形编辑器等应用中，用户可以通过撤销和重做操作回到之前的状态，备忘录模式可以用来实现这种功能。
    //2、事务管理：在数据库应用中，事务管理是非常重要的功能，备忘录模式可以用来保存数据库事务的状态，以便在需要时可以回滚到之前的状态。
    //3、游戏存档：在游戏应用中，备忘录模式可以用来保存游戏状态，以便在需要时可以回到之前的状态。
    //4、状态恢复：在某些应用中，可能会遇到系统崩溃或者断电等情况导致数据丢失的情况，备忘录模式可以用来保存数据状态，以便在恢复系统时可以回到之前的状态。

    /// <summary>
    /// 客户端调用
    /// </summary>
    public static class MementoExample
    {
        public static void Run()
        {
            Console.WriteLine("单个还原点：");
            // 创建发起人对象
            Originator originator = new Originator();
            // 创建管理器对象
            Caretaker caretaker = new Caretaker();
            // 修改发起人对象的状态
            originator.SetState("State 1");
            Console.WriteLine("Current state: " + originator.GetState());
            // 保存发起人对象的状态到备忘录中
            caretaker.SaveMemento(originator.CreateMemento());
            // 修改发起人对象的状态
            originator.SetState("State 2");
            Console.WriteLine("Current state: " + originator.GetState());
            // 恢复发起人对象的状态
            originator.RestoreMemento(caretaker.GetMemento());
            Console.WriteLine("Current state: " + originator.GetState());


            Console.WriteLine("多个还原点：");
            // 创建发起人 编辑器
            Editor editor = new Editor("Hello World");
            // 创建历史记录对象
            History history = new History();
            // 编辑器进行编辑
            editor.SetText("Hello C#");
            history.Push(editor.CreateMemento());
            editor.SetText("Hello .Net");
            history.Push(editor.CreateMemento());
            editor.SetText("Hello Visual Studio");
            history.Push(editor.CreateMemento());
            // 恢复编辑器状态到之前的状态
            editor.RestoreMemento(history.Pop());
            editor.RestoreMemento(history.Pop());
            editor.RestoreMemento(history.Pop());
            // 打印历史记录
            foreach (var text in editor.GetHistory())
            {
                Console.WriteLine(text);
            }
        }
    }

    #region 单个还原点
    /// <summary>
    /// 备忘录类，用于存储发起人对象的状态
    /// </summary>
    class Memento
    {
        public string State { get; set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    /// <summary>
    /// 发起人类，负责创建备忘录对象并记录当前状态
    /// </summary>
    class Originator
    {
        private string state;

        // 创建备忘录对象，并将当前状态保存到备忘录中
        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        // 从备忘录中恢复对象状态
        public void RestoreMemento(Memento memento)
        {
            state = memento.State;
        }

        // 修改对象状态
        public void SetState(string state)
        {
            this.state = state;
        }

        // 获取对象状态
        public string GetState()
        {
            return state;
        }
    }

    /// <summary>
    /// 管理器类，负责保存备忘录对象，并在需要时将其返回给发起人
    /// </summary>
    class Caretaker
    {
        private Memento memento;

        // 保存备忘录对象
        public void SaveMemento(Memento memento)
        {
            this.memento = memento;
        }

        // 获取备忘录对象
        public Memento GetMemento()
        {
            return memento;
        }
    }
    #endregion

    #region 多个还原点
    /// <summary>
    /// 发起人，它是需要保存状态的对象
    /// </summary>
    class Editor
    {
        private string text;
        // 保存编辑器的历史状态
        private List<string> history = new List<string>();

        public Editor(string text)
        {
            this.text = text;
        }

        // 设置文本
        public void SetText(string text)
        {
            this.text = text;
        }

        // 获取文本
        public string GetText()
        {
            return this.text;
        }

        // 创建备忘录
        public EditorMemento CreateMemento()
        {
            return new EditorMemento(text);
        }

        // 恢复备忘录
        public void RestoreMemento(EditorMemento memento)
        {
            this.text = memento.GetText();
            // 将恢复后的状态加入历史记录
            history.Add(text);
        }

        // 获取历史记录
        public List<string> GetHistory()
        {
            return history;
        }
    }

    /// <summary>
    /// 备忘录，它存储发起人的内部状态
    /// </summary>
    class EditorMemento
    {
        private string text;

        public EditorMemento(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return this.text;
        }
    }

    /// <summary>
    /// 管理器类，它负责保存和恢复备忘录
    /// </summary>
    class History
    {
        private Stack<EditorMemento> mementos = new Stack<EditorMemento>();

        // 保存备忘录
        public void Push(EditorMemento memento)
        {
            mementos.Push(memento);
        }

        // 弹出备忘录
        public EditorMemento Pop()
        {
            if (mementos.Count == 1) return mementos.Peek();
            return mementos.Pop();
        }
    }
    #endregion
}

