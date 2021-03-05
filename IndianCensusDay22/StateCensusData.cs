using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusDay22
{
    /// <summary>
    /// Adding all dataheader in Indian state census Data  and state code data
    /// </summary>
    public class StateCensusData
    {
        string state;
        int population;
        int area;
        int density;
        int serialNumber;
        string stateName;
        int tin;
        string stateCode;


        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusData"/> class.
        /// </summary>


        public StateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
        public StateCensusData(StateCode censusStateCode)
        {
            this.stateName = censusStateCode.stateName;
            this.serialNumber = censusStateCode.serialNumber;
            this.tin = censusStateCode.tin;
            this.stateCode = censusStateCode.stateCode;
        }
    }
}
