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
            if (!File.Exists(csvFilePath))//Check file exist
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.FILE_NOT_EXISTS, "File does not exists");
            }
            if (Path.GetExtension(csvFilePath) != ".csv")//this method gets extension of file and we are checking if it is .csv or not 
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.WRONG_EXTENSION, "wrong file extension");
            }
            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)//Checking first line is same or not (Headers)
            {
                throw new CustomExceptions(CustomExceptions.ExceptionType.INCORRECT_HEADER, "Incorrect Header ");
            }
           
            foreach (string row in censusData.Skip(1))
            {
                if (!row.Contains(","))//Check data is seperated with "," or not
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
