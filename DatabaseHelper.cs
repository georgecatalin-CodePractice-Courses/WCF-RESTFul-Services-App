using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace WCF_REST_JSON_App
{
    public class DatabaseHelper
    {
        private string connString_to_AppDB;

        private string ConnString_to_AppDB
        {
            get { return this.connString_to_AppDB; }
            set { this.connString_to_AppDB = value; }
        }

        public DatabaseHelper()
        {
            this.ConnString_to_AppDB = System.Configuration.ConfigurationManager.ConnectionStrings["connStringAppDB"].ConnectionString;
        }

        #region TODO: implement READ ALL from [dbo].[tblOwners]
        public List<Owner> getAllOwnersWithDetails()
        {
            List<Owner> listOfOwners;
            listOfOwners = null;

            using (SqlConnection con = new SqlConnection(ConnString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetOwners", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfOwners.Add(new Owner
                        {
                            name = reader[0].ToString(),
                            ownerID = reader[1].ToString(),
                            address = reader[2] != null ? reader[2].ToString() : "N/A",
                            city = reader[3] != null ? reader[3].ToString() : "N/A",
                            postalCode = reader[4].ToString(),
                            country = reader[5].ToString(),
                            website = reader[6] != null ? reader[6].ToString() : "N/A",
                            primaryContactID = reader[7] != null ? reader[7].ToString() : "N/A",
                            businessPhone = reader[8] != null ? reader[8].ToString() : "N/A",
                            businessEmail = reader[9] != null ? reader[9].ToString() : "N/A",
                            vatID = reader[10] != null ? reader[10].ToString() : "N/A"
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return listOfOwners;
        }
        #endregion

        #region TODO: implement READ ALL from [dbo].[tblVessels]
        public List<Vessels> getAllShipsWithDetails()
        {
            List<Vessels> listOfShips = new List<Vessels>();
           

            using (SqlConnection con = new SqlConnection(ConnString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetVessels", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfShips.Add(new Vessels
                        {
                            shipName = reader[0] != null ? reader[0].ToString() : "N/A",
                            MMSI = reader[1] != null ? reader[1].ToString() : "N/A",
                            IMO = reader[2] != null ? reader[2].ToString() : "N/A",
                            callSign = reader[3] != null ? reader[3].ToString() : "N/A",
                            flag = reader[4] != null ? reader[4].ToString() : "N/A",
                            vesselType = reader[5] != null ? reader[5].ToString() : "N/A",
                            grossTonnage = reader[6] != null ? int.Parse(reader[6].ToString()) : 0,
                            deadweight = reader[7] != null ? int.Parse(reader[7].ToString()) : 0,
                            dateBuilt = reader[8] != null ? DateTime.Parse(reader[8].ToString()) : DateTime.MinValue,
                            isActiveService = bool.Parse(reader[9].ToString())
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return listOfShips;
        }
        #endregion

        #region TODO: implement READ all records from [dbo].[tblOwnersVessels] that correspond to entered ownerId
        public List<OwnerToVessel> listOfRelationships_OwnerToVessel_By_OwnerId(string ownerId)
        {
            List<OwnerToVessel> listOfRelationshipsOV_o;
            listOfRelationshipsOV_o = null;

            using (SqlConnection con = new SqlConnection(ConnString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetOwnerVesselsRelationshipByOwnerID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ownerID", ownerId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listOfRelationshipsOV_o.Add(new OwnerToVessel
                        {
                            ownerID = reader[0].ToString(),
                            IMO = reader[1].ToString()
                        });

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return listOfRelationshipsOV_o;
        }
        #endregion

        // TODO: implement READ all records from [dbo].[tblOwnersVessels] that correspond to entered shipID
        public List<OwnerToVessel> listOfRelationships_OwnerToVessel_By_VesselId(string shipId)
        {
            List<OwnerToVessel> listOfRelationshipsOV_s;
            listOfRelationshipsOV_s = new List<OwnerToVessel>();

            return listOfRelationshipsOV_s;
        }
        

        // TODO: implement READ record from [dbo].[tblOwners] by ownerID
        public List<Owner> getAllOwnersWithDetails_By_OwnerID(string ownerId)
        {
            List<Owner> listOfOwners;
            listOfOwners = new List<Owner>();

            return listOfOwners;
        }

        // TODO: implement READ record from [dbo].[tblVessels] by shipID (ship's IMO number)
        public Vessels getAllShipsWithDetails_By_ShipID(string shipId)
        {
            Vessels myShip;
            myShip = null;

            using (SqlConnection con = new SqlConnection(ConnString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetVesselDetailByIMO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vesselID", shipId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        myShip = new Vessels {
                            shipName = reader[0] != null ? reader[0].ToString() : "N/A",
                            MMSI = reader[1] != null ? reader[1].ToString() : "N/A",
                            IMO = reader[2] != null ? reader[2].ToString() : "N/A",
                            callSign = reader[3] != null ? reader[3].ToString() : "N/A",
                            flag = reader[4] != null ? reader[4].ToString() : "N/A",
                            vesselType = reader[5] != null ? reader[5].ToString() : "N/A",
                            grossTonnage = reader[6] != null ? int.Parse(reader[6].ToString()) : 0,
                            deadweight = reader[7] != null ? int.Parse(reader[7].ToString()) : 0,
                            dateBuilt = reader[8] != null ? DateTime.Parse(reader[8].ToString()) : DateTime.MinValue,
                            isActiveService = reader[9] != null ? bool.Parse(reader[9].ToString()) : false
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return myShip;
        }

        #region TODO: implement INSERT new record in [dbo].[tblOwners]
        public void insertOwnerInDatabase(Owner newOwner)
        {
            
        }
        #endregion

        #region TODO: implement INSERT new record in [dbo].[tblVessels]
        public void insertShipInDatabase(string mmsi,string imo, string shipName,string callSign, string flag, string vesselType, int grossTonnage, int deadweight, DateTime dateBuilt,bool isActiveService)
        {
            using (SqlConnection con = new SqlConnection(connString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("AddVessel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mmsi", mmsi);
                    cmd.Parameters.AddWithValue("@imo", imo);
                    cmd.Parameters.AddWithValue("@shipName", shipName);
                    cmd.Parameters.AddWithValue("@callSign", callSign);
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@vesselType", vesselType);
                    cmd.Parameters.AddWithValue("@grossTonnage", grossTonnage);
                    cmd.Parameters.AddWithValue("@deadwight", deadweight);
                    cmd.Parameters.AddWithValue("@dateBuilt", dateBuilt);
                    cmd.Parameters.AddWithValue("@isActiveService",isActiveService);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        #endregion

        // TODO: implement INSERT new record in [dbo].[tblOwnersVessels]
        public void insertRelationship_OwnerToVessel_InDatabase(OwnerToVessel newRelationship)
        {

        }

        // TODO: implement UPDATE existing record in [dbo].[tblOwners]
        public void updateExistingOwnerInDatabase(Owner owner)
        {

        }

        #region TODO: implement UPDATE existing record in [dbo].[tblVessels]
        public void updateExistingShipInDatabase(string shipId, string mmsi,string shipName,string callSign,string flag,string vesselType, int grossTonnage, int deadweight, DateTime dateBuilt, bool isActiveService)
        {
            using (SqlConnection con = new SqlConnection(connString_to_AppDB))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateVessel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mmsi", mmsi);
                    cmd.Parameters.AddWithValue("@imo", shipId);
                    cmd.Parameters.AddWithValue("@shipName", shipName);
                    cmd.Parameters.AddWithValue("@callSign", callSign);
                    cmd.Parameters.AddWithValue("@flag", flag);
                    cmd.Parameters.AddWithValue("@vesselType", vesselType);
                    cmd.Parameters.AddWithValue("@grossTonnage", grossTonnage);
                    cmd.Parameters.AddWithValue("@deadweight", deadweight);
                    cmd.Parameters.AddWithValue("@dateBuilt", dateBuilt);
                    cmd.Parameters.AddWithValue("@isActiveService", isActiveService);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        #endregion

        // TODO : implement DELETE existing record in [dbo].[tblOwners]
        public void deleteExistingOwnerInDatabase(string ownerId)
        {

        }

        // TODO: implement DELETE existing record in [dbo].[tblVessels]
        public void deleteExistingVesselInDatabase(string shipId)
        {
            try
            {
                using (SqlConnection con=new SqlConnection(ConnString_to_AppDB))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteVessel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@imo",shipId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // TODO: implement DELETE existing record in [dbo].[tblOwnersVessels]
        public void deleteExistingRelationship_OwnerToVessel_InDatabase(string ownerId, string shipId)
        {

        }


    }
}