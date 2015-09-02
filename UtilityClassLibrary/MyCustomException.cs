using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class MyCustomException
    {
        public MyCustomException(string errorInfo, string errorDetail)
        {
            ErrorDetail = errorDetail;
            ErrorInfo = errorInfo;
        }

        public string ErrorInfo { get; set; }

        public string ErrorDetail { get; set; }
    }
}
