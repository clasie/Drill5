
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_log = new System.Windows.Forms.TextBox();
            this.btn_CallDirectAsyncAndReturn = new System.Windows.Forms.Button();
            this.btn_CallDirectAsyncAndNoReturn = new System.Windows.Forms.Button();
            this.btn_CallIndirectAsyncAndReturn = new System.Windows.Forms.Button();
            this.btn_CallIndirectAsyncAndNoReturn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_CallDirectSyncAndReturn = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_features = new System.Windows.Forms.Button();
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
            this.btn_getData.Location = new System.Drawing.Point(494, 85);
            this.btn_getData.Name = "btn_getData";
            this.btn_getData.Size = new System.Drawing.Size(261, 29);
            this.btn_getData.TabIndex = 1;
            this.btn_getData.Text = "Get data";
            this.btn_getData.UseVisualStyleBackColor = true;
            this.btn_getData.Click += new System.EventHandler(this.btn_getData_Click);
            // 
            // btn_insertData
            // 
            this.btn_insertData.Location = new System.Drawing.Point(494, 132);
            this.btn_insertData.Name = "btn_insertData";
            this.btn_insertData.Size = new System.Drawing.Size(261, 29);
            this.btn_insertData.TabIndex = 2;
            this.btn_insertData.Text = "InsertData";
            this.btn_insertData.UseVisualStyleBackColor = true;
            this.btn_insertData.Click += new System.EventHandler(this.btn_insertData_Click);
            // 
            // btn_updateData
            // 
            this.btn_updateData.Location = new System.Drawing.Point(494, 177);
            this.btn_updateData.Name = "btn_updateData";
            this.btn_updateData.Size = new System.Drawing.Size(261, 29);
            this.btn_updateData.TabIndex = 3;
            this.btn_updateData.Text = "UpdateData";
            this.btn_updateData.UseVisualStyleBackColor = true;
            this.btn_updateData.Click += new System.EventHandler(this.btn_updateData_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(494, 226);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(261, 29);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Log";
            // 
            // tbx_log
            // 
            this.tbx_log.Location = new System.Drawing.Point(208, 327);
            this.tbx_log.Multiline = true;
            this.tbx_log.Name = "tbx_log";
            this.tbx_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_log.Size = new System.Drawing.Size(531, 54);
            this.tbx_log.TabIndex = 9;
            // 
            // btn_CallDirectAsyncAndReturn
            // 
            this.btn_CallDirectAsyncAndReturn.Location = new System.Drawing.Point(208, 556);
            this.btn_CallDirectAsyncAndReturn.Name = "btn_CallDirectAsyncAndReturn";
            this.btn_CallDirectAsyncAndReturn.Size = new System.Drawing.Size(403, 29);
            this.btn_CallDirectAsyncAndReturn.TabIndex = 10;
            this.btn_CallDirectAsyncAndReturn.Text = "btn_CallDirectAsyncAndReturn";
            this.btn_CallDirectAsyncAndReturn.UseVisualStyleBackColor = true;
            this.btn_CallDirectAsyncAndReturn.Click += new System.EventHandler(this.btn_CallDirectAsyncAndReturn_Click);
            // 
            // btn_CallDirectAsyncAndNoReturn
            // 
            this.btn_CallDirectAsyncAndNoReturn.Location = new System.Drawing.Point(208, 604);
            this.btn_CallDirectAsyncAndNoReturn.Name = "btn_CallDirectAsyncAndNoReturn";
            this.btn_CallDirectAsyncAndNoReturn.Size = new System.Drawing.Size(403, 29);
            this.btn_CallDirectAsyncAndNoReturn.TabIndex = 11;
            this.btn_CallDirectAsyncAndNoReturn.Text = "btn_CallDirectAsyncAndNoReturn";
            this.btn_CallDirectAsyncAndNoReturn.UseVisualStyleBackColor = true;
            this.btn_CallDirectAsyncAndNoReturn.Click += new System.EventHandler(this.btn_CallDirectAsyncAndNoReturn_Click);
            // 
            // btn_CallIndirectAsyncAndReturn
            // 
            this.btn_CallIndirectAsyncAndReturn.Location = new System.Drawing.Point(208, 658);
            this.btn_CallIndirectAsyncAndReturn.Name = "btn_CallIndirectAsyncAndReturn";
            this.btn_CallIndirectAsyncAndReturn.Size = new System.Drawing.Size(403, 29);
            this.btn_CallIndirectAsyncAndReturn.TabIndex = 12;
            this.btn_CallIndirectAsyncAndReturn.Text = "btn_CallIndirectAsyncAndReturn";
            this.btn_CallIndirectAsyncAndReturn.UseVisualStyleBackColor = true;
            this.btn_CallIndirectAsyncAndReturn.Click += new System.EventHandler(this.btn_CallIndirectAsyncAndReturn_Click);
            // 
            // btn_CallIndirectAsyncAndNoReturn
            // 
            this.btn_CallIndirectAsyncAndNoReturn.Location = new System.Drawing.Point(208, 711);
            this.btn_CallIndirectAsyncAndNoReturn.Name = "btn_CallIndirectAsyncAndNoReturn";
            this.btn_CallIndirectAsyncAndNoReturn.Size = new System.Drawing.Size(403, 29);
            this.btn_CallIndirectAsyncAndNoReturn.TabIndex = 13;
            this.btn_CallIndirectAsyncAndNoReturn.Text = "btn_CallIndirectAsyncAndNoReturn";
            this.btn_CallIndirectAsyncAndNoReturn.UseVisualStyleBackColor = true;
            this.btn_CallIndirectAsyncAndNoReturn.Click += new System.EventHandler(this.btn_CallIndirectAsyncAndNoReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Async";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sync";
            // 
            // btn_CallDirectSyncAndReturn
            // 
            this.btn_CallDirectSyncAndReturn.Location = new System.Drawing.Point(208, 450);
            this.btn_CallDirectSyncAndReturn.Name = "btn_CallDirectSyncAndReturn";
            this.btn_CallDirectSyncAndReturn.Size = new System.Drawing.Size(403, 29);
            this.btn_CallDirectSyncAndReturn.TabIndex = 16;
            this.btn_CallDirectSyncAndReturn.Text = "btn_CallDirectSyncAndReturn";
            this.btn_CallDirectSyncAndReturn.UseVisualStyleBackColor = true;
            this.btn_CallDirectSyncAndReturn.Click += new System.EventHandler(this.btn_CallDirectSyncAndReturn_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(208, 226);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(261, 29);
            this.btn_clear.TabIndex = 17;
            this.btn_clear.Text = "btn_clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 760);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Features";
            // 
            // btn_features
            // 
            this.btn_features.Location = new System.Drawing.Point(208, 786);
            this.btn_features.Name = "btn_features";
            this.btn_features.Size = new System.Drawing.Size(403, 29);
            this.btn_features.TabIndex = 19;
            this.btn_features.Text = "Test 10 Features";
            this.btn_features.UseVisualStyleBackColor = true;
            this.btn_features.Click += new System.EventHandler(this.btn_features_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 898);
            this.Controls.Add(this.btn_features);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_CallDirectSyncAndReturn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_CallIndirectAsyncAndNoReturn);
            this.Controls.Add(this.btn_CallIndirectAsyncAndReturn);
            this.Controls.Add(this.btn_CallDirectAsyncAndNoReturn);
            this.Controls.Add(this.btn_CallDirectAsyncAndReturn);
            this.Controls.Add(this.tbx_log);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_updateData);
            this.Controls.Add(this.btn_insertData);
            this.Controls.Add(this.btn_getData);
            this.Controls.Add(this.btn_testConnection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_testConnection;
        private System.Windows.Forms.Button btn_getData;
        private System.Windows.Forms.Button btn_insertData;
        private System.Windows.Forms.Button btn_updateData;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_log;
        private System.Windows.Forms.Button btn_CallDirectAsyncAndReturn;
        private System.Windows.Forms.Button btn_CallDirectAsyncAndNoReturn;
        private System.Windows.Forms.Button btn_CallIndirectAsyncAndReturn;
        private System.Windows.Forms.Button btn_CallIndirectAsyncAndNoReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_CallDirectSyncAndReturn;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_features;
    }
}

