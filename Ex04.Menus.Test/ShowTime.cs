using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IFunctionalItem
    {
        public void Operate()
        {
            Console.WriteLine(string.Format("The Current time is:{0}", DateTime.Now.ToString("HH:mm")));
        }
    }
}