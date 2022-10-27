using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace UI
{
    public static class TableVisualization
    {
        internal static void ShowTable<T>(List<T> tableData, string tableName = "") where T : class
        {
            List<string> data = new List<string>();
            foreach (var item in tableData)
            {
                foreach (var i in item.GetType().GetProperties())
                {
                    var props = i.Name;
                    data.Add(props);
                }
                break;
            }

            Console.Clear();
            ConsoleTableBuilder.From(tableData).WithColumn(data).ExportAndWriteLine();
        }
    }
}
