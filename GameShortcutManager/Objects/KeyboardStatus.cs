using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game_Shortcut_Manager.Objects
{
    //https://stackoverflow.com/questions/6312636/how-to-implement-catching-and-showing-the-current-key-presses-using-a-wpf-textbo
    public class KeyboardStatus
    {
        ModifierKeys _modifiers;

        public KeyboardStatus(Key key, ModifierKeys modifiers)
        {
            _modifiers = modifiers;
        }

        public Key PressedKey { get; set; }
        public bool IsControlPressed { get { return ((_modifiers & ModifierKeys.Control) > 0); } }
        // ....

        public override string ToString()
        {
            string display = string.Empty;

            display += ((Keyboard.Modifiers & ModifierKeys.Control) > 0) ? "Ctrl + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Alt) > 0) ? "Alt + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Shift) > 0) ? "Shift + " : string.Empty;
            display += ((Keyboard.Modifiers & ModifierKeys.Windows) > 0) ? "Win + " : string.Empty;
            display += PressedKey.ToString();
            return display;
        }

    }
}
