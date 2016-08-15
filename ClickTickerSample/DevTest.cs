namespace ClickTickerSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DevTest")]
    public partial class DevTest
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string CampaignName { get; set; }

        public DateTime? Date { get; set; }

        public int? Clicks { get; set; }

        public int? Conversions { get; set; }

        public int? Impressions { get; set; }

        [StringLength(255)]
        public string AffiliateName { get; set; }
    }
}
