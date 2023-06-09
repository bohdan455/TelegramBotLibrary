using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TelegramBotLibrary.Models
{
    public class Response<T> where T : class
    {
        [JsonPropertyName("ok")]
        public bool Ok { get; set; }
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}
