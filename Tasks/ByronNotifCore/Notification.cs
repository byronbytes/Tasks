/*
ByronNotifCore
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
        /*
        Work in progress custom notification library.
        */
       

       public string notifTitle;
       public string notifDescription;
       public int notifButtons;
       public int notifIcon;

        /*
       public enum NotificationType
       {
        MESSAGEBOX,
        BALLOONTIP,
        MODERN;
       }
       */

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

       public static void DisplayNotification()
       {
         
       }
    }
}
