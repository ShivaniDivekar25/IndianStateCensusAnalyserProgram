using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IndianStateCensusAnalyser
{
    public class CsvStateCode
    {
        public void ReadStateCodeData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCodeModel>().ToList();
                    foreach (var record in records)
                    {
                        Console.WriteLine($"{record.SrNo} {record.Name} {record.TIN} {record.StateCode}");
                    }
                }
            }
        }
    }
}
