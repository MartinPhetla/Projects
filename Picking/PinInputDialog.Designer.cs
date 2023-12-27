namespace Picking
{
    partial class PinInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPin = new System.Windows.Forms.TextBox();
            this.lblPin = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(185, 97);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(100, 22);
            this.txtPin.TabIndex = 0;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(194, 43);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(91, 16);
            this.lblPin.TabIndex = 1;
            this.lblPin.Text = "Enter Your Pin";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(200, 141);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(55, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PinInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 222);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.txtPin);
            this.Name = "PinInputDialog";
            this.Text = "PinInputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}