using System;

namespace Ex04.Menus.Delegates
{
    public class MenuAction<T>
    {
        public delegate string ActionDelegate();
        public Action<object> m_MenuAction = delegate(object i_Obj) { };
        public delegate bool VerifyDelegate(T obj);

        private VerifyDelegate m_Verify = delegate { return true; };
        public ActionDelegate m_Requirements = delegate { return "";};

        private Type m_Type = typeof(T);

        public MenuAction(Action<object> i_MenuAction, VerifyDelegate i_Verify, string i_Description )
        {
            this.m_MenuAction = i_MenuAction;
            this.m_Verify = i_Verify;
        }
        
        public MenuAction(Action<object> i_MenuAction, VerifyDelegate i_Verify )
        {
            this.m_MenuAction = i_MenuAction;
            this.m_Verify = i_Verify;
        }
        
        public MenuAction(Action<object> i_MenuAction )
        {
            this.m_MenuAction = i_MenuAction;
        }

        public Action<object> Action
        {
            get { return this.m_MenuAction; }
        }

        public Type Type
        {
            get { return this.m_Type; }
        }
        
        public ActionDelegate Requirements
        {
            get { return this.m_Requirements; }
        }
        
        public VerifyDelegate Verify
        {
            get { return this.m_Verify; }
        }
        
    }
}