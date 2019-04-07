using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatatableToCsv
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Get Datatable .
        /// </summary>
        /// <returns></returns>
        public DataTable GetDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Company", typeof(string));
                dt.Columns.Add("HasExperience", typeof(string));

                DataRow dr = dt.NewRow();

                dr["Id"] = 1;
                dr["Name"] = "Ranjeet";
                dr["Company"] = "BNP";
                dr["HasExperience"] = "Yes";
                dt.Rows.Add(dr);

                DataRow dr2 = dt.NewRow();

                dr2["Id"] = 2;
                dr2["Name"] = "Munna";
                dr2["Company"] = "BNP";
                dr["HasExperience"] = string.Empty;
                dt.Rows.Add(dr2);

                DataRow dr3 = dt.NewRow();

                dr3["Id"] = 3;
                dr3["Name"] = "Abhishek";
                dr3["Company"] = "BNP";
                dr["HasExperience"] = string.Empty;
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();

                dr4["Id"] = 4;
                dr4["Name"] = "Pradeep";
                dr4["Company"] = "BNP";
                dr["HasExperience"] = "No";
                dt.Rows.Add(dr4);

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            string folderPath = @"D:\";
            Export(GetDetails());
            ////File.WriteAllText(folderPath + "GridViewExport.csv",da);
        }

        public void Export(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));

            }
            //modify

            File.WriteAllText($"D:\\{DateTime.Now.ToString("ddMMyyyy_hhmmss")}.csv", sb.ToString());
        }
    }
}