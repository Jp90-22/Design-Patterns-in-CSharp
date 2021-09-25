using System;
using System.Collections.Generic;

namespace Design_Patterns.Patterns
{
    // The base Component class declares common operations for both simple and
    // complex objects of a composition.
    abstract class Component
    {
        public Component() { }

        // The base Component may implement some default behavior or leave it to
        // concrete classes (by declaring the method containing the behavior as
        // "abstract").
        public abstract string Operation();

        // In some cases, it would be beneficial to define the child-management
        // operations right in the base Component class. This way, you won't
        // need to expose any concrete component classes to the client code,
        // even during the object tree assembly. The downside is that these
        // methods will be empty for the leaf-level components.
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        // You can provide a method that lets the client code figure out whether
        // a component can bear children.
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    // The Leaf class represents the end objects of a composition. A leaf can't
    // have any children.
    //
    // Usually, it's the Leaf objects that do the actual work, whereas Composite
    // objects only delegate to their sub-components.
    class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    // The Composite class represents the complex components that may have
    // children. Usually, the Composite objects delegate the actual work to
    // their children and then "sum-up" the result.
    class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        // The Composite executes its primary logic in a particular way. It
        // traverses recursively through all its children, collecting and
        // summing their results. Since the composite's children pass these
        // calls to their children and so forth, the whole object tree is
        // traversed as a result.
        public override string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (Component component in this._children)
            {
                result += component.Operation() + i;
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }

        public static void Implementation()
        {
            Program.WriteLineWithColor("Composite:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Composite is a structural design pattern that lets you compose objects into tree " +
                "structures and then work with these structures as if they were individual objects.\r\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Armies of most countries are structured as hierarchies. An army consists of several divisions; " +
                "a division is a set of brigades, and a brigade consists of platoons, which can be broken down " +
                "into squads. Finally, a squad is a small group of real soldiers. Orders are given at the top of " +
                "the hierarchy and passed down onto each level until every soldier knows what needs to be done.\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string CompositePsCode = "// The component interface declares common operations for both\r\n" +
            "// simple and complex objects of a composition.\r\n" +
            "interface Graphic is\r\n" +
            "    method move(x, y)\r\n" +
            "    method draw()\r\n" +
            "// The leaf class represents end objects of a composition. A\r\n" +
            "// leaf object can't have any sub-objects. Usually, it's leaf\r\n" +
            "// objects that do the actual work, while composite objects only\r\n" +
            "// delegate to their sub-components.\r\n" +
            "class Dot implements Graphic is\r\n" +
            "    field x, y\r\n" +
            "    constructor Dot(x, y) { ... }\r\n" +
            "    method move(x, y) is\r\n" +
            "        this.x += x, this.y += y\r\n" +
            "    method draw() is\r\n" +
            "        // Draw a dot at X and Y.\r\n" +
            "// All component classes can extend other components.\r\n" +
            "class Circle extends Dot is\r\n" +
            "    field radius\r\n" +
            "    constructor Circle(x, y, radius) { ... }\r\n" +
            "    method draw() is\r\n" +
            "        // Draw a circle at X and Y with radius R.\r\n" +
            "// The composite class represents complex components that may\r\n" +
            "// have children. Composite objects usually delegate the actual\r\n" +
            "// work to their children and then \"sum up\" the result.\r\n" +
            "class CompoundGraphic implements Graphic is\r\n" +
            "    field children: array of Graphic\r\n" +
            "    // A composite object can add or remove other components\r\n" +
            "    // (both simple or complex) to or from its child list.\r\n" +
            "    method add(child: Graphic) is\r\n" +
            "        // Add a child to the array of children.\r\n" +
            "    method remove(child: Graphic) is\r\n" +
            "        // Remove a child from the array of children.\r\n" +
            "    method move(x, y) is\r\n" +
            "        foreach (child in children) do\r\n" +
            "            child.move(x, y)\r\n" +
            "    // A composite executes its primary logic in a particular\r\n" +
            "    // way. It traverses recursively through all its children,\r\n" +
            "    // collecting and summing up their results. Since the\r\n" +
            "    // composite's children pass these calls to their own\r\n" +
            "    // children and so forth, the whole object tree is traversed\r\n" +
            "    // as a result.\r\n" +
            "    method draw() is\r\n" +
            "        // 1. For each child component:\r\n" +
            "        //     - Draw the component.\r\n" +
            "        //     - Update the bounding rectangle.\r\n" +
            "        // 2. Draw a dashed rectangle using the bounding\r\n" +
            "        // coordinates.\r\n" +
            "// The client code works with all the components via their base\r\n" +
            "// interface. This way the client code can support simple leaf\r\n" +
            "// components as well as complex composites.\r\n" +
            "class ImageEditor is\r\n" +
            "    field all: CompoundGraphic\r\n" +
            "    method load() is\r\n" +
            "        all = new CompoundGraphic()\r\n" +
            "        all.add(new Dot(1, 2))\r\n" +
            "        all.add(new Circle(5, 3, 10))\r\n" +
            "        // ...\r\n" +
            "    // Combine selected components into one complex composite\r\n" +
            "    // component.\r\n" +
            "    method groupSelected(components: array of Graphic) is\r\n" +
            "        group = new CompoundGraphic()\r\n" +
            "        foreach (component in components) do\r\n" +
            "            group.add(component)\r\n" +
            "            all.remove(component)\r\n" +
            "        all.add(group)\r\n" +
            "        // All components will be drawn.\r\n" +
            "        all.draw()\r\n";

            Program.WriteLineWithColor(CompositePsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);

            Composite tree = new Composite();
            Composite branch1 = new Composite();
            Composite branch2 = new Composite();
            List<Component> trees = new List<Component>()
            { tree, new Leaf(), new Leaf(), branch1, new Leaf(), branch2 };

            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());

            branch2.Add(new Leaf());
            branch2.Add(new Leaf());
            branch2.Add(new Leaf());

            tree.Add(branch1);
            tree.Add(branch2);

            foreach (var treeOrbranch in trees)
            {
                Console.WriteLine("Entering on a: " + (treeOrbranch.IsComposite() ? "Composite" : "Leaf"));
                Console.WriteLine(treeOrbranch.Operation());
            }

            Console.WriteLine();
        }
    }
}