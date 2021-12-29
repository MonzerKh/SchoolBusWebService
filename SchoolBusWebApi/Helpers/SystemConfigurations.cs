using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Helpers
{
    public class SystemConfigurations
    {
        public static byte[] FromBase64String(string inputString)
        {
            inputString = inputString.Replace("data:image/jpeg;base64,", "");
            if (!string.IsNullOrEmpty(inputString))
            {
                return Convert.FromBase64String(inputString);
            }
            return null;
        }

       




    }
}
