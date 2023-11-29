using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace OnTap
{
    public partial class Form1 : Form
    {
        public class KetNoi
        {
            public SqlConnection ketnoi;
            public KetNoi()
            {
                ketnoi = new SqlConnection("Data Source = A209PC33; Initial Catalog = Phong; Integrated Security = True");
            }
            public KetNoi(string strcn)
            {
                ketnoi = new SqlConnection(strcn);
            }
        }
        KetNoi kn = new KetNoi();
        SqlConnection connsql;
        public Form1()
        {
            InitializeComponent();
            connsql = kn.ketnoi;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State==ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string inserString;
                inserString = "Insert into Phong values(' " + textBox1.Text + "', N'" + textBox2.Text +"')";
                SqlCommand cmd = new SqlCommand(inserString, connsql);
                cmd.ExecuteNonQuery();
                if(connsql.State== ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch(Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(connsql.State==ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updateString;
                updateString =  "update Phong set name= '" + textBox2.Text + "'where id='" + textBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                cmd.ExecuteNonQuery();
                if(connsql.State==ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch(Exception ex) 
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(connsql.State==ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string deleteString;
                deleteString = "delete Phong where id='" + textBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if(connsql.State==ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch(Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }
    }
}
