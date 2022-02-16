using System.Security;

namespace Ex04.Menus.Interfaces
{
    public  class MenuItem
    {
        private string m_MenuItemHeader;

        public string MenuItemHeader
        {
            get
            {
                return m_MenuItemHeader;
            }
            set
            {
                m_MenuItemHeader = value;
            }
        }

        public MenuItem(string i_MenuItemHeader)
        {
            MenuItemHeader = i_MenuItemHeader;
        }
    }
}