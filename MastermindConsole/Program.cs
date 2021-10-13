using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindConsole
{
    class Program
    {
        static string masterValue;
        static string playerGuess;
        static int guessCount = 0;
        static string outputMessage;
        static bool playerWon = false;
        static string winnerMessage = "Congratulations you have guessed the master number!";
        static string loserMessage = "You were unable to best the master.";

        static void Main(string[] args)
        {
            GreetPlayer();
            GenerateMasterNumber();
            do
            {
                GetPlayerGuess();
                CompareMasterPlayerGuesses();
                if (playerWon)
                {
                    break;
                }
            }
            while (guessCount < 10);

            if (playerWon)
            {
                Console.WriteLine(winnerMessage);
            }
            else
            {
                Console.WriteLine(loserMessage);
            }
            
            Console.WriteLine(playerGuess);
            Console.ReadLine();

        }

        static void GreetPlayer()
        {
            Console.WriteLine("Welcome to Mastermind");
            Console.WriteLine("The master number is 4 digits long and may contain numbers between 1 and 6");
        }

        static void GenerateMasterNumber()
        {
            var random = new Random();
            for(int i = 0; i<4; i++)
            {
                masterValue += random.Next(1, 7);
            }
        }

        static void GetPlayerGuess()
        {
            guessCount++;
            Console.WriteLine($"Guess Count {guessCount}");
            Console.WriteLine("Enter your guess below");
            playerGuess = Console.ReadLine();
        }

        static void CompareMasterPlayerGuesses()
        {
            outputMessage = "";
            int plusCount = 0;
            for(int i = 0; i < 4; i++)
            {
                var currentPlayerIndex = playerGuess[i];
                var currentMasterIndex = masterValue[i];
                if(currentPlayerIndex == currentMasterIndex)
                {
                    plusCount += 1;
                    outputMessage += "+";
                }
                else if (masterValue.Contains(currentPlayerIndex))
                {
                    outputMessage += "-";
                }
                else
                {
                    outputMessage += " ";
                }
                
                if(plusCount == 4)
                {
                    playerWon = true;
                }
            }
        }

        static void PrintOutputMessage()
        {
            Console.WriteLine(outputMessage);
        }

    }
}
