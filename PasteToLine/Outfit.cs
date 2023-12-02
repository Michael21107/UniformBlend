using System;

namespace UniformBlend
{
    internal class Outfit
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public Component Hat { get; set; }
        public Component Glasses { get; set; }
        public Component Ear { get; set; }
        public Component Watch { get; set; }
        public Component Mask { get; set; }
        public Component Top { get; set; }
        public Component UpperSkin { get; set; }
        public Component Decal { get; set; }
        public Component UnderCoat { get; set; }
        public Component Pants { get; set; }
        public Component Shoes { get; set; }
        public Component Accessories { get; set; }
        public Component Armor { get; set; }
        public Component Parachute { get; set; }

        public Outfit()
        {
            Hat = new Component();
            Glasses = new Component();
            Ear = new Component();
            Watch = new Component();
            Mask = new Component();
            Top = new Component();
            UpperSkin = new Component();
            Decal = new Component();
            UnderCoat = new Component();
            Pants = new Component();
            Shoes = new Component();
            Accessories = new Component();
            Armor = new Component();
            Parachute = new Component();
        }

        public class Component
        {
            public int Number { get; set; }
            public int Texture { get; set; }

            public override string ToString()
            {
                return $"{Number}:{Texture}";
            }
        }

        public void SetComponent(string componentName, int number, int texture)
        {
            switch(componentName.ToLower())
            {
                case "hat":
                    Hat.Number = Math.Max(0, number - 1);
                    Hat.Texture = Math.Max(0, texture - 1);
                    break;

                case "glasses":
                    Glasses.Number = Math.Max(0, number - 1);
                    Glasses.Texture = Math.Max(0, texture - 1);
                    break;

                case "ear":
                    Ear.Number = Math.Max(0, number - 1);
                    Ear.Texture = Math.Max(0, texture - 1);
                    break;

                case "watch":
                    Watch.Number = Math.Max(0, number - 1);
                    Watch.Texture = Math.Max(0, texture - 1);
                    break;

                case "mask":
                    Mask.Number = Math.Max(0, number - 1);
                    Mask.Texture = Math.Max(0, texture - 1);
                    break;

                case "top":
                    Top.Number = Math.Max(0, number - 1);
                    Top.Texture = Math.Max(0, texture - 1);
                    break;

                case "upperskin":
                    UpperSkin.Number = Math.Max(0, number - 1);
                    UpperSkin.Texture = Math.Max(0, texture - 1);
                    break;

                case "decal":
                    Decal.Number = Math.Max(0, number - 1);
                    Decal.Texture = Math.Max(0, texture - 1);
                    break;

                case "undercoat":
                    UnderCoat.Number = Math.Max(0, number - 1);
                    UnderCoat.Texture = Math.Max(0, texture - 1);
                    break;

                case "pants":
                    Pants.Number = Math.Max(0, number - 1);
                    Pants.Texture = Math.Max(0, texture - 1);
                    break;

                case "shoes":
                    Shoes.Number = Math.Max(0, number - 1);
                    Shoes.Texture = Math.Max(0, texture - 1);
                    break;

                case "accessories":
                    Accessories.Number = Math.Max(0, number - 1);
                    Accessories.Texture = Math.Max(0, texture - 1);
                    break;

                case "armor":
                    Armor.Number = Math.Max(0, number - 1);
                    Armor.Texture = Math.Max(0, texture - 1);
                    break;

                case "parachute":
                    Parachute.Number = Math.Max(0, number - 1);
                    Parachute.Texture = Math.Max(0, texture - 1);
                    break;
            }
        }

        public static Outfit ParseOutfit(string input)
        {
            Outfit outfit = new Outfit();

            string[] lines = input.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in lines)
            {
                if(line.StartsWith("[") && line.EndsWith("]"))
                {
                    outfit.Name = line.Trim('[', ']').Trim();
                }
                else
                {
                    string[] parts = line.Split('=');
                    if(parts.Length == 2)
                    {
                        string propertyName = parts[0].Trim().ToLower();
                        string propertyValue = parts[1].Trim();

                        if(propertyName == "gender")
                        {
                            outfit.Gender = propertyValue.ToLower();
                            continue; 
                        }

                        string[] values = propertyValue.Split(':');

                        if(values.Length == 2 && int.TryParse(values[0], out int number) && int.TryParse(values[1], out int texture))
                        {
                            outfit.SetComponent(propertyName, number, texture);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input: {line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input: {line}");
                    }
                }
            }

            return outfit;
        }
    }
}