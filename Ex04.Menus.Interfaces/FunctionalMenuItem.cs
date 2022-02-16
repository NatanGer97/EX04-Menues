using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IFunctionalItem
    {
        void Operate();
    }
    public class FunctionalMenuItem : MenuItem
    {
        private List<IFunctionalItem> m_ObserversList;
        public FunctionalMenuItem(string i_MenuItemHeader)
            : base(i_MenuItemHeader)
        {
            m_ObserversList = new List<IFunctionalItem>();
        }

        public void AddObserver(IFunctionalItem i_FunctionalItem)
        {
            m_ObserversList.Add(i_FunctionalItem);
        }

        public void DoWhenOperate()
        {
            notifyObservers();

        }

        private void notifyObservers()
        {
            if(m_ObserversList != null)
            {
                foreach(IFunctionalItem item in m_ObserversList)
                {
                    item.Operate();
                }
            }
        }

       
    }
}