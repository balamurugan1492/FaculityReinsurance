using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using FACULTATIVE_REINSURANCE.Util;

namespace FACULTATIVE_REINSURANCE.View_model
{
    class GeneralInfoViewModel
    {
        public GeneralInfoViewModel()
        {
            string[] Keys = ConfigurationManager.AppSettings.AllKeys;
            this.GeneralHeader = Keys.Contains("GeneralHeader") ? ConfigurationManager.AppSettings.Get("GeneralHeader") : "General Information";
            this.ReinsuredInfo = CollectionDetails.ReinsuredDetails;
            this.RiskInfo = CollectionDetails.RiskInfoDetails;
        }

        public List<RiskInfoDetails> RiskInfo { get; set; }
        public List<ReInsuranceDetails> ReinsuredInfo { get; set; }
        public string GeneralHeader { get; set; }
    }
}
