using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace timestampMicroservices.src.Models
{
    public class TimeStamp
    {
        public TimeStamp(string? date)
        {
            
            if (date is null)
            {
                this._date = null;
            }
            else
            {
                

                if (DateTime.TryParse(date, out DateTime dataResult))
                {
                    this._date = dataResult;
                }
                else if(long.TryParse(date, out Int64 unixResult)) 
                {
                    this._date = DateTimeOffset.FromUnixTimeMilliseconds(unixResult).DateTime.ToLocalTime();
                }else
                {
                    throw new ArgumentException("Invalid Date");
                }

            }
        }
        private DateTime? _date;
        [JsonPropertyOrder(1)]
        [JsonPropertyName("utc")]
        public string UtcTime
        {
            get { 
                    return this.Date?.ToUniversalTime().ToString("R"); 
                }
            
        }

        [JsonPropertyOrder(0)]
        [JsonPropertyName("unix")]
        
        public long UnixTime{
            get
            {
                return ((DateTimeOffset)Date).ToUnixTimeMilliseconds();
            }
        }

        [JsonIgnore]
        public DateTime? Date
        {
            get { 
                    if (_date is null)
                    {
                        return _date = DateTime.Now;
                    }
                    else
                    {
                        return _date;
                    }
                         
                }
            set { _date = value; }
        }
       
    }
}