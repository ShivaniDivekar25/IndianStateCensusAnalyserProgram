﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public int ReadStateCensusData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.CSV_FILE_IS_INCORRECT, "Incorrect file path");
            }
            if (!filePath.EndsWith(".csv"))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.FILE_TYPE_INCORRECT, "File type is incorrect");
            }
            var csvReader = File.ReadAllLines(filePath);
            string header = csvReader[0];
            if (header.Contains("/"))
            {
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.INCORRECT_DELIMETER, "Delimeter is incorrect");
            }
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCensusModel>().ToList();
                    foreach (var record in records)
                    {
                        //Console.WriteLine($"{record.State} {record.Population} {record.AreaInSqKm} {record.DensityPerSqKm}");
                        Console.WriteLine(reader);
                    }
                    return records.Count() - 1;
                }
            }
        }
        public bool ReadStateCensusData(string filePath,string actualHeader)
        {
            var csvReader = File.ReadAllLines(filePath);
            string header = csvReader[0];
            if (header.Equals(actualHeader))
                return true;
            else
                throw new IndianStateCensusException(IndianStateCensusException.IndianStateExceptionType.INCORRECT_HEADER, "Header is incorrect");
        }
    }
}
