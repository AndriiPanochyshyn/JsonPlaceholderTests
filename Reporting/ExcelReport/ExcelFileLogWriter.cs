using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Reporting.ExcelReport
{
    internal class ExcelFileLogWriter
    {
        private const string WorksheetName = "Tests";
        private readonly string[] _smokeTestsWorksheetHeaders = { "#", "Result", "Test name", "Error" };
        private readonly ExcelAdapter _adapter;
        private const int InitialRowNumber = 2;
        private int _rowNumber = InitialRowNumber;

        public ExcelFileLogWriter()
        {
            _adapter = new ExcelAdapter();
            _adapter.AddWorksheet(WorksheetName);

            for (int i = 0; i < _smokeTestsWorksheetHeaders.Length; i++)
            {
                _adapter.SetCellValue(WorksheetName, 1, i + 1, _smokeTestsWorksheetHeaders[i]);
                _adapter.SetCellFontStyle(WorksheetName, 1, i + 1, true, false);
                _adapter.SetCellBackgroundColor(WorksheetName, 1, i + 1, Color.SlateGray);
            }
        }

        public void AddTestsResults(List<LogEntry> entries)
        {
            foreach (var entry in entries)
            {
                bool passed = entry.Result == TestState.Pass;

                _adapter.SetCellValue(WorksheetName, _rowNumber, 1, _rowNumber - InitialRowNumber + 1);
                _adapter.SetCellValue(WorksheetName, _rowNumber, 2, entry.Result);
                _adapter.SetCellBackgroundColor(WorksheetName, _rowNumber, 2, passed ? Color.Green : Color.Red);
                _adapter.SetCellValue(WorksheetName, _rowNumber, 3, entry.TestName);
                _adapter.SetCellValue(WorksheetName, _rowNumber, 4, entry.Error);
                _rowNumber++;
            }
        }

        public void SaveFile()
        {
            var fileName = $"Tests_{DateTime.Now:dd-MM-yyyy_HH.mm.ss}.xlsx";
            var file = Path.Combine(TestContext.CurrentContext.WorkDirectory, fileName);

            _adapter.SaveToFile(file);
            _adapter.AutoFit(file);
        }
    }
}
