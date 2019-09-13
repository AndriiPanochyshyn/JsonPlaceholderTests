using System;
using System.IO;
using OfficeOpenXml;
using System.Drawing;

namespace Reporting.ExcelReport
{
    public class ExcelAdapter : IDisposable
    {
        readonly ExcelPackage _excelPkg = new ExcelPackage();

        private ExcelWorksheet Worksheet(string name)
        {
            return _excelPkg.Workbook.Worksheets[name];
        }

        public void Dispose()
        {
            _excelPkg.Dispose();
        }

        public void AddWorksheet(string name)
        {
            _excelPkg.Workbook.Worksheets.Add(name);
        }

        public void AutoFit(string fileName)
        {
            foreach (var worksheet in _excelPkg.Workbook.Worksheets)
            {
                var start = worksheet.Dimension.Start;
                var end = worksheet.Dimension.End;
                for (int column = start.Column; column <= end.Column; column++)
                {
                    var excelWrksht = Worksheet(worksheet.Name);
                    excelWrksht.Column(column).AutoFit();
                }
            }
            SaveToFile(fileName);
        }

        public void SetCellValue(string worksheetName, int row, int col, object value)
        {
            ExcelWorksheet excelWrksht = Worksheet(worksheetName);
            excelWrksht.Cells[row, col].Value = value;
            if (null != value)
            {
                double proposedCellSize = value.ToString().Trim().Length * 1.5;
                if (value is DateTime)
                {
                    OfficeOpenXml.Style.ExcelStyle style = excelWrksht.Cells[row, col].Style;
                    style.Numberformat.Format = "dd.MM.yyyy";
                    proposedCellSize = ((DateTime)value).ToString("dd.MM.yyyy").Trim().Length * 1.5;
                }
                double cellSize = excelWrksht.Cells[row, col].Worksheet.Column(col).Width;
                if (cellSize <= proposedCellSize)
                {
                    excelWrksht.Cells[row, col].Worksheet.Column(col).Width = proposedCellSize;
                }
            }
        }

        public void SetCellFontStyle(string worksheetName, int row, int col, bool bold, bool italic)
        {
            ExcelWorksheet excelWrksht = Worksheet(worksheetName);
            OfficeOpenXml.Style.ExcelStyle style = excelWrksht.Cells[row, col].Style;
            style.Font.Bold = bold;
            style.Font.Italic = italic;
        }

        public void SetCellBackgroundColor(string worksheetName, int row, int col, Color color)
        {
            ExcelWorksheet excelWrksht = Worksheet(worksheetName);
            OfficeOpenXml.Style.ExcelStyle style = excelWrksht.Cells[row, col].Style;
            style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            style.Fill.BackgroundColor.SetColor(color);
        }

        public void SaveToFile(string fileName)
        {
            _excelPkg.File = new FileInfo(fileName);
            _excelPkg.Save();
        }
    }
}
