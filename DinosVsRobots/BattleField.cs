﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinosVsRobots
{
    class BattleField
    {
        public string userInput;
        public string selectCharacter;
        
        Fleet fleet = new Fleet();
        Herd herd = new Herd();
        Weapon weapon = new Weapon("gun");
        Dinosaur dinosaur;
        Robot robot;



        public void gameController()
        {
            gameInit();        
        }

        public void gameInit()
        {
            Console.WriteLine("Welcome to Robots vs. Dinosaurs, would you like to play a game? Please enter yes or no. ");
            userInput = Console.ReadLine().ToLower();
            gameOptions();
            Console.WriteLine("Let's get ready to do battle!!!");
            battleMode(dinosaur, robot);
        }

        public void gameOptions()
        {
            if (userInput == "y" || userInput == "yes")
            {
                Console.WriteLine("Awesome, please enter (1) to do battle a robot or (2) kick butt as a dinosaur: ");
                selectCharacter = Console.ReadLine();
                switch (selectCharacter)
                {
                    case "1":
                        Console.WriteLine($"Excellent choice you are a Robot!!!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        robot = fleet.robotInit();
                        dinosaur = fleet.opponentSelect();
                        break;
                    case "2":
                        Console.WriteLine($"Excellent choice you are a Dinosaur");
                        Console.ForegroundColor = ConsoleColor.Red;
                        dinosaur = herd.dinoInit();
                        break;
                    default:
                        Console.WriteLine($"Sorry that is not option....");
                        gameOptions();
                        break;
                }
            }
            else if (userInput == "n" || userInput == "no")
            {
                Console.WriteLine("Aww that's too bad, maybe next time. BYE");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please enter either yes or no");
                gameInit();
            }
        }

        public void battleMode(Dinosaur dinosaur, Robot robot)
        {
            int num1 = 2;                    
                while (dinosaur.dinoHealth > 0 && robot.robotHealth > 0)
                {
                    num1++;
                    if (num1 % 2 == 0)
                    {
                        Console.WriteLine(robot.robotName + " is attacking " + weapon.weaponsAttack());
                        robot.roboWeaponAttack(dinosaur);
                        Console.WriteLine(dinosaur.dinoName + " health level: " + dinosaur.dinoHealth);
                        Console.WriteLine("to atttack press ENTER");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine(dinosaur.dinoName + " is attacking: " + weapon.weaponsAttack());
                        dinosaur.dinoAttack(robot);
                        Console.WriteLine(robot.robotName + " health level: " + robot.robotHealth);
                        Console.WriteLine("to atttack press ENTER");
                        Console.ReadLine();
                    }
                }
             
            if(robot.robotHealth > dinosaur.dinoHealth)
            {
                Console.WriteLine(robot.robotName + " Wins!!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(dinosaur.dinoName + " Wins!!!");
                Console.ReadLine();
            }
            Console.WriteLine("Game Over, Thank you for playing");
            Console.WriteLine("Would you like to play again?");
            gameInit();
        }
    }
}
