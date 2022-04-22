using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{

    public class ShowVersion : IFunctionalItem
    {
        public void Operate()
        {
            Console.WriteLine("Version: 22.1.4.8930");
        }

    }
}