using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utilities
{
    class ExcelReader
    { 
        
        public static void PopulateInCollection(string sheetname, string filename = null)
        {
            if(filename == null)
            {
                filename = AppDomain.CurrentDomain.BaseDirectory.Replace(@"ConsoleApp1\bin\Debug\","TurnUpPortalTestData.xlsx").Replace(@"\", @"\\");
            }
            ExcelLib.PopulateInCollection(filename, sheetname);
        }

        public static string ReadData(int rownumber, string colname)
        {
            return ExcelLib.ReadData(rownumber, colname);
        }
    }
}
