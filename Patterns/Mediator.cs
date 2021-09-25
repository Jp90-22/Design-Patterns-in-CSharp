
using System;
using System.Collections.Generic;

namespace Design_Patterns.Patterns
{
    // The Mediator interface declares a method used by components to notify the
    // mediator about various events. The Mediator may react to these events and
    // pass the execution to other components.
    public interface IMediator
    {
        void SendMessage(string message, AbstractFriend addressee);
    }

    public abstract class AbstractFriend
    {
        public abstract string Name { get; }
        public abstract void SendMessageToFriend(string msg, AbstractFriend friend);
        public abstract void ReceiveMessage(string msg);
    }

    // Concrete Mediators implement cooperative behavior by coordinating several
    public class Mediator : IMediator
    {
        public void SendMessage(string message, AbstractFriend addressee)
        {
            Console.WriteLine($"-> the following message: '{message}' was sended to {addressee.Name}");
            addressee.ReceiveMessage(message);
        }

        public static void Implementation()
        {
            Program.WriteLineWithColor("Mediator:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Mediator is a behavioral design pattern that lets you reduce chaotic dependencies between " +
                "objects. The pattern restricts direct communications between the objects and forces them to " +
                "collaborate only via a mediator object.\r\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "Pilots of aircraft that approach or depart the airport control area don’t communicate directly with " +
                "each other. Instead, they speak to an air traffic controller, who sits in a tall tower " +
                "somewhere near the airstrip. Without the air traffic controller, pilots would need to be " +
                "aware of every plane in the vicinity of the airport, discussing landing priorities with a committee " +
                "of dozens of other pilots. That would probably skyrocket the airplane crash statistics.\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string MediatorPsCode = "// The mediator interface declares a method used by components\r\n" +
            "// to notify the mediator about various events. The mediator may\r\n" +
            "// react to these events and pass the execution to other\r\n" +
            "// components.\r\n" +
            "interface Mediator is\r\n" +
            "    method notify(sender: Component, event: string)\r\n" +
            "// The concrete mediator class. The intertwined web of\r\n" +
            "// connections between individual components has been untangled\r\n" +
            "// and moved into the mediator.\r\n" +
            "class AuthenticationDialog implements Mediator is\r\n" +
            "    private field title: string\r\n" +
            "    private field loginOrRegisterChkBx: Checkbox\r\n" +
            "    private field loginUsername, loginPassword: Textbox\r\n" +
            "    private field registrationUsername, registrationPassword,\r\n" +
            "                  registrationEmail: Textbox\r\n" +
            "    private field okBtn, cancelBtn: Button\r\n" +
            "    constructor AuthenticationDialog() is\r\n" +
            "        // Create all component objects and pass the current\r\n" +
            "        // mediator into their constructors to establish links.\r\n" +
            "    // When something happens with a component, it notifies the\r\n" +
            "    // mediator. Upon receiving a notification, the mediator may\r\n" +
            "    // do something on its own or pass the request to another\r\n" +
            "    // component.\r\n" +
            "    method notify(sender, event) is\r\n" +
            "        if (sender == loginOrRegisterChkBx and event == \"check\")\r\n" +
            "            if (loginOrRegisterChkBx.checked)\r\n" +
            "                title = \"Log in\"\r\n" +
            "                // 1. Show login form components.\r\n" +
            "                // 2. Hide registration form components.\r\n" +
            "            else\r\n" +
            "                title = \"Register\"\r\n" +
            "                // 1. Show registration form components.\r\n" +
            "                // 2. Hide login form components\r\n" +
            "        if (sender == okBtn && event == \"click\")\r\n" +
            "            if (loginOrRegister.checked)\r\n" +
            "                // Try to find a user using login credentials.\r\n" +
            "                if (!found)\r\n" +
            "                    // Show an error message above the login\r\n" +
            "                    // field.\r\n" +
            "            else\r\n" +
            "                // 1. Create a user account using data from the\r\n" +
            "                // registration fields.\r\n" +
            "                // 2. Log that user in.\r\n" +
            "                // ...\r\n" +
            "// Components communicate with a mediator using the mediator\r\n" +
            "// interface. Thanks to that, you can use the same components in\r\n" +
            "// other contexts by linking them with different mediator\r\n" +
            "// objects.\r\n" +
            "class Component is\r\n" +
            "    field dialog: Mediator\r\n" +
            "    constructor Component(dialog) is\r\n" +
            "        this.dialog = dialog\r\n" +
            "    method click() is\r\n" +
            "        dialog.notify(this, \"click\")\r\n" +
            "    method keypress() is\r\n" +
            "        dialog.notify(this, \"keypress\")\r\n" +
            "// Concrete components don't talk to each other. They have only\r\n" +
            "// one communication channel, which is sending notifications to\r\n" +
            "// the mediator.\r\n" +
            "class Button extends Component is\r\n" +
            "    // ...\r\n" +
            "class Textbox extends Component is\r\n" +
            "    // ...\r\n" +
            "class Checkbox extends Component is\r\n" +
            "    method check() is\r\n" +
            "        dialog.notify(this, \"check\")\r\n" +
            "    // ...\r\n";

            Program.WriteLineWithColor(MediatorPsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);

            IMediator mediator = new Mediator();
            FriendA friendA = new FriendA(mediator);
            FriendB friendB = new FriendB(mediator);

            friendA.SendMessageToFriend("Hi friend B, nice to see you", friendB);
            friendB.SendMessageToFriend("Hello, nice to see you too", friendA);

            Console.WriteLine();
        }
    }

    public class FriendA : AbstractFriend
    {
        private readonly IMediator _mediator;
        private string _name = "FriendA";

        public override string Name => _name;

        public FriendA(IMediator m)
        {
            _mediator = m;
        }

        public override void SendMessageToFriend(string msg, AbstractFriend friend)
        {
            _mediator.SendMessage(msg, friend as AbstractFriend);
        }

        public override void ReceiveMessage(string msg)
        {
            Console.WriteLine($"-> Friend: {_name} receive the message.");
        }
    }

    public class FriendB : AbstractFriend
    {
        private readonly IMediator _mediator;
        private string _name = "FriendB";

        public override string Name => _name;

        public FriendB(IMediator m)
        {
            _mediator = m;
        }

        public override void SendMessageToFriend(string msg, AbstractFriend friend)
        {
            _mediator.SendMessage(msg, friend as AbstractFriend);
        }

        public override void ReceiveMessage(string msg)
        {
            Console.WriteLine($"-> Friend: {_name} receive the message.");
        }
    }
}