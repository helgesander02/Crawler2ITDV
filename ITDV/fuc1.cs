using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalhw
{
    public partial class fuc1 : Form
    {
        public fuc1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string v = textBox1.Text;
                if (v == "") v = "%";
                SqlDataAdapter da1 = new SqlDataAdapter($"SELECT  * FROM 基金 WHERE 標的代號 like '%{v}%'", cn);
                da1.Fill(ds, "基金");
                SqlDataAdapter da2 = new SqlDataAdapter($"SELECT  * FROM 標的 WHERE 標的代號 like '%{v}%'", cn);
                da2.Fill(ds, "標的");


                dataGridView1.DataSource = ds.Tables[comboBox1.Text];

            }
        }

        private void fuc1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string v = textBox1.Text;
                SqlDataAdapter da1 = new SqlDataAdapter($"SELECT  * FROM 基金", cn);
                da1.Fill(ds, "基金");
                SqlDataAdapter da2 = new SqlDataAdapter($"SELECT  * FROM 標的", cn);
                da2.Fill(ds, "標的");

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    comboBox1.Items.Add(ds.Tables[i].TableName);
                }

                comboBox1.Text = ds.Tables["基金"].TableName;
                //comboBox2.Text = "請選擇";
                dataGridView1.DataSource = ds.Tables["基金"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
                dialog.Title = "請選擇資料";
                dialog.Filter = "所有檔案(*.csv)|*.csv";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = dialog.FileName;
                    try
                    {
                        using (StreamReader reader = new StreamReader(@file))
                        {
                            cn.Open();
                            reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');
                                //var sql = $@"INSERT INTO [基金](年,月,基金名稱,標的代號,金額,占基金淨資產價值之比例) VALUES (@year,@month,@name,@number,@price,@percent);";
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = cn;
                                cmd.CommandText = "InsertValues";
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                                cmd.Parameters.Add(new SqlParameter("@month", SqlDbType.Int));
                                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar));
                                cmd.Parameters.Add(new SqlParameter("@number", SqlDbType.NVarChar));
                                cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.BigInt));
                                cmd.Parameters.Add(new SqlParameter("@percent", SqlDbType.Float));
                                cmd.Parameters["@year"].Value = int.Parse(values[0]);
                                cmd.Parameters["@month"].Value = int.Parse(values[1]);
                                cmd.Parameters["@name"].Value = values[2];
                                cmd.Parameters["@number"].Value = values[3];
                                cmd.Parameters["@price"].Value = Int64.Parse(values[4]);
                                cmd.Parameters["@percent"].Value = float.Parse(values[5]);
                                cmd.ExecuteNonQuery();
                            }
                            
                            cn.Close();
                            MessageBox.Show("上傳成功", "資料上傳狀態");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "\n上傳失敗", "資料上傳狀態");
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {               
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
                dialog.Title = "請選擇資料";
                dialog.Filter = "所有檔案(*.csv)|*.csv";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = dialog.FileName;
                    try
                    {
                        using (StreamReader reader = new StreamReader(@file))
                        {
                            cn.Open();
                            reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');
                                var sql = $@"INSERT INTO [標的](標的代號,標的名稱) VALUES (N'{values[0]}',N'{values[1]}');";
                                SqlCommand cmd = new SqlCommand(sql, cn);
                                cmd.ExecuteNonQuery();
                            }
                            
                            cn.Close();
                            MessageBox.Show("上傳成功", "資料上傳狀態");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "\n上傳失敗", "資料上傳狀態");
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
