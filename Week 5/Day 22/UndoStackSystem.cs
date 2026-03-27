using System;

class UndoStackSystem
{
    static string[] stack = new string[100];
    static int top = -1;

    static void Push(string action)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        stack[++top] = action;
        Display();
    }

    static void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Nothing to undo");
            return;
        }
        top--;
        Display();
    }

    static void Display()
    {
        Console.Write("Current State: ");
        if (top == -1)
        {
            Console.WriteLine("Empty");
            return;
        }

        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Push("Type A");
        Push("Type B");
        Push("Type C");
        Pop();
        Pop();
    }
}
