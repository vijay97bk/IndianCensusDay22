using NUnit.Framework;
using IndianCensusDay22;

namespace TestProject1
{
    public class Tests
    {
        string folderPath = @"C:\Users\Vijay Kshirasagar\Desktop\C# Work\CORE\IndianCensusDay22\CSV";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string validExtensionFileStateCode = "IndiaStateCode.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCode.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        string invalidHeaderStateCode = "WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        /// <summary>
        /// TC1.1-All data in Indian state Info. is load in the file or not
        /// </summary>
        [Test]
        public void GivenCSVFile_TestIfRecordsAreSame()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC1.2:-Check Given file is exist or not
        /// </summary>
        [Test]
        public void GivenIncorrectFileName_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "A", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CustomExceptions.ExceptionType.FILE_NOT_EXISTS, Exception.type);
        }

        /// <summary>
        /// TC1.3-Check Given filename contains proper extention or not
        /// </summary>
        [Test]
        public void GivenIncorrectType_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CustomExceptions.ExceptionType.WRONG_EXTENSION, Exception.type);
        }

        /// <summary>
        /// TC1.4:-Check wheather proper delimeter is used or not
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CustomExceptions.ExceptionType.DELIMITER_NOT_FOUND, Exception.type);
        }
        /// <summary>
        /// TC1.5:-Check header is correct or not
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CustomExceptions.ExceptionType.INCORRECT_HEADER, Exception.type);
        }

        //UC2.1 Check number of records are same.
        [Test]
        public void GivenStateCodeCSVFile_TestIfRecordsAreSame()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validExtensionFileStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyser.datamap.Count);
        }
        //UC2.2
        [Test]
        public void GivenStateCodeIncorrectFileName_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + validExtensionFileStateCode + "hi", "SrNo, State Name, TIN, StateCode"));
            Assert.AreEqual(CustomExceptions.ExceptionType.FILE_NOT_EXISTS, Exception.type);
        }

        //UC2.3
        [Test]
        public void GivenStateCodeIncorrectType_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CustomExceptions.ExceptionType.WRONG_EXTENSION, Exception.type);
        }

        //UC2.4
        [Test]
        public void GivenStateCodeIncorrectDelimiter_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CustomExceptions.ExceptionType.DELIMITER_NOT_FOUND, Exception.type);
        }
        //UC2.5
        [Test]
        public void GivenStateCodeIncorrectHeader_ReturnsCustomException()
        {
            CustomExceptions Exception = Assert.Throws<CustomExceptions>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CustomExceptions.ExceptionType.INCORRECT_HEADER, Exception.type);
        }

    }
}