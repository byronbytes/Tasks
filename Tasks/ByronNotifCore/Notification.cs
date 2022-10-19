/*
ByronNotifCore v0.1
An easier way to prompt custom notifications with WinForms.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ByronNotifCore
{
     class Notification
    {
     
       public string notifTitle;
       public string notifDescription;
       public int notifButtons;
       public int notifIcon;
          
       // WIP - Will improve soon, just a rough draft.
       public string notifType(int type)
       {
            if(type == 1)
            {
                 return "MESSAGEBOX";
            }
            if(type == 2)
            {
                 return  "BALLOONTIP";
            }
       }
          
       public static void SetNotificationInfo(string title, string description, int buttons, int icon)
       {
        notifTitle = title;
        notifDescription = description;
        notifButtons = buttons;
        notifIcon = icon;
       }

       public static void SetNotificationInfo(string title, string description)
       {
        notifTitle = title;
        notifDescription = description;
       }
        
          // debug when i get home
       public static void DisplayNotification()
       {
            MessageBox.Show(notifTitle);
       }
         
          
       
    }
}
