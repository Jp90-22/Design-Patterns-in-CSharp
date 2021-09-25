using System;

namespace Design_Patterns.Patterns
{
    // Deep form of Prototype or Conation
    public class PrototypeDeep : ICloneable
    {
        public int ID { get; set; }
        public string Attr1 { get; set; }
        public string Attr2 { get; set; }
        public ObjectClass1 Class1 { get; set; }
        public ObjectClass2 Class2 { get; set; }

        public PrototypeDeep(int iD, string attr1, string attr2, ObjectClass1 class1, ObjectClass2 class2)
        {
            ID = iD;
            Attr1 = attr1;
            Attr2 = attr2;
            Class1 = class1;
            Class2 = class2;

            Console.WriteLine(
                $"-> Instace created at: {nameof(PrototypeDeep)} constructor\n" +
                $"\tWith attributes: Id: {iD}, {Attr1}, {Attr2}"
            );
        }

        public object Clone()
        {
            var objCloned = this.MemberwiseClone() as PrototypeDeep;
            objCloned.Class1 = new ObjectClass1(objCloned.Class1.ID, objCloned.Class1.Attr1, objCloned.Class1.Attr2);
            objCloned.Class2 = new ObjectClass2(objCloned.Class2.ID, objCloned.Class2.Attr1, objCloned.Class2.Attr2);

            return objCloned;
        }

        public class ObjectClass1
        {
            public int ID { get; set; }
            public string Attr1 { get; set; }
            public string Attr2 { get; set; }

            public ObjectClass1(int iD, string attr1, string attr2)
            {
                ID = iD;
                Attr1 = attr1;
                Attr2 = attr2;

                Console.WriteLine(
                    $"-> Instace created at: {nameof(ObjectClass1)} constructor\n" +
                    $"\tWith attributes: Id: {iD}, {Attr1}, {Attr2}"
                );
            }
        }

        public class ObjectClass2
        {
            public int ID { get; set; }
            public string Attr1 { get; set; }
            public string Attr2 { get; set; }

            public ObjectClass2(int iD, string attr1, string attr2)
            {
                ID = iD;
                Attr1 = attr1;
                Attr2 = attr2;

                Console.WriteLine(
                    $"-> Instace created at: {nameof(ObjectClass1)} constructor\n" +
                    $"\tWith attributes: Id: {iD}, {Attr1}, {Attr2}"
                );
            }
        }

