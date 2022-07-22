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

namespace finalhw
{
    public partial class fuc3 : Form
    {
        public fuc3()
        {
            InitializeComponent();
        }

        private void fuc3_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT  * FROM 標的", cn);
                da.Fill(ds, "標的");
                dataGridView1.DataSource = ds.Tables["標的"];
            }
                
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                try
                {

                    string strcolumn = dataGridView1.Columns[e.ColumnIndex].HeaderText;//獲取列標題
                    string strrow = strcolumn == "標的代號" ? dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() : dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();//獲取焦點觸發行的第一個值
                    string value = dataGridView1.CurrentCell.Value.ToString();//獲取當前點選的活動單元格的值
                    string title = strcolumn == "標的代號" ? "標的名稱" : "標的代號";
                    string strcomm = $"UPDATE 標的 SET {strcolumn} = {value} WHERE {title} = {strrow}";

                    DialogResult Result = MessageBox.Show("確定要修改\n" + strcomm, "警告", MessageBoxButtons.OKCancel);

                    if (Result == DialogResult.OK)
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand(strcomm, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        SqlDataAdapter da = new SqlDataAdapter($"SELECT  * FROM 標的", cn);
                        da.Fill(ds, "修改");
                        dataGridView1.DataSource = ds.Tables["修改"];
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter($"SELECT  * FROM 標的", cn);
                        da.Fill(ds, "標的");
                        dataGridView1.DataSource = ds.Tables["標的"];
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.connString))
            {
                string v = textBox1.Text;
                if (v == "") v = "%";
                SqlDataAdapter da2 = new SqlDataAdapter($"SELECT  * FROM 標的 WHERE 標的代號 like '%{v}%'", cn);
                da2.Fill(ds, "標的");


                dataGridView1.DataSource = ds.Tables["標的"];

            }
        }
    }
}
