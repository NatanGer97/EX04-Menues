using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex04.Menus.Delegates
{
    public enum eBackOrExit
    {
        Back,
        Exit,
    }

    public class Menu : MenuItem
    {
        private readonly Dictionary<int, MenuItem> r_SubMenuItems;
        private bool m_HasAncestorMenu;

        public bool HasAncestorMenu
        {
            get => m_HasAncestorMenu;

            set => m_HasAncestorMenu = value;
        }

        public Menu(string i_MenuItemHeader)
            : base(i_MenuItemHeader)
        {
            r_SubMenuItems = new Dictionary<int, MenuItem>();
            HasAncestorMenu = false;
            setBackOrExitItem();
        }

        public Menu(string i_MenuItemHeader, bool i_HasAncestorMenu)
            : base(i_MenuItemHeader)
        {
            r_SubMenuItems = new Dictionary<int, MenuItem>();
            HasAncestorMenu = i_HasAncestorMenu;
            setBackOrExitItem();
        }

        private void setBackOrExitItem()
        {
            r_SubMenuItems.Add(r_SubMenuItems.Count, HasAncestorMenu ? new MenuItem(eBackOrExit.Back.ToString()) : new MenuItem(eBackOrExit.Exit.ToString()));
        }

        public void AddNewItemToSubMenu(MenuItem i_NewMenuItem)
        {
            r_SubMenuItems.Add(r_SubMenuItems.Count, i_NewMenuItem);
        }

        public void Show()
        {
            bool exitOrBack = false;
            while (!exitOrBack)
            {
                printCurrentMenu();
                int numOfItemUserChose = getUserInput();
                Console.Clear();

                if (r_SubMenuItems[numOfItemUserChose] is Menu)
                {
                    ((Menu)r_SubMenuItems[numOfItemUserChose]).Show();
                }
                else if (r_SubMenuItems[numOfItemUserChose] is FunctionalMenuItem)
                {

                    ((FunctionalMenuItem)r_SubMenuItems[numOfItemUserChose]).DoWhenOperate();
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
            foreach (KeyValuePair<int, MenuItem> item in r_SubMenuItems)
            {
                if (item.Key != 0)
                {
                    Console.WriteLine(string.Format("{0} -> {1}", item.Key, item.Value.MenuItemHeader));
                }
            }

            Console.WriteLine(string.Format("{0} -> {1}", r_SubMenuItems.ElementAt(0).Key, r_SubMenuItems.ElementAt(0).Value.MenuItemHeader));
            Console.WriteLine(string.Format("Enter your choice:[1,2 or 0 to {0}]", r_SubMenuItems[0].MenuItemHeader));

        }

        private int getUserInput()
        {
            int userChoice = -1;
            while (!int.TryParse(Console.ReadLine(), out userChoice) || !r_SubMenuItems.ContainsKey(userChoice))
            {
                Console.WriteLine("Wrong Input");
            }

            return userChoice;
        }
    }

}