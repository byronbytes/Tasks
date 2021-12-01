using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class ErrorHandler
    {
        
        public static void InduceMessageError(int errortype)
        {
            
            if(errortype = 0)
            {
                Debug.Print("Manually induced error.");
            }
            
            if(errortype = 1)
            {
                Debug.Print("Please try running this task as an administrator.")
            }
            
        }
     
    }
}
