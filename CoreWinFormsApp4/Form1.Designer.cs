
namespace CoreWinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_testConnection = new System.Windows.Forms.Button();
            this.btn_getData = new System.Windows.Forms.Button();
            this.btn_insertData = new System.Windows.Forms.Button();
            this.btn_updateData = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_testConnection
            // 
            this.btn_testConnection.Location = new System.Drawing.Point(208, 85);
            this.btn_testConnection.Name = "btn_testConnection";
            this.btn_testConnection.Size = new System.Drawing.Size(261, 29);
            this.btn_testConnection.TabIndex = 0;
            this.btn_testConnection.Text = "Test Connection";
            this.btn_testConnection.UseVisualStyleBackColor = true;
            this.btn_testConnection.Click += new System.EventHandler(this.btn_testConnection_Click);
            // 
            // btn_getData
            // 
            this.btn_getData.Location = new System.Drawing.Point(208, 134);
            this.btn_getData.Name = "btn_getData";
            this.btn_getData.Size = new System.Drawing.Size(261, 29);
            this.btn_getData.TabIndex = 1;
            this.btn_getData.Text = "Get data";
            this.btn_getData.UseVisualStyleBackColor = true;
            this.btn_getData.Click += new System.EventHandler(this.btn_getData_Click);
            // 
            // btn_insertData
            // 
            this.btn_insertData.Location = new System.Drawing.Point(208, 181);
            this.btn_insertData.Name = "btn_insertData";
            this.btn_insertData.Size = new System.Drawing.Size(261, 29);
            this.btn_insertData.TabIndex = 2;
            this.btn_insertData.Text = "InsertData";
            this.btn_insertData.UseVisualStyleBackColor = true;
            this.btn_insertData.Click += new System.EventHandler(this.btn_insertData_Click);
            // 
            // btn_updateData
            // 
            this.btn_updateData.Location = new System.Drawing.Point(208, 226);
            this.btn_updateData.Name = "btn_updateData";
            this.btn_updateData.Size = new System.Drawing.Size(261, 29);
            this.btn_updateData.TabIndex = 3;
            this.btn_updateData.Text = "UpdateData";
            this.btn_updateData.UseVisualStyleBackColor = true;
            this.btn_updateData.Click += new System.EventHandler(this.btn_updateData_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(208, 275);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(261, 29);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_updateData);
            this.Controls.Add(this.btn_insertData);
            this.Controls.Add(this.btn_getData);
            this.Controls.Add(this.btn_testConnection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_testConnection;
        private System.Windows.Forms.Button btn_getData;
        private System.Windows.Forms.Button btn_insertData;
        private System.Windows.Forms.Button btn_updateData;
        private System.Windows.Forms.Button btn_delete;
    }
}

