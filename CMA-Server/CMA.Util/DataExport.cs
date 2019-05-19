using System;
using System.Collections.Generic;
using System.Text;

namespace CMA.Utility
{
    public static class ExportData
    {
        public static byte[] ConvertToCsv(List<object[]> records, string[] columnHeaders)
        {
            var employeecsv = new StringBuilder();
            records.ForEach(line =>
            {
                employeecsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", columnHeaders)}\r\n{employeecsv.ToString()}");

            return buffer;
        }
    }
}
