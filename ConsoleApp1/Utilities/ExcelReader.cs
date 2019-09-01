using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utilities
{
    class ExcelReader
    {
        public static void PopulateInCollection(string sheetname, string filename = "C:\\Users\\lavan\\Desktop\\LavanyaIC\\TurnUpPortalTestData.xlsx")
        {
            ExcelLib.PopulateInCollection(filename, sheetname);
        }

        public static string ReadData(int rownumber, string colname)
        {
            return ExcelLib.ReadData(rownumber, colname);
        }
    }
}
