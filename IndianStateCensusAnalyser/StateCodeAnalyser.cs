using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class StateCodeAnalyser
    {
        public int ReadStateCodeData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.CSV_CODE_FILE_IS_INCORRECT, "Incorrect state code file path");
            }
            if (!filePath.EndsWith(".csv"))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.CODE_FILE_TYPE_INCORRECT, "Incorrect state code file type");
            }
            var csvReader = File.ReadAllLines(filePath);
            string header = csvReader[0];
            if (header.Contains("/"))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.CODE_INCORRECT_DELIMETER, "Incorrect state code delimeter");
            }
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCodeModel>().ToList();
                    foreach (var record in records)
                    {
                        //Console.WriteLine($"{record.SrNo} {record.Name} {record.TIN} {record.StateCode}");
                        Console.WriteLine(record);
                    }
                    return records.Count() - 1;
                }
            }
        }
        public bool ReadStateCodeData(string filePath, string actualHeader)
        {
            var csvReader = File.ReadAllLines(filePath);
            string header = csvReader[0];
            if (header.Equals(actualHeader))
                return true;
            else
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.CODE_INCORRECT_HEADER, "State code header is incorrect");
        }
    }
}
