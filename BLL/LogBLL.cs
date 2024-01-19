using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogBLL
    {
        public static void AddLog(int ProcessType,string TableName, int ProcessID)
        {
            LogDAO.AddLog(ProcessType, TableName, ProcessID);
        }
    }
}
