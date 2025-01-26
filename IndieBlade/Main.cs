using Capitalov;

namespace IndieBlade
{
    internal class Main
    {
        private MemoryRaider _memory = new MemoryRaider();
        private string _logo = @"


                  ██ ███▄    █ ▓█████▄   ██▓ ▓█████      ▄▄▄▄     ██▓    ▄▄▄     ▓█████▄  ▓█████
                ▒▓██ ██ ▀█   █ ▒██▀ ██▌▒▓██▒ ▓█   ▀     ▓█████▄  ▓██▒   ▒████▄   ▒██▀ ██▌ ▓█   ▀
                ░▒██▓██  ▀█ ██▒░██   █▌▒▒██▒ ▒███       ▒██▒ ▄██ ▒██░   ▒██  ▀█▄ ░██   █▌ ▒███  
                 ░██▓██▒  ▐▌██▒░▓█▄   ▌░░██░ ▒▓█  ▄     ▒██░█▀   ▒██░   ░██▄▄▄▄██░▓█▄   ▌ ▒▓█  ▄
                 ░██▒██░   ▓██░░▒████▓ ░░██░▒░▒████    ▒░▓█  ▀█▓▒░██████▒▓█   ▓██░▒████▓ ▒░▒████
                 ░▓ ░ ▒░   ▒ ▒  ▒▒▓  ▒  ░▓  ░░░ ▒░     ░░▒▓███▀▒░░ ▒░▓  ░▒▒   ▓▒█ ▒▒▓  ▒ ░░░ ▒░ 
                  ▒ ░ ░░   ░ ▒░ ░ ▒  ▒ ░ ▒ ░░ ░ ░      ░▒░▒   ░ ░░ ░ ▒  ░ ░   ▒▒  ░ ▒  ▒ ░ ░ ░  
                  ▒    ░   ░ ░  ░ ░  ░ ░ ▒ ░    ░        ░    ░    ░ ░    ░   ▒   ░ ░  ░     ░  
                  ░          ░    ░      ░  ░   ░      ░ ░      ░    ░        ░     ░    ░   ░  


";
        private string _space = "                                   ";

        public void Start()
        {
            Console.WriteLine(_logo);
            Console.WriteLine($"{_space}Write the name of the game's process: ");
            string process = Console.ReadLine();
            _memory.Inject(process);
            Console.Clear();
            Console.WriteLine(_logo);
            Console.WriteLine($"{_space}Do you know the meaning of gravity in the game? (y/n)");
            string knows = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(_logo);
            float gravity = knows == "y" ? GetGravityValue() : -9.81f;
            Console.WriteLine($"{_space}Write the new value of gravity: ");
            float newGravity = float.Parse(Console.ReadLine());
            _memory.ChangeValue(gravity, newGravity);
        }

        private float GetGravityValue()
        {
            Console.WriteLine($"{_space}Write the value of gravity: ");
            return float.Parse(Console.ReadLine());
        }
    }
}
