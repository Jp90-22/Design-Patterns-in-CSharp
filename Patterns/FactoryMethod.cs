using System;

namespace Design_Patterns.Patterns
{
    public class FactoryMethod
    {
        public static void Implementation()
        {
            Program.WriteLineWithColor("Factory Method:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Factory Method is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter " +
                "the type of objects that will be created.\r\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string FactoryMethodPsCode = "// The creator class declares the factory method that must\r\n" +
            "// return an object of a product class. The creator's subclasses\r\n" +
            "// usually provide the implementation of this method.\r\n" +
            "class Dialog is\r\n" +
            "    // The creator may also provide some default implementation\r\n" +
            "    // of the factory method.\r\n" +
            "    abstract method createButton():Button\r\n" +
            "    // Note that, despite its name, the creator's primary\r\n" +
            "    // responsibility isn't creating products. It usually\r\n" +
            "    // contains some core business logic that relies on product\r\n" +
            "    // objects returned by the factory method. Subclasses can\r\n" +
            "    // indirectly change that business logic by overriding the\r\n" +
            "    // factory method and returning a different type of product\r\n" +
            "    // from it.\r\n" +
            "    method render() is\r\n" +
            "        // Call the factory method to create a product object.\r\n" +
            "        Button okButton = createButton()\r\n" +
            "        // Now use the product.\r\n" +
            "        okButton.onClick(closeDialog)\r\n" +
            "        okButton.render()\r\n" +
            "// Concrete creators override the factory method to change the\r\n" +
            "// resulting product's type.\r\n" +
            "class WindowsDialog extends Dialog is\r\n" +
            "    method createButton():Button is\r\n" +
            "        return new WindowsButton()\r\n" +
            "class WebDialog extends Dialog is\r\n" +
            "    method createButton():Button is\r\n" +
            "        return new HTMLButton()\r\n" +
            "// The product interface declares the operations that all\r\n" +
            "// concrete products must implement.\r\n" +
            "interface Button is\r\n" +
            "    method render()\r\n" +
            "    method onClick(f)\r\n" +
            "// Concrete products provide various implementations of the\r\n" +
            "// product interface.\r\n" +
            "class WindowsButton implements Button is\r\n" +
            "    method render(a, b) is\r\n" +
            "        // Render a button in Windows style.\r\n" +
            "    method onClick(f) is\r\n" +
            "        // Bind a native OS click event.\r\n" +
            "class HTMLButton implements Button is\r\n" +
            "    method render(a, b) is\r\n" +
            "        // Return an HTML representation of a button.\r\n" +
            "    method onClick(f) is\r\n" +
            "        // Bind a web browser click event.\r\n" +
            "class Application is\r\n" +
            "    field dialog: Dialog\r\n" +
            "    // The application picks a creator's type depending on the\r\n" +
            "    // current configuration or environment settings.\r\n" +
            "    method initialize() is\r\n" +
            "        config = readApplicationConfigFile()\r\n" +
            "        if (config.OS == \"Windows\") then\r\n" +
            "            dialog = new WindowsDialog()\r\n" +
            "        else if (config.OS == \"Web\") then\r\n" +
            "            dialog = new WebDialog()\r\n" +
            "        else\r\n" +
            "            throw new Exception(\"Error! Unknown operating system.\")\r\n" +
            "    // The client code works with an instance of a concrete\r\n" +
            "    // creator, albeit through its base interface. As long as\r\n" +
            "    // the client keeps working with the creator via the base\r\n" +
            "    // interface, you can pass it any creator's subclass.\r\n" +
            "    method main() is\r\n" +
            "        this.initialize()\r\n" +
            "        dialog.render()\r\n";

            Program.WriteLineWithColor(FactoryMethodPsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);
            AbstractClass factoryClass = InstaceCreator.CreateInstace(0);
            factoryClass.DoSomething();
            factoryClass = InstaceCreator.CreateInstace(1);

            Console.WriteLine();
        }
    }

    // This abstract class declares the operations that all concrete classes
    // must implement.
    public abstract class AbstractClass
    {
        public abstract void DoSomething();
    }

    // Concrete Creators override the factory method in order to change the
    // resulting product's type.
    public class HingeratedClass1 : AbstractClass
    {
        public HingeratedClass1()
        {
            Console.WriteLine("-> Instace created from the Instace creator");
        }

        public override void DoSomething()
        {
            Console.WriteLine("Doing something... from: " + nameof(HingeratedClass1));
        }
    }

    public class HingeratedClass2 : AbstractClass
    {
        public HingeratedClass2()
        {
            Console.WriteLine("-> Instace created from the Instace creator");
        }

        public override void DoSomething()
        {
            Console.WriteLine("Doing something... from: " + nameof(HingeratedClass2));
        }
    }

    // The Instace creator class declares the factory method that is supposed to return
    // an object of a Product class. The Creator's subclasses usually provide
    // the implementation of this method.
    public static class InstaceCreator
    {
        const int HINGERATED_CLASS1 = 0;
        const int HINGERATED_CLASS2 = 1;

        public static AbstractClass CreateInstace(int instaceId)
        {
            switch (instaceId)
            {
                case HINGERATED_CLASS1: return new HingeratedClass1();
                case HINGERATED_CLASS2: return new HingeratedClass2();
                default: return null;
            }
        }
    }
}