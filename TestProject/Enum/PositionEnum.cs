using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestProject.Enum
{
    public class PositionEnum
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Position
        {
            [EnumMember(Value = "PM")]
            PM,
            [EnumMember(Value = "QA")]
            QA,
            [EnumMember(Value = "Developer")]
            Developer,
            [EnumMember(Value = "Other")]
            Other
        }
    }
}