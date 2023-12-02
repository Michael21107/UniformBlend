using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace UniformBlend
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Welcome to UniformBlend!");
            WriteLine("------------------------------");
            WriteLine("1. Paste To Line");
            WriteLine("2. Credits");
            WriteLine("------------------------------");
            Write("Please enter your choice (1, or 2): ");
            WriteLine();

            string userInput = ReadLine();

            switch(userInput)
            {
                case "1":
                    PasteToLine();
                    break;

                case "2":
                    Clear();
                    WriteLine("Haze/HazeStudioFR");
                    break;

                default:
                    WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
            ReadLine();
        }

        private static void PasteToLine()
        {
            Clear();
            WriteLine("You Have Selected Paste To Line");
            List<string> userInputLines = new List<string>();
            WriteLine("Paste the lines of information. Enter an empty line to finish.");
            WriteLine("------------------------------");
            WriteLine();

            while(true)
            {
                string line = ReadLine();

                if(string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                userInputLines.Add(line);
            }

            string newString = string.Join("\n", userInputLines);
            Outfit outfit = Outfit.ParseOutfit(newString);

            WriteLine("The Following Has Been Inputed.");
            WriteLine("------------------------------");
            WriteLine($"Outfit Name: {outfit.Name}");
            WriteLine($"Outfit Gender: {outfit.Gender}");
            WriteLine($"Outfit Hat: {outfit.Hat}");
            WriteLine($"Outfit Glasses: {outfit.Glasses}");
            WriteLine($"Outfit Ear: {outfit.Ear}");
            WriteLine($"Outfit Watch: {outfit.Watch}");
            WriteLine($"Outfit Mask: {outfit.Mask}");
            WriteLine($"Outfit Top: {outfit.Top}");
            WriteLine($"Outfit UpperSkin: {outfit.UpperSkin}");
            WriteLine($"Outfit Decal: {outfit.Decal}");
            WriteLine($"Outfit UnderCoat: {outfit.UnderCoat}");
            WriteLine($"Outfit Pants: {outfit.Pants}");
            WriteLine($"Outfit Shoes: {outfit.Shoes}");
            WriteLine($"Outfit Accessories: {outfit.Accessories}");
            WriteLine($"Outfit Armor: {outfit.Armor}");
            WriteLine($"Outfit Parachute: {outfit.Parachute}");
            WriteLine("------------------------------");

            Write("Converting To LSPDFR Format...");
            using(var progress = new ProgressBar())
            {
                for(int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(10);
                }
            }
            WriteLine("Done.");
            Thread.Sleep(2000);
            Clear();

            WriteLine("Please Enter ScriptName. Ex m_base");
            string ScriptName = ReadLine();
            Clear();
            WriteLine("<Variation>");
            WriteLine($"<Name>{outfit.Name}</Name>");
            WriteLine($"<ScriptName>{ScriptName}</ScriptName>");
            WriteLine($"<Gender>{outfit.Gender.ToLower()}</Gender>");
            WriteLine($"<Components>");
            WriteLine($"<Component id=\"3\" drawable=\"{outfit.UpperSkin.Number}\" texture=\"{outfit.UpperSkin.Texture}\" />");
            WriteLine($"<Component id=\"4\" drawable=\"{outfit.Pants.Number}\" texture=\"{outfit.Pants.Texture}\" />");
            WriteLine($"<Component id=\"5\" drawable=\"{outfit.Parachute.Number}\" texture=\"{outfit.Parachute.Texture}\" />");
            WriteLine($"<Component id=\"6\" drawable=\"{outfit.Shoes.Number}\" texture=\"{outfit.Shoes.Texture}\" />");
            WriteLine($"<Component id=\"7\" drawable=\"{outfit.Accessories.Number}\" texture=\"{outfit.Accessories.Texture}\" />");
            WriteLine($"<Component id=\"8\" drawable=\"{outfit.UnderCoat.Number}\" texture=\"{outfit.UnderCoat.Texture}\" />");
            WriteLine($"<Component id=\"9\" drawable=\"{outfit.Armor.Number}\" texture=\"{outfit.Armor.Texture}\" />");
            WriteLine($"<Component id=\"10\" drawable=\"{outfit.Decal.Number}\" texture=\"{outfit.Decal.Texture}\" />");
            WriteLine($"<Component id=\"11\" drawable=\"{outfit.Top.Number}\" texture=\"{outfit.Top.Texture}\" />");
            WriteLine($"</Components>");
            WriteLine($"</Variation>");

            ReadKey();
        }
    }
}