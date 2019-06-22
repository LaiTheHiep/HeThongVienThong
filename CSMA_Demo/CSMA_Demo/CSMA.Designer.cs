namespace CSMA_Demo
{
    partial class CSMA
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbData = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cbComputerSend = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTypeCSMA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.cbComputerReceive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTypeData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCollision = new System.Windows.Forms.Button();
            this.btnCreateChanel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnViewProcess = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data input";
            // 
            // txbData
            // 
            this.txbData.Location = new System.Drawing.Point(99, 3);
            this.txbData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbData.Multiline = true;
            this.txbData.Name = "txbData";
            this.txbData.Size = new System.Drawing.Size(368, 111);
            this.txbData.TabIndex = 1;
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(475, 6);
            this.btnFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(35, 34);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Computer Send";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(518, 6);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 34);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(20, 42);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(104, 36);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cbComputerSend
            // 
            this.cbComputerSend.FormattingEnabled = true;
            this.cbComputerSend.Location = new System.Drawing.Point(152, 66);
            this.cbComputerSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbComputerSend.Name = "cbComputerSend";
            this.cbComputerSend.Size = new System.Drawing.Size(225, 21);
            this.cbComputerSend.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Algorithm CSMA";
            // 
            // cbTypeCSMA
            // 
            this.cbTypeCSMA.FormattingEnabled = true;
            this.cbTypeCSMA.Location = new System.Drawing.Point(152, 18);
            this.cbTypeCSMA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTypeCSMA.Name = "cbTypeCSMA";
            this.cbTypeCSMA.Size = new System.Drawing.Size(225, 21);
            this.cbTypeCSMA.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data receive";
            // 
            // txbOutput
            // 
            this.txbOutput.Location = new System.Drawing.Point(132, 1);
            this.txbOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txbOutput.Multiline = true;
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.Size = new System.Drawing.Size(324, 111);
            this.txbOutput.TabIndex = 12;
            // 
            // cbComputerReceive
            // 
            this.cbComputerReceive.FormattingEnabled = true;
            this.cbComputerReceive.Location = new System.Drawing.Point(565, 66);
            this.cbComputerReceive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbComputerReceive.Name = "cbComputerReceive";
            this.cbComputerReceive.Size = new System.Drawing.Size(225, 21);
            this.cbComputerReceive.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(400, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Computer Receive";
            // 
            // btnTypeData
            // 
            this.btnTypeData.Location = new System.Drawing.Point(475, 46);
            this.btnTypeData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTypeData.Name = "btnTypeData";
            this.btnTypeData.Size = new System.Drawing.Size(35, 29);
            this.btnTypeData.TabIndex = 15;
            this.btnTypeData.Text = "MM";
            this.btnTypeData.UseVisualStyleBackColor = true;
            this.btnTypeData.Click += new System.EventHandler(this.btnTypeData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearData.Location = new System.Drawing.Point(10, 73);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(76, 38);
            this.btnClearData.TabIndex = 16;
            this.btnClearData.Text = "Reset Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Enabled = false;
            this.dgvView.Location = new System.Drawing.Point(4, 5);
            this.dgvView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(550, 379);
            this.dgvView.TabIndex = 18;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(561, 138);
            this.btnView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 31);
            this.btnView.TabIndex = 19;
            this.btnView.Text = "G and S";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCollision
            // 
            this.btnCollision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollision.Location = new System.Drawing.Point(561, 73);
            this.btnCollision.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCollision.Name = "btnCollision";
            this.btnCollision.Size = new System.Drawing.Size(90, 59);
            this.btnCollision.TabIndex = 20;
            this.btnCollision.Text = "Create Collision";
            this.btnCollision.UseVisualStyleBackColor = true;
            this.btnCollision.TextChanged += new System.EventHandler(this.btnCollision_TextChanged);
            this.btnCollision.Click += new System.EventHandler(this.btnCollision_Click);
            // 
            // btnCreateChanel
            // 
            this.btnCreateChanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateChanel.Location = new System.Drawing.Point(10, 34);
            this.btnCreateChanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateChanel.Name = "btnCreateChanel";
            this.btnCreateChanel.Size = new System.Drawing.Size(76, 36);
            this.btnCreateChanel.TabIndex = 21;
            this.btnCreateChanel.Text = "Set up";
            this.btnCreateChanel.UseVisualStyleBackColor = true;
            this.btnCreateChanel.Click += new System.EventHandler(this.btnCreateChanel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Line Red";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(15, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Line Yellow";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(110, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sending";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(110, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Waitting";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(1100, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 112);
            this.panel1.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(108, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Not use channel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Line Black";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbOutput);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnDownload);
            this.panel2.Location = new System.Drawing.Point(638, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 117);
            this.panel2.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.txbData);
            this.panel3.Controls.Add(this.btnClearData);
            this.panel3.Controls.Add(this.btnFile);
            this.panel3.Controls.Add(this.btnCreateChanel);
            this.panel3.Controls.Add(this.btnTypeData);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 117);
            this.panel3.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbTypeCSMA);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cbComputerSend);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbComputerReceive);
            this.panel4.Location = new System.Drawing.Point(3, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1089, 108);
            this.panel4.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnGraph);
            this.panel5.Controls.Add(this.btnViewProcess);
            this.panel5.Controls.Add(this.dgvView);
            this.panel5.Controls.Add(this.btnCollision);
            this.panel5.Controls.Add(this.btnView);
            this.panel5.Location = new System.Drawing.Point(3, 249);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(666, 390);
            this.panel5.TabIndex = 30;
            // 
            // btnViewProcess
            // 
            this.btnViewProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewProcess.Location = new System.Drawing.Point(561, 14);
            this.btnViewProcess.Name = "btnViewProcess";
            this.btnViewProcess.Size = new System.Drawing.Size(90, 53);
            this.btnViewProcess.TabIndex = 22;
            this.btnViewProcess.Text = "View Proccess";
            this.btnViewProcess.UseVisualStyleBackColor = true;
            this.btnViewProcess.Click += new System.EventHandler(this.btnViewProcess_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph.Location = new System.Drawing.Point(561, 175);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(90, 33);
            this.btnGraph.TabIndex = 23;
            this.btnGraph.Text = "Graph Theory";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // CSMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 651);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CSMA";
            this.Text = "Carrier Sense Multiple Access";
            this.Load += new System.EventHandler(this.CSMA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbData;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cbComputerSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTypeCSMA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.ComboBox cbComputerReceive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTypeData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCollision;
        private System.Windows.Forms.Button btnCreateChanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnViewProcess;
        private System.Windows.Forms.Button btnGraph;
    }
}

