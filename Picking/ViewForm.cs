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

namespace Picking
{
    public partial class ViewForm : Form
    {

        private SqlConnection connection;
        string relativePathToDatabase = @"..\..\martin.mdf";



        public ViewForm()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
        }
        private string GetConnectionString()
        {
            string dbFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathToDatabase));
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True;Connect Timeout=30";
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
   

                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    //All columns
                    string selectCommand = "SELECT * FROM List";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        //Bind DataTable to DataGridView
                        dataGridView.DataSource = dataTable;

                        //set the size
                        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading the DataGridView" + ex.Message);
            }

        }
        private void btnPicked_Click(object sender, EventArgs e)
        {
            HighlightSelectedRow();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearListTable();
            LoadDataIntoDataGridView();
        }

        private void ClearListTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string deleteCommand = "DELETE FROM List";

                    using (SqlCommand cmd = new SqlCommand(deleteCommand, connection))
                    {
                        // Execute the DELETE query
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("All records in the 'List' table have been deleted.");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while clearing." + ex.Message);

            }

        }

        private void HighlightSelectedRow()
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int SelectedRoowIndex = dataGridView.SelectedCells[0].RowIndex;

                foreach (DataGridViewCell cell in dataGridView.Rows[SelectedRoowIndex].Cells)
                {
                    cell.Style.BackColor = System.Drawing.Color.Green;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                MessageBox.Show("Order Completed");
            }
            else
            {
                MessageBox.Show("Please select Complete order");
            }

        }
    }
}
