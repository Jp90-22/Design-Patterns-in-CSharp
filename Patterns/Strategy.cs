using System;

namespace Design_Patterns.Patterns
{
    // The Context defines the interface of interest to clients.
    public class Context
    {
        // Usually, the Context accepts a strategy through the constructor or be instanciated in the same place,
        // but also provides a setter to change it at runtime.
        private static Strategy strategy = new ConcreteDefaultStrategy();

        // Usually, the Context allows replacing a Strategy object at runtime.
        public static void SetConcreteStrategy1()
        {
            strategy = new ConcreteStrategy1();
        }

        public static void SetConcreteStrategy2()
        {
            strategy = new ConcreteStrategy2();
        }

        public static void DoSomething()
        {
            strategy.DoSomethingInMyWay();
        }
    }

    // The Strategy interface or abstract class declares operations common to all supported
    // versions of some algorithm.
    //
    // The Context uses this interface to call the algorithm defined by Concrete
    // Strategies.
    public abstract class Strategy
    {
        public Strategy()
        {
            Console.WriteLine("-> An strategy was created");
        }

        public abstract void DoSomethingInMyWay();

        public static void Implementation()
        {
            Program.WriteLineWithColor("Strategy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Strategy is a behavioral design pattern that lets you " +
                "define a family of algorithms, put each of them into a separate " +
                "class, and make their objects interchangeable.\r\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Imagine that you have to get to the airport. You can catch a bus, order a cab, " +
                "or get on your bicycle. These are your transportation strategies. You can pick one of the strategies depending on factors such as budget or time constraints.\r\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string StrategyPsCode = "// The strategy interface declares operations common to all\r\n" +
            "// supported versions of some algorithm. The context uses this\r\n" +
            "// interface to call the algorithm defined by the concrete\r\n" +
            "// strategies.\r\n" +
            "interface Strategy is\r\n" +
            "    method execute(a, b)\r\n" +
            "// Concrete strategies implement the algorithm while following\r\n" +
            "// the base strategy interface. The interface makes them\r\n" +
            "// interchangeable in the context.\r\n" +
            "class ConcreteStrategyAdd implements Strategy is\r\n" +
            "    method execute(a, b) is\r\n" +
            "        return a + b\r\n" +
            "class ConcreteStrategySubtract implements Strategy is\r\n" +
            "    method execute(a, b) is\r\n" +
            "        return a - b\r\n" +
            "class ConcreteStrategyMultiply implements Strategy is\r\n" +
            "    method execute(a, b) is\r\n" +
            "        return a * b\r\n" +
            "// The context defines the interface of interest to clients.\r\n" +
            "class Context is\r\n" +
            "    // The context maintains a reference to one of the strategy\r\n" +
            "    // objects. The context doesn't know the concrete class of a\r\n" +
            "    // strategy. It should work with all strategies via the\r\n" +
            "    // strategy interface.\r\n" +
            "    private strategy: Strategy\r\n" +
            "    // Usually the context accepts a strategy through the\r\n" +
            "    // constructor, and also provides a setter so that the\r\n" +
            "    // strategy can be switched at runtime.\r\n" +
            "    method setStrategy(Strategy strategy) is\r\n" +
            "        this.strategy = strategy\r\n" +
            "    // The context delegates some work to the strategy object\r\n" +
            "    // instead of implementing multiple versions of the\r\n" +
            "    // algorithm on its own.\r\n" +
            "    method executeStrategy(int a, int b) is\r\n" +
            "        return strategy.execute(a, b)\r\n" +
            "// The client code picks a concrete strategy and passes it to\r\n" +
            "// the context. The client should be aware of the differences\r\n" +
            "// between strategies in order to make the right choice.\r\n" +
            "class ExampleApplication is\r\n" +
            "    method main() is\r\n" +
            "        Create context object.\r\n" +
            "        Read first number.\r\n" +
            "        Read last number.\r\n" +
            "        Read the desired action from user input.\r\n" +
            "        if (action == addition) then\r\n" +
            "            context.setStrategy(new ConcreteStrategyAdd())\r\n" +
            "        if (action == subtraction) then\r\n" +
            "            context.setStrategy(new ConcreteStrategySubtract())\r\n" +
            "        if (action == multiplication) then\r\n" +
            "            context.setStrategy(new ConcreteStrategyMultiply())\r\n" +
            "        result = context.executeStrategy(First number, Second number)\r\n" +
            "        Print result.\r\n";

            Program.WriteLineWithColor(StrategyPsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);
            Context.DoSomething();
            Context.SetConcreteStrategy1();
            Context.DoSomething();
            Context.SetConcreteStrategy2();
            Context.DoSomething();

            Console.WriteLine();
        }
    }

    // Concrete Strategies implement the algorithm while following the base
    // Strategy interface. The interface makes them interchangeable in the
    // Context.
    public class ConcreteDefaultStrategy : Strategy
    {
        public ConcreteDefaultStrategy() : base() { }

        public override void DoSomethingInMyWay()
        {
            Console.WriteLine(nameof(ConcreteDefaultStrategy) + " is doing the same thing, but in the default way...");
        }
    }

    public class ConcreteStrategy1 : Strategy
    {
        public ConcreteStrategy1() : base() { }

        public override void DoSomethingInMyWay()
        {
            Console.WriteLine(nameof(ConcreteStrategy1) + " is doing the same thing, but in Its way...");
        }
    }

    public class ConcreteStrategy2 : Strategy
    {
        public ConcreteStrategy2() : base() { }

        public override void DoSomethingInMyWay()
        {
            Console.WriteLine(nameof(ConcreteStrategy2) + " is doing the same thing, but in Its way...");
        }
    }
}