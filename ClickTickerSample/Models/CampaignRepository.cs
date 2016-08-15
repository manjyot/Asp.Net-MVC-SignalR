using ClickTickerSample.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClickTickerSample.Models
{
    public class CampaignRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["TestModel"].ConnectionString;

        public IEnumerable<DevTest> GetAllDevTest()
        {
            var campaigns = new List<DevTest>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [ID], [CampaignName], [Date], [Clicks], [Conversions], [Impressions], [AffiliateName] FROM [dbo].[DevTest]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        campaigns.Add(item: new DevTest { ID = (int)reader["ID"], CampaignName = (string)reader["CampaignName"], Date = Convert.ToDateTime(reader["Date"]), Clicks = (int)reader["Clicks"], Conversions = (int)reader["Conversions"], Impressions = (int)reader["Impressions"], AffiliateName = (string)reader["AffiliateName"] });
                    }
                }

            }
            return campaigns;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                CampaignHub.SendCampaign();
            }
        }
    }
}