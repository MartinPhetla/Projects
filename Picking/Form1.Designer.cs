namespace Picking
{
    partial class Form1
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtBin = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.Qty = new System.Windows.Forms.Label();
            this.lbl_Bin = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnPicked = new System.Windows.Forms.Button();
            this.lbl_itemcode = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.txtCode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCode.Location = new System.Drawing.Point(334, 135);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(177, 25);
            this.txtCode.TabIndex = 1;
            // 
            // txtBrand
            // 
            this.txtBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.txtBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBrand.Location = new System.Drawing.Point(334, 193);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(177, 25);
            this.txtBrand.TabIndex = 2;
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.txtQty.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtQty.Location = new System.Drawing.Point(334, 252);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(177, 25);
            this.txtQty.TabIndex = 3;
            // 
            // txtBin
            // 
            this.txtBin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.txtBin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtBin.Location = new System.Drawing.Point(334, 309);
            this.txtBin.Name = "txtBin";
            this.txtBin.Size = new System.Drawing.Size(177, 25);
            this.txtBin.TabIndex = 4;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.txtTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTime.Location = new System.Drawing.Point(334, 369);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(177, 25);
            this.txtTime.TabIndex = 5;
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Location = new System.Drawing.Point(16, 197);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(53, 17);
            this.lbl_Description.TabIndex = 7;
            this.lbl_Description.Text = "BRAND";
            // 
            // Qty
            // 
            this.Qty.AllowDrop = true;
            this.Qty.AutoSize = true;
            this.Qty.Location = new System.Drawing.Point(16, 260);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(88, 17);
            this.Qty.TabIndex = 8;
            this.Qty.Text = "QTY NEEDED";
            // 
            // lbl_Bin
            // 
            this.lbl_Bin.AutoSize = true;
            this.lbl_Bin.Location = new System.Drawing.Point(16, 317);
            this.lbl_Bin.Name = "lbl_Bin";
            this.lbl_Bin.Size = new System.Drawing.Size(99, 17);
            this.lbl_Bin.TabIndex = 9;
            this.lbl_Bin.Text = "BIN LOCATION";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(16, 380);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(39, 17);
            this.lbl_Time.TabIndex = 10;
            this.lbl_Time.Text = "TIME";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(347, 439);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(144, 34);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(561, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "YOUR ORDER";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(538, 135);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(643, 322);
            this.dataGridView.TabIndex = 13;
            // 
            // btnPicked
            // 
            this.btnPicked.Location = new System.Drawing.Point(661, 474);
            this.btnPicked.Name = "btnPicked";
            this.btnPicked.Size = new System.Drawing.Size(132, 30);
            this.btnPicked.TabIndex = 14;
            this.btnPicked.Text = "COMPLETE";
            this.btnPicked.UseVisualStyleBackColor = true;
            this.btnPicked.Click += new System.EventHandler(this.btnPicked_Click);
            // 
            // lbl_itemcode
            // 
            this.lbl_itemcode.AutoSize = true;
            this.lbl_itemcode.Location = new System.Drawing.Point(16, 143);
            this.lbl_itemcode.Name = "lbl_itemcode";
            this.lbl_itemcode.Size = new System.Drawing.Size(80, 17);
            this.lbl_itemcode.TabIndex = 0;
            this.lbl_itemcode.Text = "Component";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(836, 474);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(132, 30);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "CLear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(173)))), ((int)(((byte)(136)))));
            this.ClientSize = new System.Drawing.Size(1185, 587);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPicked);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.lbl_Bin);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.lbl_Description);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtBin);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lbl_itemcode);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(57)))), ((int)(((byte)(55)))));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtBin;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.Label Qty;
        private System.Windows.Forms.Label lbl_Bin;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnPicked;
        private System.Windows.Forms.Label lbl_itemcode;
        private System.Windows.Forms.Button btnClear;
    }
}

