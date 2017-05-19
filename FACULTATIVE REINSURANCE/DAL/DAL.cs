using FACULTATIVE_REINSURANCE.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace FACULTATIVE_REINSURANCE.DAL
{
    public class DAL
    {
        private OleDbCommand objCmd = new OleDbCommand();
        private OleDbConnection objConn = null;

        public DAL()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["oleConnection"].ToString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                objConn = new OleDbConnection(connectionString);
                //FetchData();
            }
        }

        private void FetchData()
        {
            try
            {
                List<ReInsuranceDetails> listReinsuredDetail = new List<ReInsuranceDetails>();
                List<RiskInfoDetails> listRiskInfoDetail = new List<RiskInfoDetails>();
                List<CoverageDeatils> listCoverageDetail = new List<CoverageDeatils>();
                List<ExtenstionDetails> listextensionDetails = new List<ExtenstionDetails>();
                DataTable dt = executeQuery("*", "ReIssuredMaster", string.Empty).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    ReInsuranceDetails reinsuredDetail = new ReInsuranceDetails()
                    {
                        ID = row.Field<int>("ID"),
                        ColumnName = row.Field<string>("colName"),
                        Description = row.Field<string>("Description"),
                        Code = row.Field<string>("Code")
                    };
                    listReinsuredDetail.Add(reinsuredDetail);
                }
                CollectionDetails.ReinsuredDetails = listReinsuredDetail;
                DataTable dtRisk = executeQuery("*", "RiskInfoMaster", string.Empty).Tables[0];
                foreach (DataRow row in dtRisk.Rows)
                {
                    RiskInfoDetails riskInfo = new RiskInfoDetails()
                    {
                        ID = row.Field<int>("ID"),
                        ColumnName = row.Field<string>("Name"),
                        Description = row.Field<string>("Description"),
                        Code = row.Field<string>("Code")
                    };
                    listRiskInfoDetail.Add(riskInfo);
                }
                CollectionDetails.RiskInfoDetails = listRiskInfoDetail;
                DataTable dtCoverageDeatils = executeQuery("*", "DefaultConfigMaster", string.Empty).Tables[0];
                foreach (DataRow row in dtCoverageDeatils.Rows)
                {
                    if (row.Field<string>("GroupName") == "COVERAGE")
                    {
                        CoverageDeatils coverageDetails = new CoverageDeatils()
                        {
                            DisplayName = row.Field<string>("DisplayName"),
                            ID = row.Field<int>("ID"),
                            ColumnName = row.Field<string>("colName"),
                            Description = row.Field<string>("Description"),
                            Code = row.Field<string>("Code"),
                            DefaultValue = Convert.ToInt16(row.Field<string>("DefaultValue")),
                            MinValue = Convert.ToInt16(row.Field<string>("MinVal")),
                            MaxValue = Convert.ToInt16(row.Field<string>("MaxVal"))
                        };
                        listCoverageDetail.Add(coverageDetails);
                    }
                    else if (row.Field<string>("GroupName") == "EXTENSIONS")
                    {
                        ExtenstionDetails extenstionDetails = new ExtenstionDetails()
                       {
                           DisplayName = row.Field<string>("DisplayName"),
                           ID = row.Field<int>("ID"),
                           ColumnName = row.Field<string>("colName"),
                           Description = row.Field<string>("Description"),
                           Code = row.Field<string>("Code"),
                           DefaultValue = row.Field<string>("DefaultValue")
                           //MinValue = Convert.ToInt16(row.Field<string>("MinVal")),
                           //MaxValue = Convert.ToInt16(row.Field<string>("MaxVal"))
                       };
                        listextensionDetails.Add(extenstionDetails);
                    }
                }
                CollectionDetails.CoverageDeatails = listCoverageDetail;
                CollectionDetails.ExtensionDetails = listextensionDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet executeQuery(string selectFields, string fromTabls, string whereConditions)
        {
            DataSet dsResult = new DataSet();
            if (objConn != null)
            {
                string strQuery = string.Empty;
                strQuery = "SELECT " + selectFields + " FROM " + fromTabls + (string.IsNullOrEmpty(whereConditions.Trim()) ? string.Empty : " WHERE " + whereConditions);
                objCmd.CommandType = CommandType.Text;
                objCmd.Connection = objConn;
                objCmd.CommandText = strQuery;
                objConn.Open();
                OleDbDataAdapter objDataAdap = new OleDbDataAdapter(objCmd);
                objDataAdap.Fill(dsResult);
                objConn.Close();
            }
            return dsResult;
        }

        public bool insertData(string columnNames, string tableName, string insertionValues)
        {
            bool blnResult = false;
            try
            {
                if (objConn != null)
                {
                    string strQuery = "INSERT INTO " + tableName + "(" + columnNames + ") VALUES (" + insertionValues + ")";
                    objCmd.CommandType = CommandType.Text;
                    objCmd.Connection = objConn;
                    objCmd.CommandText = strQuery;
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    objConn.Close();
                    return true;
                }
                else
                    return blnResult;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}