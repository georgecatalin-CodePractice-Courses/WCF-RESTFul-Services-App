using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_REST_JSON_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFleetService" in both code and config file together.
    [ServiceContract]
    public interface IFleetService
    {
        // Insert records POST HTTP verb
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddShip/{mmsi}/{imo}/{shipName}/{callSign}/{flag}/{vesselType}/{grossTonnage}/{deadweight}/{dateBuilt}/{isActive}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        void addShip(string mmsi, string imo, string shipName, string callSign, string flag, string vesselType, string grossTonnage, string deadWeight, string dateBuilt, string isActive);

        // Get all records GET HTTP verb
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Ships/")]
        List<Vessels> getAllShips();

        // Get record by Id GET HTTP verb
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Ships/{shipId}")]
        Vessels getVesselById(string shipId);

        // Update records  PUT HTTP verb
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "UpdateShip/{mmsi}/{imo}/{shipName}/{callSign}/{flag}/{vesselType}/{grossTonnage}/{deadweight}/{dateBuilt}/{isActive}",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        void updateShip(string mmsi, string imo, string shipName, string callSign, string flag, string vesselType, string grossTonnage, string deadWeight, string dateBuilt, string isActive);

        // Delete records DELETE HTTP verb
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "RemoveShip/{shipId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void removeShip(string shipId);



    }


}
