using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FusionRestService.Contracts
{
    public class GoogleGeocodingResponse
    {
        public List<GoogleGeocodingResult> results { get; set; }

        public string status { get; set; }

        public static GoogleGeocodingResponse Parse(string parse)
        {
            if (string.IsNullOrEmpty(parse))
                return null;

            return JsonConvert.DeserializeObject<GoogleGeocodingResponse>(parse);
        }
    }

    public class GoogleGeocodingResult
    {
        public List<GoogleGeocodingAddress> address_components { get; set; }
        public string formatted_address { get; set; }
        public GoogleGeocodingGeometry geometry { get; set; }
        public List<string> types { get; set; }
    }

    public class GoogleGeocodingAddress
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class GoogleGeocodingGeometry
    {
        public GoogleGeocodingLatLong location { get; set; }
        public string location_type { get; set; }
        public GoogleGeocodingViewPort viewport { get; set; }
    }

    public class GoogleGeocodingViewPort
    {
        public GoogleGeocodingLatLong northeast { get; set; }
        public GoogleGeocodingLatLong southwest { get; set; }
    }

    public class GoogleGeocodingLatLong
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }
}