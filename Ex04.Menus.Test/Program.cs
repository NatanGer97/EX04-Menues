using Ex04.Menus.Interfaces;
using Menu = Ex04.Menus.Delegates.Menu;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu interfaceMainMenu = new MainMenu("Interfaces Main Menu");
            Interfaces.Menu versionAndCapitalsSubMenu = new Interfaces.Menu("Version and Capitals");
            FunctionalMenuItem showVersionMenuItem = new FunctionalMenuItem("Show Version");
            FunctionalMenuItem countCapitalsMenuItem = new FunctionalMenuItem("Count Capitals");
            ShowVersion versionFunction = new ShowVersion();
            CountCapitals countCapitalsFunction = new CountCapitals();
            showVersionMenuItem.AddObserver(versionFunction);
            countCapitalsMenuItem.AddObserver(countCapitalsFunction);
            versionAndCapitalsSubMenu.AddNewItemToSubMenu(showVersionMenuItem);
            versionAndCapitalsSubMenu.AddNewItemToSubMenu(countCapitalsMenuItem);
            interfaceMainMenu.SubMenu.AddNewItemToSubMenu(versionAndCapitalsSubMenu);
            Interfaces.Menu dateOrTimeSubMenu = new Interfaces.Menu("**Show Date/Time**");
            FunctionalMenuItem showDateFunctionalMenuItem = new FunctionalMenuItem("Show Date");
            FunctionalMenuItem showTimeFunctionalMenuItem = new FunctionalMenuItem("Show Time");
            ShowDate showDateFunction = new ShowDate();
            ShowTime showTimeFunction = new ShowTime();
            showDateFunctionalMenuItem.AddObserver(showDateFunction);
            showTimeFunctionalMenuItem.AddObserver(showTimeFunction);
            dateOrTimeSubMenu.AddNewItemToSubMenu(showDateFunctionalMenuItem);
            dateOrTimeSubMenu.AddNewItemToSubMenu(showTimeFunctionalMenuItem);
            interfaceMainMenu.SubMenu.AddNewItemToSubMenu(dateOrTimeSubMenu);
            interfaceMainMenu.Show();


            Delegates.MainMenu DelegateMainMenu = new Delegates.MainMenu("Delegate Main Menu");
            Delegates.Menu versionAndCapitalsDelegates = new Delegates.Menu("Version and Capitals");
            Delegates.Menu dateOrTimeMenuDelegates = new Menu("Show Date/Time");
            Delegates.FunctionalMenuItem ShowVersion = new Delegates.FunctionalMenuItem("Show Version");
            Delegates.FunctionalMenuItem CapitalCount = new Delegates.FunctionalMenuItem("Count Capitals");
            Delegates.FunctionalMenuItem ShowTime = new Delegates.FunctionalMenuItem("Show Time");
            Delegates.FunctionalMenuItem ShowDate = new Delegates.FunctionalMenuItem("Show Date");

            ShowVersion.AttachObserver(versionFunction.Operate);
            CapitalCount.AttachObserver(countCapitalsFunction.Operate);
            ShowDate.AttachObserver(showDateFunction.Operate);
            ShowTime.AttachObserver(showTimeFunction.Operate);
            versionAndCapitalsDelegates.AddNewItemToSubMenu(ShowVersion);
            versionAndCapitalsDelegates.AddNewItemToSubMenu(CapitalCount);
            dateOrTimeMenuDelegates.AddNewItemToSubMenu(ShowDate);
            dateOrTimeMenuDelegates.AddNewItemToSubMenu(ShowTime);
            DelegateMainMenu.SubMenu.AddNewItemToSubMenu(versionAndCapitalsDelegates);
            DelegateMainMenu.SubMenu.AddNewItemToSubMenu(dateOrTimeMenuDelegates);
            DelegateMainMenu.Show();
        }
    }
}