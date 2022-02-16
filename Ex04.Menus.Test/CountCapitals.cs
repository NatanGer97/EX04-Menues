using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountCapitals : IFunctionalItem
    {
        public void Operate()
        {
            int upperCounter = 0;

            Console.WriteLine("Enter a sentence :");
            string userInput = Console.ReadLine();
            foreach (char t in userInput)
            {
                if (char.IsUpper(t))
                {
                    upperCounter++;
                }
            }

            Console.WriteLine(string.Format("The amount of upper letters is : {0}", upperCounter));
        }
    }
}