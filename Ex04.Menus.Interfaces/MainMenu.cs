namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private Menu m_SubMenu;
        private const bool k_HasAncestor = false;

        public MainMenu(string i_MainMenuTitle)
        {
            SubMenu = new Menu(i_MainMenuTitle,k_HasAncestor);
        }

        public void Show()
        {
            SubMenu.Show();
        }

        public Menu SubMenu
        {
            get => m_SubMenu;
            set => m_SubMenu = value;
        }
    }
}