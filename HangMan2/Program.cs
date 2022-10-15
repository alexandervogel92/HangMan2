using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HangMan2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("#############################################################");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                       HANGMAN    ");
                Console.ResetColor();
                Console.WriteLine("#############################################################");

                Console.WriteLine();
                Console.WriteLine("Wähle eine Option aus: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 Spielen");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2 Beenden");
                Console.ResetColor();
                Console.Write("Aktion: ");
                int options = Convert.ToInt32(Console.ReadLine());
                bool end = false;

                switch (options)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        end = true;
                        break;
                }
                if (end)
                {
                    break;
                }
                Console.ReadKey();
            }
        }

        static void StartGame()
        {
            string[] words = new string[]
            {
                "Gesetzesgeber",
                "Teufelsbahn",
                "Sushi",
                "kleinigkeiten",
                "geburtskanal",
                "Fischfutter",
                "gurgeln",
                "halteverbot",
                "Turbo",
                "überhohlen",
                "ängstlich",
                "magendarm",
                "fiasko",
                "idioten",
                "liedermacher",
                "faultier",
                "gürtelrose"
            };

            Random random = new Random();
            int index = random.Next(0, words.Length);
            string word = words[index].ToLower();
            GameLoop(word);




        }
        static void GameLoop(string word)
        {
            int lives = 10;
            string frontchar = "";
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ä', 'ö', 'ü' };
            string hiddenword = "";

            for (int i = 0; i < lives; i++)
            {
                hiddenword += "_";
            }
            for (int f = 0; f < letters.Length; f++)
            {
                frontchar += "_";
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gesuchtes Wort: " + hiddenword);
                Console.Write("noch übrige Versuche:");
                for (int i = 0; i < lives; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }
                Console.WriteLine();
                Console.WriteLine("bereits benutzte Buchstaben: " + frontchar);

                Console.WriteLine();
                Console.Write("Buchstabe: ");
                char charakter = Convert.ToChar(Console.ReadLine().ToLower());

                bool foundCharakterInWord = false;
                bool showCharakter = false;

                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == charakter)
                    {
                        foundCharakterInWord = true;
                        break;
                    }
                }


                for (int l = 0; l < letters.Length; l++)
                {
                    if (letters[l] == charakter)
                    {
                        showCharakter = true;
                        break;
                    }
                }


                string tempHiddenWord = hiddenword;
                hiddenword = "";
                string tempfrontchar = frontchar;
                frontchar = "";

                if (foundCharakterInWord)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (word[j] == charakter)
                        {
                            hiddenword += charakter;
                        }
                        else if (tempHiddenWord[j] != '_')
                        {
                            hiddenword += tempHiddenWord[j];
                        }
                        else
                        {
                            hiddenword += '_';
                        }

                    }
                    if (hiddenword == word)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Herzlichen Glückwunsch du hast Gewonnen");
                        Console.WriteLine("das Gesuchte Wort war: " + word);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    hiddenword = tempHiddenWord;

                    if (lives > 0)
                    {
                        lives -= 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Verloren!!!!");
                        Console.ReadKey();
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    }
                }

                

                if (showCharakter)
                {
                    for (int l = 0; l < letters.Length; l++)
                    {
                        if (letters[l] == charakter)
                        {
                            frontchar += charakter;
                        }
                        else if (tempfrontchar[l] != '_')
                        {
                            frontchar += tempfrontchar[l];
                        }
                        else
                        {
                            frontchar += '_';
                        }
                    }

                }
            }
            }
        }
    }
