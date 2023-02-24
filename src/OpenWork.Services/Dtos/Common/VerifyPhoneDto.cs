using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWork.Services.Dtos.Common
{
    public class VerifyPhoneDto
    {
        public string Phone { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
    }
}
