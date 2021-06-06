using System;

namespace Ex04.Menus.Delegates
{
    public class MenuAction<T>
    {
        public delegate string ActionDelegate();
        public delegate Menu MenuDelegate(T obj);
        public delegate bool VerifyDelegate(T obj);

        private MenuDelegate m_MenuAction = delegate { throw new NotImplementedException(); };
        private VerifyDelegate m_Verify = delegate { return true; };
        public ActionDelegate m_Description = delegate { return "";};
        public ActionDelegate m_Requirements = delegate { return "";};

        private readonly string m_Name;
        private Type m_Type = typeof(T);
        

        public MenuAction(MenuDelegate i_MenuAction, string i_Name, VerifyDelegate i_Verify, ActionDelegate i_Description )
        {
            this.m_MenuAction = i_MenuAction;
            this.m_Name = i_Name;
            ActionDelegate m_Description = i_Description;
            VerifyDelegate m_Verify = i_Verify;
        }
        
        public string Name {
            get { return this.m_Name;}
        }

        public MenuDelegate Action
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
        
        public ActionDelegate Description
        {
            get { return this.m_Description; }
        }
    }
}