using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Common
{
    public class GeolocationPosition
    {
        public GeolocationCoordinates Coords { get; set; } = new GeolocationCoordinates();
    }

    public class GeolocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Accuracy { get; set; }
    }
    public class OpenCageResponse
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public Components Components { get; set; }
    }

    public class Components
    {
        public string City { get; set; }
        public string Town { get; set; }
        public string Village { get; set; }
        public string Municipality { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string state_district { get; set; }
    }
}
