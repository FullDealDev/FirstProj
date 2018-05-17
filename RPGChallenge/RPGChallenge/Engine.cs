using System;
using System.Threading;

namespace RPGChallenge
{
	public class Engine
	{
		// VARIABLES:

		protected static string userInput;
		protected static int experience;
		protected static int playerHealth;
		protected static int armorPoints;
        
		// FUNCTIONS:

		protected static void Init(int loadTime) // Initializer
		{
			userInput = null;
			experience = 0;
			armorPoints = 0;
			playerHealth = 100;
			Thread.Sleep(1000 * loadTime);
		}

		// ENEMYS:

		protected static void Knight()
		{
			var health = 50;
			var damage = 20;
			Console.WriteLine("\nA Knight has appeared!");
			Hint("Take a drink, take a reward");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Swing sword(x)");
				Console.WriteLine("Health Potion(y)");
				Console.WriteLine("Stab(e)");
				Console.WriteLine();
				userInput = Console.ReadLine();
				switch (userInput) // Checks if the player inputs the buttons for the weapons.
				{
					case "x":
						SwordSwing("Knight");
						playerHealth = playerHealth - damage;
						health = health - 5;
						DisplayHealth();
						Console.WriteLine("Enemy health: " + health);
						break;
					case "y":
						HealthPotion(10);
						break;
					case "e":
						SwordStab("Knight");
						playerHealth = playerHealth - damage;
						health = health - 7;
						DisplayHealth();
						Console.WriteLine("Enemy health: " + health);
						break;
				}
			}
			// After the player defeats or is killed by the enemy.
			if (health < 0 && playerHealth > 0)
			{
				VictoryScreen(15, "Knight");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		protected static void SkeletonArcher()
		{
			var health = 25;
			var damage = 10;
			Console.WriteLine("\nA Skeleton Archer has appeared!");
			Hint("IT'S NO SCOPE");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Fire Gun(e)");
				Console.WriteLine("Throw Rock(r)");
				Console.WriteLine("Deflect Arrow(x)"); // Sorry if I missed spillled it.
				userInput = Console.ReadLine();
				switch (userInput)
				{
					case "e":
						FireGun("Skeleton Archer");
						health = health - 7;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "r":
						ThrowRock("Skeleton Archer"); // Mission failed: Will Get'em next time lol
						health = health - 1;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "x":
						Damage(3, "Skeleton Archer", ".");
						health = health - 3;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
				}
			}
			if (health <= 0 && playerHealth > 0)
			{
				VictoryScreen(15, "Skeleton Archer");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		protected static void Golem()
		{
			var health = 100;
			var damage = 25;
			Console.WriteLine("\nA Golem has appeared!!");
			Hint("When you choose your weapon, you can only use that weapon and no other weapon");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Swing Sword(q)");
				Console.WriteLine("Health Potion(x)");
				Console.WriteLine("Punch With Iron Glove(e)");
				userInput = Console.ReadLine();
				switch (userInput)
				{
					case "q":
						SwordSwing("Golem");
						health = health - 5;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "x":
						ThrowRock("Golem");
						health = health - 1;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "e":
						PunchWithIronGlove("Golem");
						health = health - 35;
						playerHealth = playerHealth - damage;
						break;
				}
			}
			if (health <= 0 && playerHealth > 0)
			{
				VictoryScreen(45, "Golem");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		protected static void Witch()
		{
			var health = 100;
			var damage = 15;
			Console.WriteLine("\nA Witch has appeared!!");
			Hint("BURN THE WITCH");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Swing Torch(e)");
				Console.WriteLine("Shoot Arrow With A Poison Tip(d)");
				Console.WriteLine("Swing Sword(q)");
				userInput = Console.ReadLine();
				switch (userInput)
				{
					case "e":
						SwingTorch("Witch");
						health = health - 25;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "d":
						FireArrowWithPoison("Witch");
						health = health - 1;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "q":
						SwordSwing("Witch");
						health = health - 5;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
				}
			}
			if (health <= 0 && playerHealth > 0)
			{
				VictoryScreen(20, "Witch");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		protected static void Zombie(int armorLevel) 
		{
			var health = 50;
			if (armorLevel >= 10 || armorLevel >= 20) 
			{
				health = health + armorLevel;
			}
            var damage = 25;
            Console.WriteLine("\nA Zombie has appeared!!");
            Hint("How do you kill a Zombie?");
            while (health > 0 && playerHealth > 0)
            {
                Console.WriteLine("Fire Gun(e)");
                Console.WriteLine("Swing Sword(d)");
                Console.WriteLine("Punch(x)");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "e":
						ShootHeadWithShotGun("Zombie");
                        health = health - 50;
                        playerHealth = playerHealth - damage;
                        DisplayHealth();
                        break;
                    case "d":
						SwordSwing("Zombie");
                        health = health - 0;
                        playerHealth = playerHealth - damage;
                        DisplayHealth();
                        break;
                    case "x":
                        Punch("Zombie");
                        health = health - 0;
                        playerHealth = playerHealth - damage;
                        DisplayHealth();
                        break;
                }
            }
            if (health <= 0 && playerHealth > 0)
            {
                VictoryScreen(20, "Zombie");
            }
            else if (playerHealth <= 0)
            {
                DeathScreen();
            }
		}

		protected static void Mummy()
		{
			var health = 5;
			var damage = 25;
			Console.WriteLine("\nA Mummy has appeared!!");
			Hint("Light is a powerful weapon against the dead");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Torch(x)");
				Console.WriteLine("Swing Sword(e)");
				Console.WriteLine("Punch(q)");
				userInput = Console.ReadLine();
				switch (userInput)
				{
					case "x":
						Torch("Mummy");
						health = health - 5;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "e":
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "q":
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
				}
			}
			if (health <= 0 && playerHealth > 0)
			{
				VictoryScreen(5, "Mummy");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		public static void DarkIbis()
		{
			var health = 15;
			var damage = 25;
			Console.WriteLine("\nA Dark Ibis has appeared!!");
			Hint("FIRE");
			while (health > 0 && playerHealth > 0)
			{
				Console.WriteLine("Fire Gun(q)");
				Console.WriteLine("Swing Sword(x)");
				Console.WriteLine("Punch(u)");
				userInput = Console.ReadLine();
				switch (userInput)
				{
					case "q":
						FireGun("DarkIbis");
						health = health - 5;
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "x":
						SwordSwing("DarkIbis");
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
					case "u":
						Punch("Dark Ibis");
						playerHealth = playerHealth - damage;
						DisplayHealth();
						break;
				}
			}
			if (health <= 0 && playerHealth > 0)
			{
				VictoryScreen(15, "Dark Ibis");
			}
			else if (playerHealth <= 0)
			{
				DeathScreen();
			}
		}

		// DUNGEONS AND STRUCTURES:

		protected static void NormalDungeon(Int16 seed)
		{
			int loadingTime = 900;
			switch (seed)
			{
				case 88:
					Console.WriteLine("You found a dungeon! Would you like to enter? \nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						SkeletonArcher();
						Knight();
						Golem();
						Reward(103);
					}
					break;
				case 45:
					Console.WriteLine("You found a dungeon! Would you like to enter? \nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						Witch();
						SkeletonArcher();
						Reward(5);
						SkeletonArcher();
						Reward(100);
					}
					break;
				case 69:
					Console.WriteLine("You found a dungeon! Would you like to enter? \nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						Knight();
						Reward(12);
						SkeletonArcher();
						Reward(90);
					}
					break;
				case 02:
					Console.WriteLine("You found a dungeon! Would you like to enter? \nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						Knight();
						Reward(12);
						SkeletonArcher();
						Reward(90);
					}
					break;
				default:
					Error("Seed does not exist");
					break;
			}
			Console.WriteLine("You have defeated this dungeon!");
		}

		protected static void Pyramid(Int16 seed)
		{
			int loadingTime = 900;
			switch (seed)
			{
				case 19:
					Console.WriteLine("You have found a anchient Pyramid! Would you like to enter?\nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						Mummy();
						Reward(50);
						DarkIbis();
						Mummy();
						Reward(155);
					}
					break;
				case 72:
					Console.WriteLine("You have found a anchient Pyramid! Would you like to enter?\nYes(x)\nNo(e)");
					userInput = Console.ReadLine();
					if (userInput == "x")
					{
						LoadingScreen(loadingTime);
						DarkIbis();
						Reward(212);
						Mummy();
					}
					break;
				default:
					Error("Seed does not exist");
					break;
			}
		}


		// BASIC GAME MECHANICS:

		protected static void DisplayHealth()
		{
			Console.WriteLine("Current health: " + playerHealth);
		}

		protected static void Reward(int reward)
		{
			experience = experience + reward;
			Console.WriteLine("\nAwarded " + reward + " experience.");
			Console.WriteLine("Current experience: " + experience);
		}

		protected static void Damage(int damage, string enemyType, string damageType)
		{
			Console.WriteLine(enemyType + " has tooken " + damage + " damage" + damageType);
		}

		public static void LoadingScreen(int length)
		{
			Console.WriteLine("\nLoading... ");
			Thread.Sleep(length);
		}

		protected static void RewardForKill(int reward, string enemyType)
		{
			Console.WriteLine("You have defeated a " + enemyType + "!");
			Reward(reward);
			LoadingScreen(1000);
		}

		protected static void DeathScreen()
		{
			Console.WriteLine("[§YOU HAVE DIED§]");
			experience = experience - 20;
			if (experience < 0)
			{
				experience = 0;
			}
			Console.WriteLine("Current experience: " + experience);
			playerHealth = 100;
		}

		protected static void VictoryScreen(int rewardForKill, string enemyType)
		{
			Console.WriteLine("[¶YOU WIN¶]");
			RewardForKill(rewardForKill, enemyType);
			Console.WriteLine("Current experience: " + rewardForKill);
		}

		public static void Hint(string hint)
		{
			Console.Write("[HINT]: " + hint + ".\n");
		}

		public static void Message(object message)
		{
			Console.Write("[MESSAGE]: " + "[" + message + "]");
		}

		public static void CharacterMessage(object message, string characterName)
		{
			Console.Write("[" + characterName + "]: " + "[" + message + "]");
		}

		public static void Narrate(string text)
		{
			Console.WriteLine("'" + text + "'");
		}

		public static void Error(string error)
		{
			Console.Beep();
			Console.WriteLine("[ERROR]: " + error.ToUpper() + ";");
		}

		// ATTACKS:

		protected static void HealthPotion(int extraHealth)
		{
			playerHealth = playerHealth + extraHealth;
			Console.WriteLine("You have gained " + extraHealth + " health!");
		}

		protected static void SwordSwing(string enemyType)
		{
			Damage(5, enemyType, "!");
		}

		protected static void SwordStab(string enemyType)
		{
			Damage(7, enemyType, "!!");
		}

		protected static void FireGun(string enemyType)
		{
			Damage(7, enemyType, "!!");
		}

		protected static void ThrowRock(string enemyType)
		{
			Damage(1, enemyType, " •_•");
		}

		protected static void DeflectArrow(string enemyType)
		{
			Damage(3, enemyType, ".");
		}

		protected static void PunchWithIronGlove(string enemyType)
		{
			Damage(35, enemyType, "!!!");
		}

		protected static void SwingTorch(string enemyType)
		{
			Damage(25, enemyType, "!!!");
		}

		protected static void FireArrowWithPoison(string enemyType)
		{
			Damage(1, enemyType, " •_•");
		}

		protected static void Torch(string enemyType)
		{
			Damage(5, enemyType, ".");
		}

		protected static void Punch(string enemyType)
		{
			Damage(1, enemyType, " •_•");
		}

		protected static void Knife(string enemyType)
		{
			Damage(9, enemyType, "!!");
		}

		protected static void ShootHeadWithShotGun(string enemyType) 
		{
			Damage(50, enemyType, "!!!!");
		}
       
	}
}