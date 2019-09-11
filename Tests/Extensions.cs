using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests
{
    public static class Extensions
    {
        public static List<string> ToList(this Table table)
        {
            return table.Rows.Select(x => x.Values.FirstOrDefault()).ToList();
        }
    }
}
