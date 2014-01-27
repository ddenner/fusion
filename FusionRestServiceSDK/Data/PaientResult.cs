using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FusionRestServiceSDK.Data
{
    public class PatientResult : Patient
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        new public static PatientResult Parse(string parse)
        {
            if (string.IsNullOrEmpty(parse))
                return null;

            return JsonConvert.DeserializeObject<PatientResult>(parse);
        }

        public override string ToString()
        {
            var ser = new DataContractJsonSerializer(typeof(PatientResult));

            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, this);
                var json = Encoding.Default.GetString(ms.ToArray());
                ms.Close();
                return json;
            }
        }
    }
}
