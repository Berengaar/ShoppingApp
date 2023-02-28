using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Features
{
    public class BaseCommandRequest
    {
        [JsonIgnore]
        public int? UserId { get; set; } = 0;
    }
}
