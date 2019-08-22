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


namespace Project1
{
    public partial class SAICSearch : Form
    {
        private SqlConnection conn;

        public SAICSearch()
        {
            InitializeComponent();
            conn = new SqlConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adding a key press handler in order to check for Enter key being pressed
            textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);

            // Setting ActiveControl ensures the search text is highlighted
            ActiveControl = textBox1;
        }

        private void TextBox1(object sender, EventArgs e)
        {

        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // handle the Enter key in the text box
            if (e.KeyChar == (char)13)
            {
                // Pressing Enter is the same as pressing search button
                button1_Click_1(sender, e);
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Passing the query from textBox1 to the data load function
            LoadData(textBox1.Text);     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData(string query)
        {
            //string sqlQueryStr = "SELECT category Category, note_data Note FROM categories, notes "+
            //                    "WHERE notes.note_cat = categories.catidx " +
            //                   "AND CONTAINS(note_data,'\"" +query + "\"')";
            string sqlQueryStr = "SELECT * FROM " + query;

            //SqlConnection conn = new SqlConnection();
            try
            {
                // Constructing a connection string to the database
                // SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                // builder.DataSource = ".\\MYSERVER";
                // builder.InitialCatalog = "msnotes";
                // builder.IntegratedSecurity = true;
                // conn.ConnectionString = builder.ConnectionString;

                //To connect to your local SQL Server, the connection string needs to be in the format:
                //"Server=[server_name];Database=[database_name];Trusted_Connection=true";
                //After starting your local SQL Server, this should work:
                //conn.ConnectionString = "Server=localhost;Database=master;Trusted_Connection=True;";

                if (!button3.Text.Equals("Connected"))
                    throw new Exception("Invalid server/database information; you are not connected to a database.");

                // Connecting
                conn.Open();

                using (SqlDataAdapter myAdapter = new SqlDataAdapter(sqlQueryStr, conn))
                {
                    // Using DataAdapter to fill DataTable
                    DataTable myTable = new DataTable();
                    myAdapter.Fill(myTable);

                    // Rendering data onto the screen
                    dataGridView1.DataSource = myTable;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error Accessing Database");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Accessing Database");
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection();
            try
            {
                if (!button3.Text.Equals("Connected"))
                {
                    // Connecting
                    conn.ConnectionString = "Server=" + textBox2.Text + ";Database=" + textBox3.Text + ";Trusted_Connection=" + checkBox1.Checked.ToString() + ";";
                    button3.Text = "Connecting...";
                    this.Refresh();
                    conn.Open();
                    button3.Text = "Connected";
                    button3.BackColor = Color.Green;
                    conn.Close();
                }   
               else
                {
                    //MessageBox.Show("Closing Connection", "Closed");
                    conn.Close();
                    button3.Text = "Connect";
                    button3.BackColor = Color.Gray;
                }

            }
            catch (SqlException exc)
            {
                button3.Text = "Not Connected";
                button3.BackColor = Color.Red;
                MessageBox.Show(exc.Message, "Error Accessing Database");
            }

            finally
            {

            }
    }
    }
}
