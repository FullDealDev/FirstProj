using System;

namespace RPGChallenge
{
	public class Gameplay : Engine
    {
        public static void Main(string[] args) // Start method
        {
			Init(1);
			Zombie(12);
            Console.ReadKey();
        }
	}
}
