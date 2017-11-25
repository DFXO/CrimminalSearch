using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NationalCriminal.Search.DataContracts
{
    [DataContract]
    public enum Sex
    {
        [EnumMember] Male,
        [EnumMember] Female,
        [EnumMember] Other
    }
}
