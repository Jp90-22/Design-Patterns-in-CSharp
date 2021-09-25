using System;
using Design_Patterns.Patterns;
using System.Collections.Generic;

namespace Design_Patterns
{
    class Program
    {
        // Font colors
        public const ConsoleColor TITLE_COLOR = ConsoleColor.Red;
        public const ConsoleColor PSCODE_COLOR = ConsoleColor.Cyan;

        static void Main(string[] args)
        {
            // First set up console.
            SetUpConsole();

            // Singleton implementation
            ShowSingleton();

            // Prototype implementation
            ShowPrototype();

            // Factory method implementation
            ShowFactoryMethod();

            // Mediator implementation
            ShowMediator();

            // State implementation
            ShowState();

            // Strategy implementation
            ShowStrategy();

            // Composite implementation
            ShowComposite();
        }

        static void SetUpConsole()
        {
            Console.Clear();
            Console.Title = "Design Patterns in C#";
            Console.ResetColor();
            Console.Beep();
        }

        public static void WriteWithColor(string txt, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(txt);
            Console.ResetColor();
        }

        public static void WriteLineWithColor(string txt, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(txt);
            Console.ResetColor();
        }

        // Show methods
        static void ShowSingleton() =>
            Singleton.Implementation();

        static void ShowPrototype() =>
            PrototypeDeep.Implementation();

        static void ShowFactoryMethod() =>
            FactoryMethod.Implementation();

        static void ShowComposite() =>
            Composite.Implementation();

        static void ShowMediator() =>
            Mediator.Implementation();

        static void ShowState() =>
            State.Implementation();

        static void ShowStrategy() =>
            Strategy.Implementation();
    }
}
