using System.Windows.Input;

namespace Deak_Levente_Ferenc_Lab4.CustomCommands
{
    public class StopCommand
    {
        private static RoutedUICommand launch_command;
        static StopCommand()
        {
            InputGestureCollection myInputGestures = new InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            launch_command = new RoutedUICommand("Launch", "Launch",
                typeof(StopCommand), myInputGestures);
        }
        public static RoutedUICommand Launch => launch_command;
    }
}
