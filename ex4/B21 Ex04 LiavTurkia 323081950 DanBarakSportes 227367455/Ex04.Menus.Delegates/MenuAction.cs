using System;

namespace Ex04.Menus.Delegates
{
    public class MenuAction<T>
    {
        private readonly VerifyDelegate r_Verify = obj => { return true; };
        private readonly Type r_Type = typeof(T);
        private readonly Action<object> r_MenuAction = i_Obj => { };
        private readonly ActionDelegate r_Requirements = () => { return string.Empty; };

        public delegate bool VerifyDelegate(T obj);

        public delegate string ActionDelegate();

        public MenuAction(Action<object> i_MenuAction, VerifyDelegate i_Verify, ActionDelegate i_Requirements)
        {
            this.r_MenuAction = i_MenuAction;
            this.r_Verify = i_Verify;
            this.r_Requirements = i_Requirements;
        }

        public MenuAction(Action<object> i_MenuAction, VerifyDelegate i_Verify)
        {
            this.r_MenuAction = i_MenuAction;
            this.r_Verify = i_Verify;
        }

        public MenuAction(Action<object> i_MenuAction)
        {
            this.r_MenuAction = i_MenuAction;
        }

        public Action<object> Action
        {
            get { return this.r_MenuAction; }
        }

        public Type Type
        {
            get { return this.r_Type; }
        }

        public ActionDelegate Requirements
        {
            get { return this.r_Requirements; }
        }

        public VerifyDelegate Verify
        {
            get { return this.r_Verify; }
        }
    }
}