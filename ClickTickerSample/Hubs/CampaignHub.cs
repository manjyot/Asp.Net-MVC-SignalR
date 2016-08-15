using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Configuration;

namespace ClickTickerSample.Hubs
{
    [HubName("CampaignHub")]
    public class CampaignHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["TestModel"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("SendCampaign")]
        public static void SendCampaign()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CampaignHub>();
            context.Clients.All.updateCampaign();
        }
    }
}