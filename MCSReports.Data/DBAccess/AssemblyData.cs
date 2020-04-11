using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MCSReportData.Models;
using Microsoft.Extensions.Configuration;

namespace MCSReportData
{
    public class AssemblyData
    {

        #region ===[ Private Members ]=============================================================

        private static IConfiguration Configuration { get; set; }
        private static string conStringMCSDb;
        private static string conStringMCSDMZDb;
        #endregion

        #region ===[ Constructor ]=================================================================
        /// <summary>
        /// Initialize the configs
        /// </summary>
        /// <param name="configuration"></param>
        public AssemblyData(IConfiguration configuration)//, ILogger<DataSource> logger
        {
            Configuration = configuration;
            conStringMCSDb = ConfigurationExtensions.GetConnectionString(Configuration, "MCSDB");
        }
        #endregion

        public static List<TestHistory> GetTestModuleResultsData()
        {
            string connectionString = "";
            string SerialNumber = "M0620105";
            //connectionString = conStringMCSDb;
            connectionString = "Data Source=AZW1WMCSSQLD01\\SQL01, 55370; Initial Catalog=MCS; User ID=AppUser01; PWD=QwJF7Y2qskdpktw";

            List<TestHistory> retValue = new List<TestHistory>();
            using (SqlConnection conx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conx;
                    cmd.CommandText = "dbo.rw_SNTestResultsByAO";
                    cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;

                    conx.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            retValue.Add(new TestHistory()
                            {
                                Stage = sdr["Stage"].ToString(),
                                ProductName = sdr["ProductName"].ToString(),
                                ModuleName = sdr["ModuleName"].ToString(),
                                AssemblyName = sdr["AssemblyName"].ToString(),
                                StartTime = DateTime.Parse(sdr["StartTime"].ToString()),
                                StopTime = DateTime.Parse(sdr["StopTime"].ToString()),
                                Outcome = sdr["Outcome"].ToString(),
                                StationName = sdr["StationName"].ToString(),
                                Operator = sdr["Operator"].ToString(),
                                SiteName = sdr["SiteName"].ToString(),

                            });
                        }
                    }
                    conx.Close();
                }
            }
            return retValue;
        }


        public static List<ShipmentHistory> GetShipmentHistory()
        {
            string connectionString = "";
            string SerialNumber = "M0620105";
            //connectionString = conStringMCSDb;
            connectionString = "Data Source=AZW1WMCSSQLD03\\SQL03; Initial Catalog=MCSDatawarehouse; User ID=Appuser03; PWD=PeQxFt-dm665mMj";

            List<ShipmentHistory> retValue = new List<ShipmentHistory>();
            using (SqlConnection conx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conx;
                    cmd.CommandText = "dbo.rw_GetShipmentHistory";
                    cmd.Parameters.AddWithValue("@SerialNumber", SerialNumber);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;

                    conx.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            retValue.Add(new ShipmentHistory()
                            {
                                DateShipped = DateTime.Parse(sdr["DateShipped"].ToString()),
                                CO = sdr["CO"].ToString(),
                                Customer = sdr["Customer"].ToString(),
                                SerialNumber = sdr["SerialNumber"].ToString(),
                                PartNumber = sdr["PartNumber"].ToString(),
                                CustomerPO = sdr["Customer PO"].ToString(),
                                DataSource = sdr["Data Source"].ToString()


                            });
                        }
                    }
                    conx.Close();
                }
            }
            return retValue;
        }
    }
}
