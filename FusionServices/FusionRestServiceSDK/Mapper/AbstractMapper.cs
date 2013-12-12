using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FusionRestServiceSDK.Data;
using FusionRestServiceSDK.FaultDetection;

namespace FusionRestServiceSDK.Mapper
{
    public abstract class AbstractMapper
    {
        protected string HttpGet(string uri)
        {
            var r = RetryPolicyFactory.MakeHttpRetryPolicy();

            return r.ExecuteAction(() =>
            {
                using (var wc = new WebClient())
                {
                    var response = wc.DownloadString(uri);
                    if (!string.IsNullOrEmpty(response))
                        return response;
                    else
                        return null;
                }
            });
        }

        protected string HttpPost(string uri, string parameters)
        {
            var r = RetryPolicyFactory.MakeHttpRetryPolicy();

            return r.ExecuteAction(() =>
            {
                using (var wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    return wc.UploadString(uri, parameters);
                }
            });
        }

    }
}
