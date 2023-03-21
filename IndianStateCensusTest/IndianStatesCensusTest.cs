using IndianStateCensusAnalyser;

namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string path = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusData.csv";
        public static string incorrectStatePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\File\StateCensusData.csv";
        public static string incorrectStateFilePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusData.txt";
        public static string incorrectDelimeterPath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCensusDelimeter.csv";
        public static string stateCodePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StateCode.csv";
        public static string incorrectStateCodePath = @"C:\Users\hp\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\Files\StatesCode.csv";
        StateCensusAnalyser stateCensusAnalyser = new StateCensusAnalyser();
        CsvStateCensus csvState = new CsvStateCensus();
        StateCodeAnalyser stateCodeAnalyser = new StateCodeAnalyser();
        CsvStateCode csvStateCode = new CsvStateCode();
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
        [Test]
        public void GivenIncorrectFileType_ShouldReturnCustomException()
        {
            try
            {
                int record = stateCensusAnalyser.ReadStateCensusData(incorrectStateFilePath);
            }
            catch (IndianStateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "File type is incorrect");
            }
        }
        [Test]
        public void GivenIncorrectFileDelimeter_ShouldReturnCustomException()
        {
            try
            {
                int record = stateCensusAnalyser.ReadStateCensusData(incorrectDelimeterPath);
            }
            catch (IndianStateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter is incorrect");
            }
        }
        [Test]
        public void GivenIncorrectHeader_ShouldReturnCustomException()
        {
            try
            {
                bool record = stateCensusAnalyser.ReadStateCensusData(path, "State,Population,AreaInSqKm,DensityPerSqKm\r\n");
                Assert.IsTrue(record);
            }
            catch (IndianStateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Header is incorrect");
            }
        }
        [Test]
        public void GivenStateCodeData_ShouldMatchNumbersOfRetrunMatches()
        {
            Assert.AreEqual(stateCodeAnalyser.ReadStateCodeData(stateCodePath), csvStateCode.ReadStateCodeData(stateCodePath));
        }
        [Test]
        public void GivenIncorrectStateCodeCSVFilePath_ShouldReturnCustomException()
        {
            try
            {
                int record = stateCodeAnalyser.ReadStateCodeData(incorrectStateCodePath);
            }
            catch (IndianStateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect state code file path");
            }
        }
    }
}