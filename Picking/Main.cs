using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picking
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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

        private void btnComplete_Click(object sender, EventArgs e)
        {
            ViewOrders();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();

        }
    }
}
