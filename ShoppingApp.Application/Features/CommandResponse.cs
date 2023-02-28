using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingApp.Application.Features
{
    public class CommandResponse
    {
        public bool IsSuccess { get; set; }
        public JObject? SuccessReturn { get; set; }
        public string Error { get; set; }
    }
}
