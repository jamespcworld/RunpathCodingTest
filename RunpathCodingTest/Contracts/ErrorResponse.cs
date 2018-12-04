using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Contracts
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }

        public ErrorResponse()
        { }

        public ErrorResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
