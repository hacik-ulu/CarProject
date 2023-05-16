using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        // base -- Result
        public SuccessResult(string message) : base(true)
        {

        }

        public SuccessResult():base(true)
        {
            
        }
    }
}
