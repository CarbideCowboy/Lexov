using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models
{
    public class BaseResponse
    {
        public int[] ErrorCodes { get; set; }
        public string ErrorTextAdditional { get; set; }
        public bool IsError => String.IsNullOrWhiteSpace(ErrorTextAdditional) == false;
        public string ErrorMessage
        {
            get
            {
                if(String.IsNullOrWhiteSpace(ErrorTextAdditional) == false)
                {
                    return ErrorTextAdditional;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
