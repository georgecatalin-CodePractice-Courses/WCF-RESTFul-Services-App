using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_REST_JSON_App
{
   
    public class FleetService : IFleetService
    {
        public void addShip(string mmsi, string imo, string shipName, string callSign, string flag, string vesselType, string grossTonnage, string deadWeight, string dateBuilt, string isActive)
        {
            DatabaseHelper dh = new DatabaseHelper();
            dh.insertShipInDatabase(mmsi, imo, shipName, callSign, flag, vesselType, int.Parse(grossTonnage), int.Parse(deadWeight), DateTime.Parse(dateBuilt), bool.Parse(isActive));
        }

        public List<Vessels> getAllShips()
        {
            List<Vessels> myList;

            DatabaseHelper dh = new DatabaseHelper();
            myList=dh.getAllShipsWithDetails();

            return myList;
        }

        public Vessels getVesselById(string shipId)
        {
            Vessels myShip;

            DatabaseHelper dh = new DatabaseHelper();
            myShip = dh.getAllShipsWithDetails_By_ShipID(shipId);
            return myShip;
        }

        public void removeShip(string shipId)
        {
            DatabaseHelper dh = new DatabaseHelper();
            dh.deleteExistingVesselInDatabase(shipId);
        }

        public void updateShip(string mmsi, string imo, string shipName, string callSign, string flag, string vesselType, string grossTonnage, string deadWeight, string dateBuilt, string isActive)
        {
            DatabaseHelper dh = new DatabaseHelper();
            dh.updateExistingShipInDatabase(imo, mmsi, shipName, callSign, flag, vesselType, int.Parse(grossTonnage), int.Parse(deadWeight), DateTime.Parse(dateBuilt), bool.Parse(isActive));
        }
    }
}
