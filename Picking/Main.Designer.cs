namespace Picking
{
    partial class Main
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
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(266, 238);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(188, 61);
            this.btnOrder.TabIndex = 0;
            this.btnOrder.Text = "Place Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(528, 238);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(195, 61);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "Complete Order";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(804, 459);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnOrder);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnComplete;
    }
}