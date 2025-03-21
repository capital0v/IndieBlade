using Capitalov;
using System;
using System.Collections.Generic;

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
            _memory.Attach(process);

            Console.Clear();
            Console.WriteLine(_logo);
            Console.WriteLine($"{_space}Do you know the meaning of gravity in the game? (y/n)");
            string knows = Console.ReadLine();

            float gravity = knows.ToLower() == "y" ? GetGravityValue() : -9.81f;

            Console.Clear();
            Console.WriteLine(_logo);
            Console.WriteLine($"{_space}Write the new value of gravity: ");
            float newGravity = float.Parse(Console.ReadLine());

            ChangeGravity(gravity, newGravity);
        }

        private float GetGravityValue()
        {
            Console.WriteLine($"{_space}Write the value of gravity: ");
            return float.Parse(Console.ReadLine());
        }

        private void ChangeGravity(float gravity, float newGravity)
        {
            Dictionary<IntPtr, float> foundValues = _memory.ScanValue(gravity);

            if (foundValues.Count == 0)
            {
                Console.WriteLine($"{_space}No values matching gravity = {gravity} were found.");
                return;
            }

            Console.WriteLine($"{_space}Found {foundValues.Count} addresses with gravity = {gravity}.");

            foreach (var address in foundValues.Keys)
            {
                _memory.Write(address, newGravity);
            }

            Console.WriteLine($"{_space}Gravity has been changed to {newGravity} at {foundValues.Count} addresses.");
        }
    }
}