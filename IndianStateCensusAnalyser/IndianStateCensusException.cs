﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser
{
    public class IndianStateCensusException : Exception
    {
        public enum IndianStateExceptionType
        {
            CSV_FILE_IS_INCORRECT
        }
        public IndianStateExceptionType indianStateExceptionType;
        public IndianStateCensusException(IndianStateExceptionType indianStateExceptionType, string message) : base(message)
        {
            this.indianStateExceptionType = indianStateExceptionType;
        }
    }
}
