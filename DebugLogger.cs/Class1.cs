using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace DebugLogger
{

    public class CDebugLogger
    {
        static public string __FUNCTION__
        {
            get {
                return System.Reflection.MethodBase.GetCurrentMethod().Name;
            }
        }

        static public void DEBUG_LOG(string logMsg)
        {
            Debug.WriteLine(__FUNCTION__ + logMsg);
        }
    }
}
