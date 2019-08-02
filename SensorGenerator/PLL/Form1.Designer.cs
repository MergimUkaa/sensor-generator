namespace SensorGenerator
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Remote");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Hospitalizations");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Patients", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.btnGenerate = new System.Windows.Forms.Button();
            this.sensorTimer = new System.Windows.Forms.Timer(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkSelectUnselect = new System.Windows.Forms.CheckBox();
            this.radioMinute = new System.Windows.Forms.RadioButton();
            this.radioSecond = new System.Windows.Forms.RadioButton();
            this.numericInterval = new System.Windows.Forms.NumericUpDown();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblCountPatients = new System.Windows.Forms.Label();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(26, 75);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(192, 40);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Start generating";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // sensorTimer
            // 
            this.sensorTimer.Enabled = true;
            this.sensorTimer.Interval = 1;
            this.sensorTimer.Tick += new System.EventHandler(this.sensorTimer_Tick);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(26, 175);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "remote";
            treeNode7.Text = "Remote";
            treeNode8.Name = "hospitalizations";
            treeNode8.Text = "Hospitalizations";
            treeNode9.Name = "patients";
            treeNode9.Text = "Patients";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(354, 800);
            this.treeView1.TabIndex = 11;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(-3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkSelectUnselect);
            this.splitContainer1.Panel1.Controls.Add(this.radioMinute);
            this.splitContainer1.Panel1.Controls.Add(this.radioSecond);
            this.splitContainer1.Panel1.Controls.Add(this.numericInterval);
            this.splitContainer1.Panel1.Controls.Add(this.lblInterval);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblCountPatients);
            this.splitContainer1.Panel2.Controls.Add(this.gmap);
            this.splitContainer1.Size = new System.Drawing.Size(1646, 994);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 12;
            // 
            // chkSelectUnselect
            // 
            this.chkSelectUnselect.AutoSize = true;
            this.chkSelectUnselect.Location = new System.Drawing.Point(26, 136);
            this.chkSelectUnselect.Name = "chkSelectUnselect";
            this.chkSelectUnselect.Size = new System.Drawing.Size(193, 24);
            this.chkSelectUnselect.TabIndex = 1;
            this.chkSelectUnselect.Text = "Select all / Unselect all";
            this.chkSelectUnselect.UseVisualStyleBackColor = true;
            this.chkSelectUnselect.CheckedChanged += new System.EventHandler(this.chkSelectUnselect_CheckedChanged);
            // 
            // radioMinute
            // 
            this.radioMinute.AutoSize = true;
            this.radioMinute.Location = new System.Drawing.Point(242, 45);
            this.radioMinute.Name = "radioMinute";
            this.radioMinute.Size = new System.Drawing.Size(59, 24);
            this.radioMinute.TabIndex = 13;
            this.radioMinute.TabStop = true;
            this.radioMinute.Text = "Min";
            this.radioMinute.UseVisualStyleBackColor = true;
            // 
            // radioSecond
            // 
            this.radioSecond.AutoSize = true;
            this.radioSecond.Location = new System.Drawing.Point(163, 45);
            this.radioSecond.Name = "radioSecond";
            this.radioSecond.Size = new System.Drawing.Size(62, 24);
            this.radioSecond.TabIndex = 1;
            this.radioSecond.TabStop = true;
            this.radioSecond.Text = "Sec";
            this.radioSecond.UseVisualStyleBackColor = true;
            // 
            // numericInterval
            // 
            this.numericInterval.Location = new System.Drawing.Point(26, 43);
            this.numericInterval.Name = "numericInterval";
            this.numericInterval.Size = new System.Drawing.Size(120, 26);
            this.numericInterval.TabIndex = 1;
            this.numericInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(22, 11);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(61, 20);
            this.lblInterval.TabIndex = 12;
            this.lblInterval.Text = "Interval";
            // 
            // lblCountPatients
            // 
            this.lblCountPatients.AutoSize = true;
            this.lblCountPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountPatients.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblCountPatients.Location = new System.Drawing.Point(3, 86);
            this.lblCountPatients.Name = "lblCountPatients";
            this.lblCountPatients.Size = new System.Drawing.Size(406, 29);
            this.lblCountPatients.TabIndex = 13;
            this.lblCountPatients.Text = "0 patient ready for sending to Kafka...";
            // 
            // gmap
            // 
            this.gmap.AutoScroll = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(8, 175);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 20;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1296, 800);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1654, 1072);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Sensor Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Timer sensorTimer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.CheckBox chkSelectUnselect;
        private System.Windows.Forms.RadioButton radioMinute;
        private System.Windows.Forms.RadioButton radioSecond;
        private System.Windows.Forms.NumericUpDown numericInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblCountPatients;
    }
}

