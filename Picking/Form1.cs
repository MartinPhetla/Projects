using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        string relativePathToDatabase = @"..\..\martin.mdf";

        //Set the pincode to enter befor viewing Orders
        private string pin = "1234";

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

        }
        private void InitializeDatabaseConnection()
        {
            //connection string

            string dbFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathToDatabase));

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True;Connect Timeout=30";
 


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
            string dbFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathToDatabase));

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
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
            ClearFormFields();


        }

        private void InsertIntoListTable()
        {
            string dbFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePathToDatabase));

            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
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


        private void btnView_Click(object sender, EventArgs e)
        {
            ViewOrders();
        }
        private void ViewOrders()
        {
            // Prompt user for PIN
            string enteredPin = PromptForPin();

            // Check if the entered PIN is correct
            if (enteredPin == "1234")
            {
                // PIN is correct, show ViewForm
                ViewForm viewForm = new ViewForm();
                viewForm.Show();
            }
            else
            {
                // Incorrect PIN, show an error message
                MessageBox.Show("Incorrect PIN. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForPin()
        {
            using (PinInputDialog pinInputDialog = new PinInputDialog())
            {
                DialogResult result = pinInputDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return pinInputDialog.EnteredPin;
                }
                return string.Empty; // User canceled
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


  
