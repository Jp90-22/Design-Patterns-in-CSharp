using System;

namespace Design_Patterns.Patterns
{
    public class State
    {
        public static void Implementation()
        {
            Program.WriteLineWithColor("State:", Program.TITLE_COLOR);
            Console.WriteLine(
                "State is a behavioral design pattern that lets an object alter its behavior when its " +
                "internal state changes. It appears as if the object changed its class.\r\n"
            );

            Program.WriteLineWithColor("Real-World Analogy:", Program.TITLE_COLOR);
            Console.WriteLine(
                "The buttons and switches in your smartphone behave differently depending on the current state of the device:\r\n" +
                "- When the phone is unlocked, pressing buttons leads to executing various functions.\r\n" +
                "- When the phone is locked, pressing any button leads to the unlock screen.\r\n" +
                "- When the phone’s charge is low, pressing any button shows the charging screen.\r\n"
            );

            Program.WriteLineWithColor("- Pseudocode:", Program.TITLE_COLOR);

            string StatePsCode = "// The AudioPlayer class acts as a context. It also maintains a\r\n" +
            "// reference to an instance of one of the state classes that\r\n" +
            "// represents the current state of the audio player.\r\n" +
            "class AudioPlayer is\r\n" +
            "    field state: State\r\n" +
            "    field UI, volume, playlist, currentSong\r\n" +
            "    constructor AudioPlayer() is\r\n" +
            "        this.state = new ReadyState(this)\r\n" +
            "        // Context delegates handling user input to a state\r\n" +
            "        // object. Naturally, the outcome depends on what state\r\n" +
            "        // is currently active, since each state can handle the\r\n" +
            "        // input differently.\r\n" +
            "        UI = new UserInterface()\r\n" +
            "        UI.lockButton.onClick(this.clickLock)\r\n" +
            "        UI.playButton.onClick(this.clickPlay)\r\n" +
            "        UI.nextButton.onClick(this.clickNext)\r\n" +
            "        UI.prevButton.onClick(this.clickPrevious)\r\n" +
            "    // Other objects must be able to switch the audio player's\r\n" +
            "    // active state.\r\n" +
            "    method changeState(state: State) is\r\n" +
            "        this.state = state\r\n" +
            "    // UI methods delegate execution to the active state.\r\n" +
            "    method clickLock() is\r\n" +
            "        state.clickLock()\r\n" +
            "    method clickPlay() is\r\n" +
            "        state.clickPlay()\r\n" +
            "    method clickNext() is\r\n" +
            "        state.clickNext()\r\n" +
            "    method clickPrevious() is\r\n" +
            "        state.clickPrevious()\r\n" +
            "    // A state may call some service methods on the context.\r\n" +
            "    method startPlayback() is\r\n" +
            "        // ...\r\n" +
            "    method stopPlayback() is\r\n" +
            "        // ...\r\n" +
            "    method nextSong() is\r\n" +
            "        // ...\r\n" +
            "    method previousSong() is\r\n" +
            "        // ...\r\n" +
            "    method fastForward(time) is\r\n" +
            "        // ...\r\n" +
            "    method rewind(time) is\r\n" +
            "        // ...\r\n" +
            "// The base state class declares methods that all concrete\r\n" +
            "// states should implement and also provides a backreference to\r\n" +
            "// the context object associated with the state. States can use\r\n" +
            "// the backreference to transition the context to another state.\r\n" +
            "abstract class State is\r\n" +
            "    protected field player: AudioPlayer\r\n" +
            "    // Context passes itself through the state constructor. This\r\n" +
            "    // may help a state fetch some useful context data if it's\r\n" +
            "    // needed.\r\n" +
            "    constructor State(player) is\r\n" +
            "        this.player = player\r\n" +
            "    abstract method clickLock()\r\n" +
            "    abstract method clickPlay()\r\n" +
            "    abstract method clickNext()\r\n" +
            "    abstract method clickPrevious()\r\n" +
            "// Concrete states implement various behaviors associated with a\r\n" +
            "// state of the context.\r\n" +
            "class LockedState extends State is\r\n" +
            "    // When you unlock a locked player, it may assume one of two\r\n" +
            "    // states.\r\n" +
            "    method clickLock() is\r\n" +
            "        if (player.playing)\r\n" +
            "            player.changeState(new PlayingState(player))\r\n" +
            "        else\r\n" +
            "            player.changeState(new ReadyState(player))\r\n" +
            "    method clickPlay() is\r\n" +
            "        // Locked, so do nothing.\r\n" +
            "    method clickNext() is\r\n" +
            "        // Locked, so do nothing.\r\n" +
            "    method clickPrevious() is\r\n" +
            "        // Locked, so do nothing.\r\n" +
            "// They can also trigger state transitions in the context.\r\n" +
            "class ReadyState extends State is\r\n" +
            "    method clickLock() is\r\n" +
            "        player.changeState(new LockedState(player))\r\n" +
            "    method clickPlay() is\r\n" +
            "        player.startPlayback()\r\n" +
            "        player.changeState(new PlayingState(player))\r\n" +
            "    method clickNext() is\r\n" +
            "        player.nextSong()\r\n" +
            "    method clickPrevious() is\r\n" +
            "        player.previousSong()\r\n" +
            "class PlayingState extends State is\r\n" +
            "    method clickLock() is\r\n" +
            "        player.changeState(new LockedState(player))\r\n" +
            "    method clickPlay() is\r\n" +
            "        player.stopPlayback()\r\n" +
            "        player.changeState(new ReadyState(player))\r\n" +
            "    method clickNext() is\r\n" +
            "        if (event.doubleclick)\r\n" +
            "            player.nextSong()\r\n" +
            "        else\r\n" +
            "            player.fastForward(5)\r\n" +
            "    method clickPrevious() is\r\n" +
            "        if (event.doubleclick)\r\n" +
            "            player.previous()\r\n" +
            "        else\r\n" +
            "            player.rewind(5)\r\n";

            Program.WriteLineWithColor(StatePsCode, Program.PSCODE_COLOR);

            // The client code
            Program.WriteLineWithColor("Implementation:", Program.TITLE_COLOR);

            StateContext state = new StateContext();

            Console.WriteLine("Working with a good state:");
            state.StateToHandler = new GoodState();
            state.Request();

            Console.WriteLine("Working with a bad state:");
            state.StateToHandler = new BadState();
            state.Request();

            Console.WriteLine();
        }
    }

    // The base State class declares methods that all Concrete State should
    // implement and also can provides a backreference to the Context object,
    // associated with the State. This backreference can be used by States to
    // transition the Context to another State (This class don't do that).
    public interface IState
    {
        void Handler();
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    public class BadState : IState
    {
        public void Handler()
        {
            Console.WriteLine("I'm handling a bad state...");
        }
    }

    public class GoodState : IState
    {
        public void Handler()
        {
            Console.WriteLine("I'm handling a good state...");
        }
    }

    // The Context defines the interface of interest to clients. It also
    // maintains a reference to an instance of a State to handler, which
    // represents the current state of the Context.
    public class StateContext
    {
        // A reference to the current state of the Context.
        public IState StateToHandler { get; set; }

        public void Request()
        {
            StateToHandler.Handler();
        }
    }
}