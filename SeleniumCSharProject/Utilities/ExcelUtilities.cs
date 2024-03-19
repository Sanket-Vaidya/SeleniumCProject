using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;



namespace OrangeHRM_Test.Utilities
{
    public class ExcelUtilities
    {
 
        public static string [,] ReadExcel(string filePath)
        {

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range range;
            string str;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;
            xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
            string[,] data = new string[rw - 1, cl];
            for (rCnt = 2; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    Console.WriteLine(str);
                    data[rCnt-2, cCnt-1] = str;
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            return data;
        }


    }
}
