

using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace TimeSeriesChart.Report
{
    public class ReportViewerRdlc
    {
        public byte[] RptPO(string rptType = "pdf")
        {
            DataSet rptDS = new DataSet();
            string ReportCaption = "PO Report";
            LocalReport localReport = new LocalReport();
            ReportDataSource reportDataSource = new ReportDataSource { Name = "DataSet1" };

            string mimeType, encoding, fileNameExtension = (rptType == "Excel") ? "xlsx" : (rptType == "Word" ? "doc" : "pdf");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //SoftifySQLConnection clsCon = new SoftifySQLConnection("SoftifySalesInventory", true);
            try
            {
                string rptQuery = "";

                rptDS = GetData();
                //rptQuery = "EXEC rptPO " + comId + ", " + id + " ";
                localReport.ReportPath = "rptPO.rdlc";

                //clsCon.softifyFillDatasetUsingSQLCommand(ref rptDS, rptQuery);


                reportDataSource.Value = rptDS.Tables[0];

                if (rptDS.Tables[0].Rows.Count == 0)
                {
                    //ModelState.AddModelError("CustomError", "Data Not Found.....");
                }
                else
                {
                    localReport.DataSources.Add(reportDataSource);

                    renderedBytes = localReport.Render(rptType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    //Response.AddHeader("Content-Disposition", $"inline; filename = {ReportCaption}.{fileNameExtension}");
                    //Response.ContentType = Models.Report.ReturnExtension("." + fileNameExtension.ToLower());

                    //Response.AddHeader("content-length", renderedBytes.Length.ToString());
                    //Response.BinaryWrite(renderedBytes);
                    return renderedBytes;
                    //return File(renderedBytes, mimeType);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public DataSet GetData()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
      
            connetionString = @"Data Source=.;Initial Catalog=B2PosSystem;User ID=sa;Password=007";
            string sql = "select * from  Categories";

            connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
          
            }
            catch (Exception ex)
            {
                adapter.Dispose();
                //command.Dispose();
                connection.Close();
            }
            return ds;
        }
    }
}
