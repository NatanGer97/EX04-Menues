namespace Ex04.Menus.Delegates
{
    public delegate void OperateFunctionalMenuItemDelegate();

    public class FunctionalMenuItem : MenuItem
    {
        /* public event OperationDelagate OpertionToPerform;*/
        private OperateFunctionalMenuItemDelegate m_FunctionalMenuItemDelegate;

        public void AttachObserver(OperateFunctionalMenuItemDelegate i_ObserverDelegate)
        {
            m_FunctionalMenuItemDelegate += i_ObserverDelegate;
        }

        public void DoWhenOperate()
        {
            notifyOperetionalObservers();
        }

        private void notifyOperetionalObservers()
        {
            if (m_FunctionalMenuItemDelegate != null)
            {
                m_FunctionalMenuItemDelegate.Invoke();
            }
        }

        public FunctionalMenuItem(string i_MenuItemHeader)
            : base(i_MenuItemHeader)
        {
        }
    }
}