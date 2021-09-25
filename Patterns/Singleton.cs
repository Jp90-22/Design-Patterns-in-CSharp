using System;

namespace Design_Patterns.Patterns
{
    /**
    * The Singleton class defines the `GetInstance` method or an instace getter
    * that serves as an alternative to constructor and lets clients
    * access the same instance of this class over and over.
    * Any singleton could define some static business logic,
    * which can be executed on its instance.
    */
    public class Singleton
    {
        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton _Instace;

        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton()
        {
            Console.WriteLine($"-> Called from {nameof(Singleton)}: instace created.");
        }

        // This is the static instance getter that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Singleton Instace
        {
            get
            {
                if (_Instace is null) _Instace = new Singleton();

                Console.WriteLine("-> Using instance...");
                return _Instace;
            }
        }

        public static void Implementation()
        {
            Program.WriteLineWithColor("Singleton:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Singleton is a creational design pattern that lets you ensure that a class" +
                "has only one instance, while providing a global access point to this instance.\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "The government is an excellent example of the Singleton pattern. " +
                "A country can have only one official government. Regardless of the " +
                "personal identities of the individuals who form governments, the title, " +
                "“The Government of X”, is a global point of access that identifies " +
                "the group of people in charge.\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string SingletonPsCode = "// The Database class defines the `getInstance` method that lets\r\n" +
            "// clients access the same instance of a database connection\r\n" +
            "// throughout the program.\r\n" +
            "class Database is\r\n" +
            "    // The field for storing the singleton instance should be\r\n" +
            "    // declared static.\r\n" +
            "    private static field instance: Database\r\n" +
            "    // The singleton's constructor should always be private to\r\n" +
            "    // prevent direct construction calls with the `new`\r\n" +
            "    // operator.\r\n" +
            "    private constructor Database() is\r\n" +
            "        // Some initialization code, such as the actual\r\n" +
            "        // connection to a database server.\r\n" +
            "        // ...\r\n" +
            "    // The static method that controls access to the singleton\r\n" +
            "    // instance.\r\n" +
            "    public static method getInstance() is\r\n" +
            "        if (Database.instance == null) then\r\n" +
            "            acquireThreadLock() and then\r\n" +
            "                // Ensure that the instance hasn't yet been\r\n" +
            "                // initialized by another thread while this one\r\n" +
            "                // has been waiting for the lock's release.\r\n" +
            "                if (Database.instance == null) then\r\n" +
            "                    Database.instance = new Database()\r\n" +
            "        return Database.instance\r\n" +
            "    // Finally, any singleton should define some business logic\r\n" +
            "    // which can be executed on its instance.\r\n" +
            "    public method query(sql) is\r\n" +
            "        // For instance, all database queries of an app go\r\n" +
            "        // through this method. Therefore, you can place\r\n" +
            "        // throttling or caching logic here.\r\n" +
            "        // ...\r\n" +
            "class Application is\r\n" +
            "    method main() is\r\n" +
            "        Database foo = Database.getInstance()\r\n" +
            "        foo.query(\"SELECT ...\")\r\n" +
            "        // ...\r\n" +
            "        Database bar = Database.getInstance()\r\n" +
            "        bar.query(\"SELECT ...\")\r\n" +
            "        // The variable `bar` will contain the same object as\r\n" +
            "        // the variable `foo`.\r\n";
            Program.WriteLineWithColor(SingletonPsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);
            Singleton s1 = Singleton.Instace;
            Singleton s2 = Singleton.Instace;

            if (s1 == s2)
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            else
                Console.WriteLine("Singleton failed, variables contain different instances.");

            Console.WriteLine();
        }
    }
}