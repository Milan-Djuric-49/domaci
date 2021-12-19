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

namespace domaci2021
{
    public partial class Form1 : Form
    {

        DataTable Element = new DataTable();

        int rows = 0;
        string cs = "Data source=LAPTOP-FGQM75PR\\SQLEXPRESS; Initial catalog=domaci2021; Integrated security=true";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Element ", veza);
            adapter.Fill(Element);

            refresh(rows);

            if (rows == 0)
            {
                button2.Enabled = false;
            }
            if (rows == Element.Rows.Count - 1)
            {
                button3.Enabled = false;
            }
        }

        private void refresh(int x)
        {
            textBox1.Text = Element.Rows[x]["ID"].ToString();
            textBox2.Text = Element.Rows[x]["Naziv"].ToString();
            textBox3.Text = Element.Rows[x]["Simbol"].ToString();
            textBox4.Text = Element.Rows[x]["Masa"].ToString();
            textBox5.Text = Element.Rows[x]["AtomskiBroj"].ToString();
            textBox6.Text = Element.Rows[x]["Grupa"].ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rows < Element.Rows.Count - 1)
            {
                rows++;
                refresh(rows);
                button2.Enabled = true;
            }
            if (rows == Element.Rows.Count - 1)
            {
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rows > 0)
            {
                rows--;
                refresh(rows);
                button3.Enabled = true;
            }
            if (rows == 0)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rows = 0;
            refresh(rows);
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rows = Element.Rows.Count - 1;
            refresh(rows);
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("DELETE FROM Element WHERE ID=" + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Element", veza);
            Element.Clear();
            adapter.Fill(Element);
            if (rows == Element.Rows.Count) rows = rows - 1;
            if (rows == 0)
            {
                button2.Enabled = false;
            }
            if (Element.Rows.Count > 1)
            {
                button3.Enabled = true;
            }
            if (rows == Element.Rows.Count - 1)
            {
                button3.Enabled = false;
            }

            refresh(rows);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update Element Set Grupa= '" + textBox6.Text + "' , Naziv= '" + textBox2.Text + "', Simbol= '" + textBox3.Text + "' , Masa= '" + textBox4.Text + "' , AtomskiBroj= '" + textBox5.Text + "'  where ID= " + textBox1.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Element", veza);
            Element.Clear();
            adapter.Fill(Element);
            refresh(rows);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("insert into Element (ID , Naziv, Simbol, Masa, AtomskiBroj, Grupa) values (" + textBox1.Text + ", '" + textBox2.Text + "' ,'" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "' ,'" + textBox6.Text + "' ) ", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Element", veza);
            Element.Clear();
            adapter.Fill(Element);
            refresh(rows);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
    }
}
