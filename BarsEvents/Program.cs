using System;

namespace BarsEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyboardReader reader = new KeyboardReader();
            reader.OnKeyPresed += Symbol;
            reader.Run();
        }
        public static void Symbol(object sender, char symbol)
        {
            Console.WriteLine($"\n{symbol}");
        }
    }

    public class KeyboardReader
    {
        public event EventHandler<char> OnKeyPresed;
        public void Run()
        {
            char pressedKeyChar = Console.ReadKey().KeyChar;
            while (pressedKeyChar != 'c')
            {
                pressedKeyChar = Console.ReadKey().KeyChar;
                OnKeyPresed?.Invoke(this,pressedKeyChar);
            }
        }
    }
}