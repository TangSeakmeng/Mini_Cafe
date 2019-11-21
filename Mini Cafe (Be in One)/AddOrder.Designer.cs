namespace Mini_Cafe__Be_in_One_
{
    partial class AddOrder
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
            this.TakeAwayRdBtn = new System.Windows.Forms.RadioButton();
            this.DineInRdBtn = new System.Windows.Forms.RadioButton();
            this.btnAddOrders = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TakeAwayRdBtn
            // 
            this.TakeAwayRdBtn.AutoSize = true;
            this.TakeAwayRdBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TakeAwayRdBtn.Location = new System.Drawing.Point(23, 56);
            this.TakeAwayRdBtn.Margin = new System.Windows.Forms.Padding(2);
            this.TakeAwayRdBtn.Name = "TakeAwayRdBtn";
            this.TakeAwayRdBtn.Size = new System.Drawing.Size(108, 24);
            this.TakeAwayRdBtn.TabIndex = 4;
            this.TakeAwayRdBtn.TabStop = true;
            this.TakeAwayRdBtn.Text = "Take Away";
            this.TakeAwayRdBtn.UseVisualStyleBackColor = true;
            this.TakeAwayRdBtn.CheckedChanged += new System.EventHandler(this.TakeAwayRdBtn_CheckedChanged);
            // 
            // DineInRdBtn
            // 
            this.DineInRdBtn.AutoSize = true;
            this.DineInRdBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DineInRdBtn.Location = new System.Drawing.Point(24, 26);
            this.DineInRdBtn.Margin = new System.Windows.Forms.Padding(2);
            this.DineInRdBtn.Name = "DineInRdBtn";
            this.DineInRdBtn.Size = new System.Drawing.Size(81, 24);
            this.DineInRdBtn.TabIndex = 3;
            this.DineInRdBtn.TabStop = true;
            this.DineInRdBtn.Text = "Dine-In";
            this.DineInRdBtn.UseVisualStyleBackColor = true;
            this.DineInRdBtn.CheckedChanged += new System.EventHandler(this.DineInRdBtn_CheckedChanged);
            // 
            // btnAddOrders
            // 
            this.btnAddOrders.AutoSize = true;
            this.btnAddOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrders.Location = new System.Drawing.Point(322, 139);
            this.btnAddOrders.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOrders.Name = "btnAddOrders";
            this.btnAddOrders.Size = new System.Drawing.Size(84, 27);
            this.btnAddOrders.TabIndex = 6;
            this.btnAddOrders.Text = "Add Order";
            this.btnAddOrders.UseVisualStyleBackColor = true;
            this.btnAddOrders.Click += new System.EventHandler(this.btnAddOrders_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(24, 139);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 187);
            this.Controls.Add(this.TakeAwayRdBtn);
            this.Controls.Add(this.DineInRdBtn);
            this.Controls.Add(this.btnAddOrders);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddOrder";
            this.Text = "AddOrder";
            this.Load += new System.EventHandler(this.AddOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton TakeAwayRdBtn;
        public System.Windows.Forms.RadioButton DineInRdBtn;
        private System.Windows.Forms.Button btnAddOrders;
        private System.Windows.Forms.Button btnCancel;
    }
}