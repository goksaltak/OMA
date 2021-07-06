using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true)
        {
            base.Message = message;
        }
        public SuccessResult():base(true)
        {

        }
    }
}
