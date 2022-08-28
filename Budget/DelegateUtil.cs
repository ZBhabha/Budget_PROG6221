using System;
using System.Collections.Generic;
using System.Text;

namespace Budget
{
    // code attribution
    //Delegates learnt and adapted from  youtube video
    //Author: VCSOIT
    //Link:https://youtu.be/MFjlDbn7P8k
    class DelegateUtil
    {  //delegate and event declared
        public delegate void NotifyUserDelegate();
        public event NotifyUserDelegate ExpensesViewed;
        
        public void NotifyUser()
        {
            Helper h = new Helper();
            //warning method subscribed to event
            ExpensesViewed += h.Warning;
            OnExpensesViewed();
        }

        protected virtual void OnExpensesViewed()
        {
            if (ExpensesViewed != null)
            {
                ExpensesViewed();
            }
        }
    }
}
