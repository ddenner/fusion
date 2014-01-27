using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionRestService.Contracts.Mapper
{
    public interface IGeographyMapper
    {
        GoogleGeocodingResponse Geocode(string address);
    }
}