        public static void Implementation()
        {
            Program.WriteLineWithColor("Prototype:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Prototype (also known as Clone) is a creational design pattern that lets you copy existing objects without" +
                "making your code dependent on their classes.\r\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "In real life, prototypes are used for performing various tests before starting mass production of a product. However, in this case, prototypes don’t participate in any actual production, playing a passive role instead.\r\n" +
                "Since industrial prototypes don’t really copy themselves, a much closer analogy to the pattern is the process of mitotic cell division (biology, remember?). After mitotic division, a pair of identical cells is formed. The original cell acts as a prototype and takes an active role in creating the copy.\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string PrototypePsCode = "// Base prototype.\r\n" +
            "abstract class Shape is\r\n" +
            "    field X: int\r\n" +
            "    field Y: int\r\n" +
            "    field color: string\r\n" +
            "    // A regular constructor.\r\n" +
            "    constructor Shape() is\r\n" +
            "        // ...\r\n" +
            "    // The prototype constructor. A fresh object is initialized\r\n" +
            "    // with values from the existing object.\r\n" +
            "    constructor Shape(source: Shape) is\r\n" +
            "        this()\r\n" +
            "        this.X = source.X\r\n" +
            "        this.Y = source.Y\r\n" +
            "        this.color = source.color\r\n" +
            "    // The clone operation returns one of the Shape subclasses.\r\n" +
            "    abstract method clone():Shape\r\n" +
            "// Concrete prototype. The cloning method creates a new object\r\n" +
            "// and passes it to the constructor. Until the constructor is\r\n" +
            "// finished, it has a reference to a fresh clone. Therefore,\r\n" +
            "// nobody has access to a partly-built clone. This keeps the\r\n" +
            "// cloning result consistent.\r\n" +
            "class Rectangle extends Shape is\r\n" +
            "    field width: int\r\n" +
            "    field height: int\r\n" +
            "    constructor Rectangle(source: Rectangle) is\r\n" +
            "        // A parent constructor call is needed to copy private\r\n" +
            "        // fields defined in the parent class.\r\n" +
            "        super(source)\r\n" +
            "        this.width = source.width\r\n" +
            "        this.height = source.height\r\n" +
            "    method clone():Shape is\r\n" +
            "        return new Rectangle(this)\r\n" +
            "class Circle extends Shape is\r\n" +
            "    field radius: int\r\n" +
            "    constructor Circle(source: Circle) is\r\n" +
            "        super(source)\r\n" +
            "        this.radius = source.radius\r\n" +
            "    method clone():Shape is\r\n" +
            "        return new Circle(this)\r\n" +
            "// Somewhere in the client code.\r\n" +
            "class Application is\r\n" +
            "    field shapes: array of Shape\r\n" +
            "    constructor Application() is\r\n" +
            "        Circle circle = new Circle()\r\n" +
            "        circle.X = 10\r\n" +
            "        circle.Y = 10\r\n" +
            "        circle.radius = 20\r\n" +
            "        shapes.add(circle)\r\n" +
            "        Circle anotherCircle = circle.clone()\r\n" +
            "        shapes.add(anotherCircle)\r\n" +
            "        // The `anotherCircle` variable contains an exact copy\r\n" +
            "        // of the `circle` object.\r\n" +
            "        Rectangle rectangle = new Rectangle()\r\n" +
            "        rectangle.width = 10\r\n" +
            "        rectangle.height = 20\r\n" +
            "        shapes.add(rectangle)\r\n" +
            "    method businessLogic() is\r\n" +
            "        // Prototype rocks because it lets you produce a copy of\r\n" +
            "        // an object without knowing anything about its type.\r\n" +
            "        Array shapesCopy = new Array of Shapes.\r\n" +
            "        // For instance, we don't know the exact elements in the\r\n" +
            "        // shapes array. All we know is that they are all\r\n" +
            "        // shapes. But thanks to polymorphism, when we call the\r\n" +
            "        // `clone` method on a shape the program checks its real\r\n" +
            "        // class and runs the appropriate clone method defined\r\n" +
            "        // in that class. That's why we get proper clones\r\n" +
            "        // instead of a set of simple Shape objects.\r\n" +
            "        foreach (s in shapes) do\r\n" +
            "            shapesCopy.add(s.clone())\r\n" +
            "        // The `shapesCopy` array contains exact copies of the\r\n" +
            "        // `shape` array's children.\r\n";

            Program.WriteLineWithColor(PrototypePsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);
            Console.WriteLine("Shallow copy =>");
            PrototypeShallow prototype = new PrototypeShallow(1, "Is new", "It's gonna be copied");
            PrototypeShallow shallowCopy = prototype.Clone() as PrototypeShallow;
            Console.WriteLine($"Coping {nameof(prototype)} into {nameof(shallowCopy)}...");
            Console.WriteLine($"{((prototype == shallowCopy) ? "Copied" : "Copied but are different")}");

            Console.WriteLine("Deep copy =>");
            PrototypeDeep prototypeDeep =
                new PrototypeDeep(
                    1, "Is new", "It's gonna be copied",
                    new PrototypeDeep.ObjectClass1(1, "Its a child class", "Its new in this world"),
                    new PrototypeDeep.ObjectClass2(2, "Its a child class", "Its new in this world too")
                );
            PrototypeDeep deepCopy = prototypeDeep.Clone() as PrototypeDeep;
            Console.WriteLine($"Coping {nameof(prototypeDeep)} into {nameof(deepCopy)}...");
            Console.WriteLine($"{((prototypeDeep == deepCopy) ? "Copied it and copied its objects" : "Copied but it and its objects are different")}");

            Console.WriteLine();
        }
    }
}