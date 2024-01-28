using System;

class Program
{
    private static int playerHealth;
    private static int enemyHealth;
    private static int bossHealth;
    static Random random = new Random();

    static void Main()
    {
        playerHealth = 35;
        enemyHealth = 35;
        bossHealth = 75;

        Console.WriteLine("Welcome to the Big Fish, underwater text based adventure game.\nYou are a fish, and try to eat other fishes. Bon Apetit!\n--------------------\n");

        BigFish();
    }

    static void BigFish()
    {
        Console.WriteLine("--The flow drags you to a crossroad. Which way do you wanna swim?\n");
        Console.WriteLine("1. Left");
        Console.WriteLine("2. Right");

        int choice = selectChoice(2);

        if (choice == 1)
        {
            Left();
        }
        else
        {
            Right();
        }
    }

    static void Left()
    {
        Console.WriteLine("--Your selection guides you to ocean, what do you want to do?\n");
        Console.WriteLine("1. Go Back");
        Console.WriteLine("2. Keep swimming");

        int choice = selectChoice(2);

        if (choice == 2)
        {
            Console.WriteLine("\n--------------------\nYou are too small to eat the fishes in the ocean, and eaten by a shark. You're Dead.");
        }
        else
        {
            Console.WriteLine("--You tried to find another way because of the flow, and find a way to river that being secured by a guard. What do you want to do?");
            Console.WriteLine("1. Try to eat the guard fish");
            Console.WriteLine("2. Try to negotiate with it");

            choice = selectChoice(2);

            if (choice == 1)
            {
                Fight("Guard Fish");
                
                if (playerHealth > 0)
                {
                    Console.WriteLine("\n--------------------\nYou managed to eat the guard, and enter the river. You're safe now!\n");
                }
                else
                {
                    Console.WriteLine("\n--------------------\nYou were bigger then the guard, but it seems it was hungrier than you. You'd been eaten!");
                }
            }
            else
            {
                Console.WriteLine("\n--------------------\nThe Guard let you in because you are smarter then your stomach, you're safe now!");
            }
        }
    }

    static void Right()
    {
        Console.WriteLine("--You entered radioactive waters, and saw fishes there. Do you want to eat them?\n");
        Console.WriteLine("1. Eat");
        Console.WriteLine("2. Don't Eat");

        int choice = selectChoice(2);

        if (choice == 2)
        {
            Console.WriteLine("\n--------------------\nYou starved to death! Did you forgot your purpose?\n");
        }
        else
        {
            Console.WriteLine("\n--------------------\nYou get radiation in your blood. But unlike you scared, you're stronger now. And with your bravery, you tried to eat the whole river.\n");
            playerHealth = 75;

            Fight("Guards of the river");
            if (playerHealth > 0)
            {
                Console.WriteLine("--You somehow managed to eat all of the fishes in the river. Do you want to continue with greed, or have a good sleep?");
                Console.WriteLine("1. Swim to ocean and try to eat shark");
                Console.WriteLine("2. Go get some good sleep");

                choice = selectChoice(2);

                if (choice == 1)
                {
                    BossFight("Shark");
                    if (playerHealth > 0)
                    {
                        Console.WriteLine("\n--------------------\nYou've become so powerful that now you know how every type of fish tastes. Congrats!");
                    }
                }
                else
                {
                    Console.WriteLine("\n--------------------\nNight' night!\n");
                }
            }
            else
            {
                Console.WriteLine("\n--------------------\nRadiation must have just show it's effects. You suddenly weakened, and eaten by guardians!\n");
            }
        }
    }
    
    static void BossFight(string EnemyName)
    {
        Console.WriteLine($"\n--------------------\nBOSS FIGHT!\n--------------------\n");
        Console.WriteLine($"It's {EnemyName} vs you! Sharpen your teeth, Fight is about the start!");
        enemyHealth = bossHealth;

        while (playerHealth > 0)
        {
            Console.WriteLine($"--Your Health: {playerHealth}  {EnemyName}'s Health: {enemyHealth}\n");
            Console.WriteLine("1. Bite");
            Console.WriteLine("2. Dodge");

            int choice = selectChoice(2);

            if (choice == 1)
            {
                Attack(EnemyName);
            }
            else
            {
                Console.WriteLine($"You dodged {EnemyName}'s bite!");
                break;
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine($"Your Health: 0  {EnemyName}'s Health: {enemyHealth}");
                Console.WriteLine("You were defeated not by the shark, but your greed! You were eaten!");
                break;
            }
            if (enemyHealth <= 0)
            {
                Console.WriteLine("Radiation must have worked, you even managed to eat a shark!");
                break;
            }

            EnemyAttack(EnemyName);
            if (playerHealth <= 0)
            {
                Console.WriteLine($"Your Health: 0  {EnemyName}'s Health: {enemyHealth}");
                Console.WriteLine("You were defeated not by the shark, but your greed! You were eaten!");
                break;
            }
        }
    }

    static void Fight(string EnemyName)
    {
        Console.WriteLine($"\nIt's {EnemyName} vs you! Sharpen your teeth, Fight is about the start!");

        while (playerHealth > 0)
        {
            Console.WriteLine($"--Your Health: {playerHealth}  {EnemyName}'s Health: {enemyHealth}\n");
            Console.WriteLine("1. Bite");
            Console.WriteLine("2. Dodge");

            int choice = selectChoice(2);

            if (choice == 1)
            {
                Attack(EnemyName);
            }
            else
            {
                Console.WriteLine($"You dodged {EnemyName}'s bite!");
                break;
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine($"Your Health: 0  {EnemyName}'s Health: {enemyHealth}");
                Console.WriteLine("You were eaten!");
                break;
            }
            if (enemyHealth <= 0)
            {
                Console.WriteLine("You managed to get the last bite!");
                break;
            }

            EnemyAttack(EnemyName);
            if (playerHealth <= 0)
            {
                Console.WriteLine($"Your Health: 0  {EnemyName}'s Health: {enemyHealth}");
                Console.WriteLine("You were eaten!");
                break;
            }
        }
    }

    static void Attack(string enemyName)
    {
        int damageGiven = random.Next(5, 15);



        if (playerHealth > 0)
        {
            enemyHealth -= damageGiven;
            Console.WriteLine($"\nYou bite and give {damageGiven} damage.");
        }
    }

    static void EnemyAttack(string enemyName)
    {
        int damageTaken = random.Next(3, 10);
        playerHealth -= damageTaken;

        Console.WriteLine($"{enemyName} bites you! you took {damageTaken} damage.");
    }

    static int selectChoice(int choice)
    {
        int currentChoice;
        while (true)
        {
            Console.Write("\nWhat's your choice? (1-" + choice + "): ");
            if (int.TryParse(Console.ReadLine(), out currentChoice) && currentChoice >= 1 && currentChoice <= choice)
            {
                break;
            }
            else
            {
                Console.WriteLine("\nThere's no other way!\n");
            }
        }
        return currentChoice;
    }
}

