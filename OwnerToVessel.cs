using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST_JSON_App
{
    [DataContract]
    public class OwnerToVessel
    {
        [DataMember]
        public string ownerID { get; set; }

        [DataMember]
        public string IMO { get; set; }
    }
}