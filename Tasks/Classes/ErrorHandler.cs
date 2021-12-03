using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class ErrorHandler
    {
        
        public static void InduceMessageError(int errortype)
        {
            
            if(errortype == 0)
            {
                Debug.Print("Manually induced error.");
            }
            
            if(errortype == 1)
            {
                Debug.Print("Please try running the app as an administrator.");
            }
            
            if(errortype == 2)
            {
                Debug.Print("This is currently being used by another program.");   
            }
            
        }
     
    }
}
