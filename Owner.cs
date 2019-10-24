using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST_JSON_App
{
    [DataContract]
    public class Owner
    {

        [DataMember]
        public string ownerID { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string postalCode { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string website { get; set; }

        [DataMember]
        public string primaryContactID { get; set; }

        [DataMember]
        public string businessPhone { get; set; }

        [DataMember]
        public string businessEmail { get; set; }

        [DataMember]
        public string vatID { get; set; }


    }
}