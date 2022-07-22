using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace finalhw
{
    public partial class fuc2 : Form
    {
        public fuc2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (radioButton1.Checked)
                {
                    SqlDataAdapter da_1 = new SqlDataAdapter($"SELECT 基金.標的代號,標的.標的名稱,COUNT(基金.標的代號) AS 總數 FROM 基金 INNER JOIN 標的 ON 基金.標的代號 = 標的.標的代號 GROUP BY 基金.標的代號, 標的.標的名稱 ORDER BY 總數 desc; ", cn);
                    da_1.Fill(ds, "排行");
                    //dataGridView1.DataSource = ds.Tables["排行"];
                    DataTable ranking = ds.Tables["排行"];
                    if (txt == "") txt = "0";

                    var tr = from r in ranking.AsEnumerable()
                             where r.Field<int>("總數") >= int.Parse(txt)
                             select new
                             {
                                 標的代號 = r.Field<string>("標的代號"),
                                 標的名稱 = r.Field<string>("標的名稱"),
                                 總數 = r.Field<int>("總數")
                             };

                    //dataGridView1.DataSource = tr.ToList();
                    List<int> t1 = new List<int>();
                    List<string> t2 = new List<string>();
                    foreach (var item in tr)
                    {
                        t1.Add(item.總數);
                        t2.Add(item.標的名稱);
                    }
                    Column(t1, t2);
                }
                if (radioButton2.Checked)
                {
                    SqlDataAdapter da_2 = new SqlDataAdapter($"SELECT 基金.標的代號,標的.標的名稱,SUM(基金.金額) AS 總金額 FROM 基金 INNER JOIN 標的 ON 基金.標的代號 = 標的.標的代號 GROUP BY 基金.標的代號, 標的.標的名稱 ORDER BY 總金額  desc; ", cn);
                    da_2.Fill(ds, "排行");
                    //dataGridView1.DataSource = ds.Tables["排行"];
                    DataTable ranking = ds.Tables["排行"];
                    if (txt == "") txt = "0";

                    var tr = from r in ranking.AsEnumerable()
                             where r.Field<Int64>("總金額") >= Int64.Parse(txt)
                             select new
                             {
                                 標的代號 = r.Field<string>("標的代號"),
                                 標的名稱 = r.Field<string>("標的名稱"),
                                 總金額 = r.Field<Int64>("總金額")
                             };
                    //dataGridView1.DataSource = tr.ToList();
                    List<Int64> t1 = new List<Int64>();
                    List<string> t2 = new List<string>();
                    foreach (var item in tr)
                    {
                        t1.Add(item.總金額);
                        t2.Add(item.標的名稱);
                    }
                    Column(t1, t2);
                }


            }
        }
        
        private void Column<T>(List<T> t1, List<string> t2)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();
            Title title = chart1.Titles.Add(radioButton2.Text);
            title.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
            title.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            chart1.ChartAreas[0].AxisY.TitleForeColor = Color.White;
            chart1.ChartAreas[0].AxisX.Title = "標題名稱";
            chart1.ChartAreas[0].AxisY.Title = "總數";
            chart1.Series.Add("Column1");
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("微軟正黑體", 12, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("微軟正黑體", 12, FontStyle.Bold);
            chart1.Series["Column1"].LabelForeColor = Color.White;
            chart1.Series["Column1"].ChartType = SeriesChartType.Column;
            chart1.Series["Column1"].BorderWidth = 3;
            chart1.Series["Column1"].XValueType = ChartValueType.String;
            chart1.Series["Column1"].YValueType = ChartValueType.Int64;
            chart1.Series["Column1"].Points.DataBindXY(t2, t1);
            

        }
    }
}
