namespace MagicJackSvcCreator
{
    partial class frmMain
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
            this.gbHardwareStatus = new System.Windows.Forms.GroupBox();
            this.btnForceHelp = new System.Windows.Forms.LinkLabel();
            this.cbForceDetection = new System.Windows.Forms.CheckBox();
            this.lblDevID = new System.Windows.Forms.Label();
            this.lblConnectStatus = new System.Windows.Forms.Label();
            this.gbSoftwareStatus = new System.Windows.Forms.GroupBox();
            this.lblDrvLtr = new System.Windows.Forms.Label();
            this.lblSoftPath = new System.Windows.Forms.Label();
            this.lblSoftStatus = new System.Windows.Forms.Label();
            this.gbConvert = new System.Windows.Forms.GroupBox();
            this.lblAlready2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblAlready = new System.Windows.Forms.Label();
            this.lblNotDone2 = new System.Windows.Forms.Label();
            this.lblNotDone = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.lblNTSvcStart = new System.Windows.Forms.Label();
            this.lblUpdtRegistry = new System.Windows.Forms.Label();
            this.lblCreateSvc = new System.Windows.Forms.Label();
            this.lblMove = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.llblAbout = new System.Windows.Forms.LinkLabel();
            this.gbHardwareStatus.SuspendLayout();
            this.gbSoftwareStatus.SuspendLayout();
            this.gbConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHardwareStatus
            // 
            this.gbHardwareStatus.Controls.Add(this.btnForceHelp);
            this.gbHardwareStatus.Controls.Add(this.cbForceDetection);
            this.gbHardwareStatus.Controls.Add(this.lblDevID);
            this.gbHardwareStatus.Controls.Add(this.lblConnectStatus);
            this.gbHardwareStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHardwareStatus.Location = new System.Drawing.Point(12, 12);
            this.gbHardwareStatus.Name = "gbHardwareStatus";
            this.gbHardwareStatus.Size = new System.Drawing.Size(480, 89);
            this.gbHardwareStatus.TabIndex = 1;
            this.gbHardwareStatus.TabStop = false;
            this.gbHardwareStatus.Text = "Hardware Status";
            // 
            // btnForceHelp
            // 
            this.btnForceHelp.AutoSize = true;
            this.btnForceHelp.Location = new System.Drawing.Point(450, 30);
            this.btnForceHelp.Name = "btnForceHelp";
            this.btnForceHelp.Size = new System.Drawing.Size(24, 17);
            this.btnForceHelp.TabIndex = 3;
            this.btnForceHelp.TabStop = true;
            this.btnForceHelp.Text = " ? ";
            this.btnForceHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnForceHelp_LinkClicked);
            // 
            // cbForceDetection
            // 
            this.cbForceDetection.AutoSize = true;
            this.cbForceDetection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbForceDetection.Location = new System.Drawing.Point(331, 31);
            this.cbForceDetection.Name = "cbForceDetection";
            this.cbForceDetection.Size = new System.Drawing.Size(122, 20);
            this.cbForceDetection.TabIndex = 2;
            this.cbForceDetection.Text = "Force Detection";
            this.cbForceDetection.UseVisualStyleBackColor = true;
            this.cbForceDetection.CheckedChanged += new System.EventHandler(this.cbForceDetection_CheckedChanged_1);
            // 
            // lblDevID
            // 
            this.lblDevID.AutoSize = true;
            this.lblDevID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevID.Location = new System.Drawing.Point(6, 54);
            this.lblDevID.Name = "lblDevID";
            this.lblDevID.Size = new System.Drawing.Size(64, 16);
            this.lblDevID.TabIndex = 1;
            this.lblDevID.Text = "DeviceID";
            // 
            // lblConnectStatus
            // 
            this.lblConnectStatus.AutoSize = true;
            this.lblConnectStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectStatus.Location = new System.Drawing.Point(6, 31);
            this.lblConnectStatus.Name = "lblConnectStatus";
            this.lblConnectStatus.Size = new System.Drawing.Size(104, 16);
            this.lblConnectStatus.TabIndex = 0;
            this.lblConnectStatus.Text = "HardwareStatus";
            // 
            // gbSoftwareStatus
            // 
            this.gbSoftwareStatus.Controls.Add(this.lblDrvLtr);
            this.gbSoftwareStatus.Controls.Add(this.lblSoftPath);
            this.gbSoftwareStatus.Controls.Add(this.lblSoftStatus);
            this.gbSoftwareStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSoftwareStatus.Location = new System.Drawing.Point(6, 107);
            this.gbSoftwareStatus.Name = "gbSoftwareStatus";
            this.gbSoftwareStatus.Size = new System.Drawing.Size(480, 113);
            this.gbSoftwareStatus.TabIndex = 4;
            this.gbSoftwareStatus.TabStop = false;
            this.gbSoftwareStatus.Text = "Software Status";
            // 
            // lblDrvLtr
            // 
            this.lblDrvLtr.AutoSize = true;
            this.lblDrvLtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrvLtr.Location = new System.Drawing.Point(6, 79);
            this.lblDrvLtr.Name = "lblDrvLtr";
            this.lblDrvLtr.Size = new System.Drawing.Size(73, 16);
            this.lblDrvLtr.TabIndex = 2;
            this.lblDrvLtr.Text = "DriveLetter";
            // 
            // lblSoftPath
            // 
            this.lblSoftPath.AutoSize = true;
            this.lblSoftPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftPath.Location = new System.Drawing.Point(6, 54);
            this.lblSoftPath.Name = "lblSoftPath";
            this.lblSoftPath.Size = new System.Drawing.Size(69, 16);
            this.lblSoftPath.TabIndex = 1;
            this.lblSoftPath.Text = "InstallPath";
            // 
            // lblSoftStatus
            // 
            this.lblSoftStatus.AutoSize = true;
            this.lblSoftStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftStatus.Location = new System.Drawing.Point(6, 31);
            this.lblSoftStatus.Name = "lblSoftStatus";
            this.lblSoftStatus.Size = new System.Drawing.Size(97, 16);
            this.lblSoftStatus.TabIndex = 0;
            this.lblSoftStatus.Text = "SoftwareStatus";
            // 
            // gbConvert
            // 
            this.gbConvert.Controls.Add(this.lblAlready2);
            this.gbConvert.Controls.Add(this.btnRemove);
            this.gbConvert.Controls.Add(this.lblAlready);
            this.gbConvert.Controls.Add(this.lblNotDone2);
            this.gbConvert.Controls.Add(this.lblNotDone);
            this.gbConvert.Controls.Add(this.btnStart);
            this.gbConvert.Controls.Add(this.pb1);
            this.gbConvert.Controls.Add(this.lblNTSvcStart);
            this.gbConvert.Controls.Add(this.lblUpdtRegistry);
            this.gbConvert.Controls.Add(this.lblCreateSvc);
            this.gbConvert.Controls.Add(this.lblMove);
            this.gbConvert.Controls.Add(this.lblStop);
            this.gbConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConvert.Location = new System.Drawing.Point(6, 226);
            this.gbConvert.Name = "gbConvert";
            this.gbConvert.Size = new System.Drawing.Size(480, 266);
            this.gbConvert.TabIndex = 3;
            this.gbConvert.TabStop = false;
            this.gbConvert.Text = "Convert to Run as Background Service";
            // 
            // lblAlready2
            // 
            this.lblAlready2.AutoSize = true;
            this.lblAlready2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlready2.ForeColor = System.Drawing.Color.Green;
            this.lblAlready2.Location = new System.Drawing.Point(7, 81);
            this.lblAlready2.Name = "lblAlready2";
            this.lblAlready2.Size = new System.Drawing.Size(428, 13);
            this.lblAlready2.TabIndex = 11;
            this.lblAlready2.Text = "Click button below to remove Windows service and re-activate desktop UI";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(9, 168);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(464, 39);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove Windows Service";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // lblAlready
            // 
            this.lblAlready.AutoSize = true;
            this.lblAlready.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlready.ForeColor = System.Drawing.Color.Green;
            this.lblAlready.Location = new System.Drawing.Point(6, 63);
            this.lblAlready.Name = "lblAlready";
            this.lblAlready.Size = new System.Drawing.Size(382, 18);
            this.lblAlready.TabIndex = 9;
            this.lblAlready.Text = "MagicJack Windows service is currently installed.";
            // 
            // lblNotDone2
            // 
            this.lblNotDone2.AutoSize = true;
            this.lblNotDone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotDone2.Location = new System.Drawing.Point(6, 77);
            this.lblNotDone2.Name = "lblNotDone2";
            this.lblNotDone2.Size = new System.Drawing.Size(389, 18);
            this.lblNotDone2.TabIndex = 8;
            this.lblNotDone2.Text = "and run it behind the scenes as a Windows service";
            // 
            // lblNotDone
            // 
            this.lblNotDone.AutoSize = true;
            this.lblNotDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotDone.Location = new System.Drawing.Point(6, 58);
            this.lblNotDone.Name = "lblNotDone";
            this.lblNotDone.Size = new System.Drawing.Size(405, 18);
            this.lblNotDone.TabIndex = 7;
            this.lblNotDone.Text = "Click below to remove MagicJack from your desktop";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(9, 168);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(464, 39);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Install Windows Service";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(9, 227);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(464, 23);
            this.pb1.TabIndex = 5;
            // 
            // lblNTSvcStart
            // 
            this.lblNTSvcStart.AutoSize = true;
            this.lblNTSvcStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTSvcStart.Location = new System.Drawing.Point(6, 129);
            this.lblNTSvcStart.Name = "lblNTSvcStart";
            this.lblNTSvcStart.Size = new System.Drawing.Size(173, 16);
            this.lblNTSvcStart.TabIndex = 4;
            this.lblNTSvcStart.Text = "Start MagicJack NT service";
            // 
            // lblUpdtRegistry
            // 
            this.lblUpdtRegistry.AutoSize = true;
            this.lblUpdtRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdtRegistry.Location = new System.Drawing.Point(6, 105);
            this.lblUpdtRegistry.Name = "lblUpdtRegistry";
            this.lblUpdtRegistry.Size = new System.Drawing.Size(146, 16);
            this.lblUpdtRegistry.TabIndex = 3;
            this.lblUpdtRegistry.Text = "Update system registry";
            // 
            // lblCreateSvc
            // 
            this.lblCreateSvc.AutoSize = true;
            this.lblCreateSvc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateSvc.Location = new System.Drawing.Point(6, 81);
            this.lblCreateSvc.Name = "lblCreateSvc";
            this.lblCreateSvc.Size = new System.Drawing.Size(117, 16);
            this.lblCreateSvc.TabIndex = 2;
            this.lblCreateSvc.Text = "Create NT service";
            // 
            // lblMove
            // 
            this.lblMove.AutoSize = true;
            this.lblMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMove.Location = new System.Drawing.Point(6, 58);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(180, 16);
            this.lblMove.TabIndex = 1;
            this.lblMove.Text = "Move install out of user folder";
            // 
            // lblStop
            // 
            this.lblStop.AutoSize = true;
            this.lblStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStop.Location = new System.Drawing.Point(6, 36);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(204, 16);
            this.lblStop.TabIndex = 0;
            this.lblStop.Text = "Stop MagicJack desktop service";
            // 
            // llblAbout
            // 
            this.llblAbout.AutoSize = true;
            this.llblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblAbout.Location = new System.Drawing.Point(443, 495);
            this.llblAbout.Name = "llblAbout";
            this.llblAbout.Size = new System.Drawing.Size(45, 17);
            this.llblAbout.TabIndex = 5;
            this.llblAbout.TabStop = true;
            this.llblAbout.Text = "About";
            this.llblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAbout_LinkClicked_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 542);
            this.Controls.Add(this.llblAbout);
            this.Controls.Add(this.gbConvert);
            this.Controls.Add(this.gbSoftwareStatus);
            this.Controls.Add(this.gbHardwareStatus);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 580);
            this.MinimumSize = new System.Drawing.Size(520, 580);
            this.Name = "frmMain";
            this.Text = "MSC";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.gbHardwareStatus.ResumeLayout(false);
            this.gbHardwareStatus.PerformLayout();
            this.gbSoftwareStatus.ResumeLayout(false);
            this.gbSoftwareStatus.PerformLayout();
            this.gbConvert.ResumeLayout(false);
            this.gbConvert.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbHardwareStatus;
        internal System.Windows.Forms.LinkLabel btnForceHelp;
        internal System.Windows.Forms.CheckBox cbForceDetection;
        internal System.Windows.Forms.Label lblDevID;
        internal System.Windows.Forms.Label lblConnectStatus;
        internal System.Windows.Forms.GroupBox gbSoftwareStatus;
        internal System.Windows.Forms.Label lblDrvLtr;
        internal System.Windows.Forms.Label lblSoftPath;
        internal System.Windows.Forms.Label lblSoftStatus;
        internal System.Windows.Forms.GroupBox gbConvert;
        internal System.Windows.Forms.Label lblAlready2;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.Label lblAlready;
        internal System.Windows.Forms.Label lblNotDone2;
        internal System.Windows.Forms.Label lblNotDone;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.ProgressBar pb1;
        internal System.Windows.Forms.Label lblNTSvcStart;
        internal System.Windows.Forms.Label lblUpdtRegistry;
        internal System.Windows.Forms.Label lblCreateSvc;
        internal System.Windows.Forms.Label lblMove;
        internal System.Windows.Forms.Label lblStop;
        internal System.Windows.Forms.LinkLabel llblAbout;
    }
}

