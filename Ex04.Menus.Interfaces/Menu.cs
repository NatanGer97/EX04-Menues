using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        private Dictionary<int, MenuItem> m_subMenuItems;
        private bool m_HasAncestorMenu;

        public bool HasAncestorMenu
        {
            get
            {
                return m_HasAncestorMenu;
            }

            set
            {
                m_HasAncestorMenu = value;
            }
        }

        public Menu(string i_MenuItemHeader)
            : base(i_MenuItemHeader)
        {
            m_subMenuItems = new Dictionary<int, MenuItem>();
            HasAncestorMenu = true;
            SetBackOrExitItem();
        }

        public Menu(string i_MenuItemHeader, bool i_HasAncestorMenu)
            : base(i_MenuItemHeader)
        {
            m_subMenuItems = new Dictionary<int, MenuItem>();
            HasAncestorMenu = i_HasAncestorMenu;
            SetBackOrExitItem();
        }

       public void SetBackOrExitItem()
        {

            if (HasAncestorMenu)
            {
                m_subMenuItems.Add(m_subMenuItems.Count, new MenuItem("Back"));
            }
            else
            {
                m_subMenuItems.Add(m_subMenuItems.Count, new MenuItem("Exit"));
            }
        }

        public void AddNewItemToSubMenu(MenuItem i_NewMenuItem)
        {
            m_subMenuItems.Add(m_subMenuItems.Count, i_NewMenuItem);
        }
        public void Show()
        {
            bool exitOrBack = false;

            while (!exitOrBack)
            {
                printCurrentMenu();
                int userChoice = getUserInput();
                Console.Clear();

                if (m_subMenuItems[userChoice] is Menu)
                {
                    ((Menu)m_subMenuItems[userChoice]).Show();
                }
                else if (m_subMenuItems[userChoice] is FunctionalMenuItem)
                {

                    ((FunctionalMenuItem)m_subMenuItems[userChoice]).DoWhenOperate();
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    exitOrBack = true;
                }
            }
        }

        private void printCurrentMenu()
        {
            StringBuilder menuHeaderToDiplay = new StringBuilder();
            menuHeaderToDiplay.Append('*', 2).Append(this.MenuItemHeader).Append('*', 2).AppendLine();
            menuHeaderToDiplay.Append('-', menuHeaderToDiplay.Length);
            Console.WriteLine(menuHeaderToDiplay.ToString());

            foreach (KeyValuePair<int, MenuItem> item in m_subMenuItems)
            {
                if (item.Key != 0)
                {
                    Console.WriteLine(string.Format("{0} -> {1}", item.Key, item.Value.MenuItemHeader));
                }
            }

            Console.WriteLine(string.Format("{0} -> {1}", m_subMenuItems.ElementAt(0).Key, m_subMenuItems.ElementAt(0).Value.MenuItemHeader));
            Console.WriteLine(string.Format("Enter your choice:[1,2 or 0 to {0}]", m_subMenuItems[0].MenuItemHeader));
        }

        private int getUserInput()
        {
            int userChoice = -1;

            while (!int.TryParse(Console.ReadLine(), out userChoice) || !m_subMenuItems.ContainsKey(userChoice))
            {
                Console.Clear();
                Console.WriteLine("Wrong selection, Please try again");
                Console.ReadLine();
                Console.Clear();
                printCurrentMenu();
            }

            return userChoice;
        }
    }

}