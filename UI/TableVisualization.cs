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
            List<string> propNames = TableNames();
            Console.Clear();
            ConsoleTableBuilder.From(tableData).WithColumn(propNames).ExportAndWriteLine();
        }

        private static List<string> TableNames()
        {
            var exercise = new Exercise();
            List<string> props = new List<string>();

            foreach (var item in exercise.GetType().GetProperties())
            {
                props.Add(item.Name);
            }
            return props;
        }
    }
}
