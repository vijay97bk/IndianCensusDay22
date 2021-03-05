using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianCensusDay22
{
    public class CensusAnalyser
    {
        public Dictionary<string, StateCensusData> datamap;

        /// <summary>
        /// Loads the census data.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="Dictionary<string, StateCensusData>"></exception>
        public Dictionary<string, StateCensusData> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, StateCensusData>();
            // Check file is exist or not 
            if (!File.Exists(csvFilePath))
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.FILE_NOT_EXISTS, "File does not exists");
            }
            //Check file extention is proper or not
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.IMPROPER_EXTENSION, "Improper file extension");
            }

            //Check data header is correct or not
            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.INCORRECT_HEADER, "Incorrect Header ");
            }
            //Check for delimiter is available or not for this skipping header check all the data
            foreach (string row in censusData.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CustomExceptions(CustomExceptions.ExceptionType.DELIMITER_NOT_FOUND, "Delimiter not found");
                }
                string[] column = row.Split(',');
                if (csvFilePath.Contains("StateCode"))
                    datamap.Add(column[0], new StateCensusData(new StateCode(column[0], column[1], column[2], column[3])));
                else
                    datamap.Add(column[0], new StateCensusData(column[0], column[1], column[2], column[3]));
            }
            return datamap;
        }
    }
}
