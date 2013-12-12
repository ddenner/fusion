using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using FusionRestService.Contracts;
using FusionRestService.Contracts.Mapper;
using FusionRestService.FaultDetection;

namespace FusionRestService.Mapper
{
    /// <summary>
    /// returns lat/long for a given address
    /// </summary>
    public class GeographyMapper : IGeographyMapper
    {
        public Contracts.GoogleGeocodingResponse Geocode(string address)
        {
            var r = RetryPolicyFactory.MakeHttpRetryPolicy();

            return r.ExecuteAction(() =>
            {
                using (var wc = new WebClient())
                {
                    string uri =
                        string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false",
                            address);
                    var response = wc.DownloadString(uri);
                    if (!string.IsNullOrEmpty(response))
                        return GoogleGeocodingResponse.Parse(response);
                    else
                        return null;
                }
            });
        }
    }
}