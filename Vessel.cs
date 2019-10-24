using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST_JSON_App
{
    [DataContract]

    public class Vessels
    {
        [DataMember]
        public string MMSI { get; set; }

        [DataMember]
        public string IMO { get; set; }

        [DataMember]
        public string shipName { get; set; }

        [DataMember]
        public string callSign { get; set; }

        [DataMember]
        public string flag { get; set; }

        [DataMember]
        public string vesselType { get; set; }

        [DataMember]
        public int grossTonnage { get; set; }

        [DataMember]
        public int deadweight { get; set; }

        [DataMember]
        public DateTime dateBuilt { get; set; }

        [DataMember]
        public bool isActiveService { get; set; }
    }
}