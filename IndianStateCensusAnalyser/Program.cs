namespace IndianStateCensusAnalyser
{
    internal class Program
    {
        public static string filePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusData.csv";
        public static string filePath1 = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCode.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian State Census Analyser Program.");
            CsvStateCensus csvStateCensus = new CsvStateCensus();
            csvStateCensus.ReadStateCensusData(filePath);
            CsvStateCode csvStateCode = new CsvStateCode();
            csvStateCode.ReadStateCodeData(filePath1);
        }
    }
}