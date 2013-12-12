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
    public class Patient
    {
        public Guid Id { get; set; }
        public int Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public static Patient Parse(string parse)
        {
            if (string.IsNullOrEmpty(parse))
                return null;

            return JsonConvert.DeserializeObject<Patient>(parse);
        }

        public override string ToString()
        {
            var ser = new DataContractJsonSerializer(typeof(Patient));

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
