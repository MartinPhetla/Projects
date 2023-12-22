using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Picking
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter itemModelsAdapter;
        private AutoCompleteStringCollection itemModelsAutoCompleteCollection;
        private SqlDataAdapter itemCodesAdapter;
        private AutoCompleteStringCollection binLocationAutoCompleteCollection;
        private SqlDataAdapter binCodesAdapter;
        private AutoCompleteStringCollection itemCodesAutoCompleteCollection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\martin\OneDrive - FHS\Desktop\IT ERROR\Picking\Picking\martin.mdf"";Integrated Security=True;Connect Timeout=30";


        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeAutoComplete();
            InitializeTimer();

            //call the txtQty 
            txtQty.KeyPress += TxtQty_KeyPress;

            //Assign the buton send to the method 
            btnSend.Click -= btnSend_Click;
            btnSend.Click += btnSend_Click;

            btnClear.Click += btnClear_Click;
        }

        private void InitializeDatabaseConnection()
        {
            //connection string

            connection = new SqlConnection(connectionString);

            //Adapter and collection for itemModels
            itemModelsAdapter = new SqlDataAdapter("SELECT itemModels FROM Models", connection);
            itemModelsAutoCompleteCollection = new AutoCompleteStringCollection();

            //Adapter and collection for binCodes
            binCodesAdapter = new SqlDataAdapter("SELECT binLocation FROM bins", connection);
            binLocationAutoCompleteCollection = new AutoCompleteStringCollection();

            //Adapter and Collection for itemModels
            itemCodesAdapter = new SqlDataAdapter("SELECT itemCodes FROM Codes", connection);
            itemCodesAutoCompleteCollection = new AutoCompleteStringCollection();
        }

        private void InitializeAutoComplete()
        {
            //AutoComplete itemModels
            using (SqlCommand command = new SqlCommand("SELECT itemModels FROM Models", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    itemModelsAutoCompleteCollection.Add(reader["itemModels"].ToString());
                }

                connection.Close();
            }

            // AutoComplete binLocations
            using (SqlCommand command = new SqlCommand("SELECT binLocation FROM Bin", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    binLocationAutoCompleteCollection.Add(reader["binLocation"].ToString());
                }

                connection.Close();
            }
            //AutoComplete itemCodes
            using (SqlCommand command = new SqlCommand("SELECT itemCodes FROM codes", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    itemCodesAutoCompleteCollection.Add(reader["itemCodes"].ToString());
                }
                connection.Close();
            }

            // AutoCompleteSource for txtDes
            txtCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCode.AutoCompleteCustomSource = itemModelsAutoCompleteCollection;

            //AutoCompleteSource for txtBin
            txtBin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBin.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBin.AutoCompleteCustomSource = binLocationAutoCompleteCollection;

            //AutoCompleteSource for itemCodes
            txtBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBrand.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBrand.AutoCompleteCustomSource = itemCodesAutoCompleteCollection;
        }

        private void InitializeTimer()
        {
            //Time with a 1 - second interval 
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            //start the timer 
            timer.Start();

        }


        //update the time in the box
        private void Timer_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToString("HH:mm");
        }

        //method to make sure that qty filed take only integers 
        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            InsertIntoListTable();
            LoadDataIntoDataGridView();
            ClearFormFields();


        }

        private void InsertIntoListTable()
        {
            try
            {
                // Check if all required fields are filled in
                if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                    string.IsNullOrWhiteSpace(txtBrand.Text) ||
                    string.IsNullOrWhiteSpace(txtBin.Text) ||
                    string.IsNullOrWhiteSpace(txtTime.Text) ||
                    string.IsNullOrWhiteSpace(txtQty.Text))
                {
                    MessageBox.Show("Please fill in all fields before sending the order.");
                    return;
                }


                //Comm open
                connection.Open();

                //sql comman to insert values into selected fileds in the table List
                string insertCommand = "INSERT INTO List (item, description, bin, time, qty) VALUES (@item, @description, @bin, @time, @qty)";

                using (SqlCommand cmd = new SqlCommand(insertCommand, connection))
                {
                    cmd.Parameters.AddWithValue("@item", txtCode.Text);
                    cmd.Parameters.AddWithValue("@description", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@bin", txtBin.Text);
                    cmd.Parameters.AddWithValue("@time", txtTime.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);

                    //run query 
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Order Successfully sent");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Your order was not sent " + ex.Message);
            }
            finally
            { connection.Close(); }
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void HighlightSelectedRow()
        {
            if(dataGridView.SelectedCells.Count > 0)
            {
                int SelectedRoowIndex = dataGridView.SelectedCells[0].RowIndex;

                foreach(DataGridViewCell cell in dataGridView.Rows[SelectedRoowIndex].Cells)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearListTable();
            LoadDataIntoDataGridView();
            
        }
        private void ClearListTable()
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Error while clearing." + ex.Message);

            }
            finally
            {
                connection.Close();
            }
        }

        private void ClearFormFields()
        {
            // Clear textboxes
            txtCode.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtBin.Text = string.Empty;
            txtTime.Text = string.Empty;
            txtQty.Text = string.Empty;

            // Set focus to the first textbox for convenience
            txtCode.Focus();
        }

    }

}


  
