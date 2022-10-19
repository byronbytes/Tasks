/*
ByronNotifCore v0.1 - @byronbytes 2022
An easier way to prompt custom notifications with WinForms. Currently supports default messageboxes, balloontips, and custom messageboxes.
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
     
       private string notifTitle;
       private string notifDescription;
       private int notifButtons;
       private int notifIcon;
          
          
       public Notification(string title, string description, int buttons, int icon)
       {
        notifTitle = title;
        notifDescription = description;
        notifButtons = buttons;
        notifIcon = icon;
       }

       public Notification(string title, string description)
       {
        notifTitle = title;
        notifDescription = description;
       }
        
       // Needs debugging.
       public static void DisplayNotification()
       {
            MessageBox.Show(notifTitle, notifDescription);
       }
          
       public static string GetNotificationTitle()
       {
            return notifTitle;
       }
          
       public static string GetNotificationDescription()
       {
            return notifDescription;
       }
         
    }
}
