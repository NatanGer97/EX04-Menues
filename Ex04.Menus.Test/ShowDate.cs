using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IFunctionalItem
    {
        public void Operate()
        {
            Console.WriteLine(string.Format("Today is: {0}",DateTime.Today.ToString("d")));
        }
    }
}