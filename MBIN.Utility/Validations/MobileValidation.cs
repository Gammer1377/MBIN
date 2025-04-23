using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBIN.Utility.Validations
{
    public class MobileValidation:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string val=value as string;
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            if (val.Length!=11)
            {
                return false;
            }
            if (!val.StartsWith("09"))
            {
                return false;
            }
            return true;
        }
    }
}
