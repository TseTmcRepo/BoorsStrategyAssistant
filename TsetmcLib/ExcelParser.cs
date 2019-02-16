using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml.Linq;
using OfficeOpenXml;

namespace TsetmcLib
{
    public class ExcelParser
    {
        public static List<Trade> Excel()
        {
            string path = @"http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=0";
            var physicalPath = HostingEnvironment.MapPath("~/xlsx");
            var fileName = @"file.xlsx";
            string localPath = string.Format(@"{0}/{1}",physicalPath,fileName) ;
            WebClient wc = new WebClient();

            var request = (HttpWebRequest)WebRequest.Create(path);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip,deflate";
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var output = File.Create(localPath))
            {
                stream.CopyTo(output);
            }

            DataTable rs = new DataTable();
            var list = new List<Trade>();
            using (var odConnection = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';",localPath)))
            {
                odConnection.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = odConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [دیده بان بازار$]";
                    using (OleDbDataAdapter oleda = new OleDbDataAdapter(cmd))
                    {
                        oleda.Fill(rs);
                    }
                }

                odConnection.Close();
                string username = "ime.co.ir";
                string password = "ime.co.ir";
                var days = new TseDayCollectionGenerator().GenerateToday();
                list = GetLastDayTrades(username, password, 1).ToList();
                rs.Rows[0].Delete();
                rs.Rows[1].Delete();
                rs.AcceptChanges();
                foreach(var row in rs.Rows.Cast<DataRow>())
                {
                    var trade = list.Where(t => t.LVal18AFC.Contains( row[0].ToString() ) ).FirstOrDefault();
                    if(trade != null)
                    {
                        trade.PbE = string.IsNullOrEmpty(row[16].ToString()) ? 0 :  Convert.ToDecimal(row[16].ToString().Replace('/','.'));
                        trade.EPS = string.IsNullOrEmpty(row[15].ToString()) ? 0 : Convert.ToDecimal(row[15].ToString());
                    }

                }
            }

            return list;
        }
        private static IEnumerable<Trade> GetLastDayTrades(string username, string password, byte market)
        {
            ServiceReference1.TsePublicV2SoapClient client = new ServiceReference1.TsePublicV2SoapClient();
            var tradesDataset = client.TradeLastDay(username, password, market);

            var trades = CollectionMapper.Map<Trade>(tradesDataset.Tables[0]);
            return trades;
        }
    }
}
