namespace Mini_Cafe__Be_in_One_
{
    partial class EditInformation
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDrinks = new System.Windows.Forms.Button();
            this.btCashier = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(763, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cashier information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(23, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 500);
            this.panel1.TabIndex = 14;
            // 
            // btDrinks
            // 
            this.btDrinks.Location = new System.Drawing.Point(104, 15);
            this.btDrinks.Name = "btDrinks";
            this.btDrinks.Size = new System.Drawing.Size(75, 23);
            this.btDrinks.TabIndex = 13;
            this.btDrinks.Text = "Drinks";
            this.btDrinks.UseVisualStyleBackColor = true;
            this.btDrinks.Click += new System.EventHandler(this.BtDrinks_Click);
            // 
            // btCashier
            // 
            this.btCashier.Location = new System.Drawing.Point(23, 15);
            this.btCashier.Name = "btCashier";
            this.btCashier.Size = new System.Drawing.Size(75, 23);
            this.btCashier.TabIndex = 12;
            this.btCashier.Text = "Cashiers";
            this.btCashier.UseVisualStyleBackColor = true;
            this.btCashier.Click += new System.EventHandler(this.BtCashier_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1078, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btDrinks);
            this.Controls.Add(this.btCashier);
            this.Name = "EditInformation";
            this.Text = "EditInformation";
            this.Load += new System.EventHandler(this.EditInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btDrinks;
        private System.Windows.Forms.Button btCashier;
        private System.Windows.Forms.Button button1;
    }
}