namespace IndianStateCensusAnalyser
{
    internal class Program
    {
        public static string filePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusData.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian State Census Analyser Program.");
            CsvStateCensus csvStateCensus = new CsvStateCensus();
            csvStateCensus.ReadStateCensusData(filePath);
        }
    }
}