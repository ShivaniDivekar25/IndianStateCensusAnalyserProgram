using IndianStateCensusAnalyser;

namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string path = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusData.csv";
        public static string incorrectStatePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StatesCensusData.csv";
        StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
        CsvStateCensus csvState = new CsvStateCensus();
        [Test]
        public void GivenStateCensusData_ShouldMatchNumbersOfRetrunMatches()
        {
            Assert.AreEqual(stateCensusAnalyser.ReadStateCensusData(path),csvState.ReadStateCensusData(path));
        }
        [Test]
        public void GivenIncorrectCSVFilePath_ShouldReturnCustomException()
        {
            try
            {
                int record = stateCensusAnalyser.ReadStateCensusData(incorrectStatePath);
            }
            catch (IndianStateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect file path");
            }
        }
    }
}