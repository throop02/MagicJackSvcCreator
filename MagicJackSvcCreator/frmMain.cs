using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicJackSvcCreator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private MagicJackSvcCreator.SysData objSysData;
	    private BackgroundWorker withEventsField_InstallWorker;
        private Constants ac;

        //Handles service installation
        private BackgroundWorker InstallWorker {
		    get { return withEventsField_InstallWorker; }
		    set {
			    if (withEventsField_InstallWorker != null) {
				    withEventsField_InstallWorker.DoWork -= InstallWorker_DoWork;
				    withEventsField_InstallWorker.RunWorkerCompleted -= InstallWorker_Completed;
				    withEventsField_InstallWorker.ProgressChanged -= InstallWorker_ProgressChanged;
			    }
			    withEventsField_InstallWorker = value;
			    if (withEventsField_InstallWorker != null) {
				    withEventsField_InstallWorker.DoWork += InstallWorker_DoWork;
				    withEventsField_InstallWorker.RunWorkerCompleted += InstallWorker_Completed;
				    withEventsField_InstallWorker.ProgressChanged += InstallWorker_ProgressChanged;
			    }
		    }

	    }

        //Handles service removal
	    private BackgroundWorker withEventsField_RemoveWorker;
	    private BackgroundWorker RemoveWorker {
		    get { return withEventsField_RemoveWorker; }
		    set {
			    if (withEventsField_RemoveWorker != null) {
				    withEventsField_RemoveWorker.DoWork -= RemoveWorker_DoWork;
				    withEventsField_RemoveWorker.RunWorkerCompleted -= RemoveWorker_Completed;
				    withEventsField_RemoveWorker.ProgressChanged -= RemoveWorker_ProgressChanged;
			    }
			    withEventsField_RemoveWorker = value;
			    if (withEventsField_RemoveWorker != null) {
				    withEventsField_RemoveWorker.DoWork += RemoveWorker_DoWork;
				    withEventsField_RemoveWorker.RunWorkerCompleted += RemoveWorker_Completed;
				    withEventsField_RemoveWorker.ProgressChanged += RemoveWorker_ProgressChanged;
			    }
		    }
	    }


	#region "Event Handlers"


    private void frmMain_Load_1(object sender, EventArgs e)
	{
		//CheckForUpdates();
        ac = new Constants();

        this.Text = ac.c_sMSCTitle + " - GNU [Vanilla]";

		InstallWorker = new BackgroundWorker();
		RemoveWorker = new BackgroundWorker();

		var _with1 = InstallWorker;
		_with1.WorkerReportsProgress = true;
		_with1.WorkerSupportsCancellation = false;
		var _with2 = RemoveWorker;
		_with2.WorkerReportsProgress = true;
		_with2.WorkerSupportsCancellation = false;

		StartApp();

	}

    private void llblAbout_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
	{
		About ab = new About();
		ab.Show();
	}

    private void cbForceDetection_CheckedChanged_1(object sender, EventArgs e)
	{
		cbForceDetection.Refresh();
		StartApp();
	}

	private void btnForceHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
        MessageBox.Show(ac.c_sForceDetectionInfo, ac.c_sForceDetectionMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
	}


	private void InstallWorker_DoWork(System.Object sender, DoWorkEventArgs e)
	{
        MagicJackSvcCreator.SysData objWorkerSysData = default(MagicJackSvcCreator.SysData);
        objWorkerSysData = (MagicJackSvcCreator.SysData)e.Argument;

		InstallService(objWorkerSysData);

	}


	private void RemoveWorker_DoWork(System.Object sender, DoWorkEventArgs e)
	{
        MagicJackSvcCreator.SysData objWorkerSysData = default(MagicJackSvcCreator.SysData);
        objWorkerSysData = (MagicJackSvcCreator.SysData)e.Argument;

		RemoveService(objWorkerSysData);

	}

	private void InstallWorker_Completed(System.Object sender, RunWorkerCompletedEventArgs e)
	{
		StartApp();
	}

	private void RemoveWorker_Completed(System.Object sender, RunWorkerCompletedEventArgs e)
	{
		StartApp();
	}


	private void RemoveWorker_ProgressChanged(System.Object sender, ProgressChangedEventArgs e)
	{
		pb1.Value = e.ProgressPercentage;

	}


	private void InstallWorker_ProgressChanged(System.Object sender, ProgressChangedEventArgs e)
	{
        MagicJackSvcCreator.Enums.ProgressData objProgress = default(MagicJackSvcCreator.Enums.ProgressData);
        objProgress = (MagicJackSvcCreator.Enums.ProgressData)e.UserState;

		switch (objProgress.ProgressStatus) {

            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.KillMJPassed:
				lblStop.ForeColor = Color.Green;
				lblMove.ForeColor = Color.Blue;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.KillMJFailed:
				lblStop.ForeColor = Color.Red;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveInstallPassed:
				lblMove.ForeColor = Color.Green;
				lblCreateSvc.ForeColor = Color.Blue;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveInstallFailed:
				lblMove.ForeColor = Color.Red;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.CreateServicePassed:
				lblCreateSvc.ForeColor = Color.Green;
				lblUpdtRegistry.ForeColor = Color.Blue;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.CreateServiceFailed:
				lblCreateSvc.ForeColor = Color.Red;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.UpdateRegistryPassed:
				lblUpdtRegistry.ForeColor = Color.Green;
				lblNTSvcStart.ForeColor = Color.Blue;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.UpdateRegistryFailed:
				lblUpdtRegistry.ForeColor = Color.Red;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.StartServicePassed:
				lblNTSvcStart.ForeColor = Color.Green;

				break;
            case MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.StartServiceFailed:
				lblNTSvcStart.ForeColor = Color.Red;

				break;
		}

		if (!string.IsNullOrEmpty(objProgress.sExceptionMessage)) {
            MessageBox.Show(objProgress.sExceptionMessage, ac.c_sMessageTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		pb1.Value = e.ProgressPercentage;

	}


    private void btnStart_Click_1(object sender, EventArgs e)
	{

		if (ValidateForm()) {
			lblCreateSvc.Visible = true;
			lblMove.Visible = true;
			lblNTSvcStart.Visible = true;
			lblStop.Visible = true;
			lblUpdtRegistry.Visible = true;
			lblNotDone.Visible = false;
			lblNotDone2.Visible = false;
			btnStart.Enabled = false;
			pb1.Visible = true;
			lblNotDone.Visible = false;
			lblNotDone2.Visible = false;
			lblAlready.Visible = false;
			lblAlready2.Visible = false;
			lblStop.ForeColor = Color.Blue;

			InstallWorker.RunWorkerAsync(objSysData);
		} else {
			StartApp();
		}

	}


    private void btnRemove_Click_1(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(objSysData.DevID)) {
            MessageBox.Show(ac.c_sValHard, ac.c_sMessageTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			StartApp();
		} else {
			btnRemove.Enabled = false;
			pb1.Visible = true;

			RemoveWorker.RunWorkerAsync(objSysData);

		}

	}

	#endregion

	#region "Methods"


	private void RemoveService(MagicJackSvcCreator.SysData objRemoveWorkerSysData)
	{
        MagicJackSvcCreator.MscEngine objMscEngine = new MagicJackSvcCreator.MscEngine(objRemoveWorkerSysData);

		objMscEngine.StopNTService();
		RemoveWorker.ReportProgress(30);
        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		objMscEngine.DeleteNTService();
		RemoveWorker.ReportProgress(75);
        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		objMscEngine.StartOEMMJ();
		RemoveWorker.ReportProgress(100);
        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

	}


    private void InstallService(MagicJackSvcCreator.SysData objWorkerSysData)
	{
        MagicJackSvcCreator.MscEngine objMscEngine = new MagicJackSvcCreator.MscEngine(objWorkerSysData);
        MagicJackSvcCreator.Enums.ProgressData objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
		bool bErrorEncountered = false;
        MagicJackSvcCreator.GenericEngineOutput objMscEngineGenericOutput = new MagicJackSvcCreator.GenericEngineOutput();

		System.Threading.Thread.Sleep(100);

		//Kill MJ desktop app
		objMscEngineGenericOutput = objMscEngine.KillMJ();
		if (objMscEngineGenericOutput.bSuccess == true) {
            objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.KillMJPassed;
			InstallWorker.ReportProgress(20, objReportProgress);
		} else {
            objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.KillMJFailed;
			objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
			InstallWorker.ReportProgress(0, objReportProgress);
			bErrorEncountered = true;
		}

        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		//Move MJ files out of user folder
		if (bErrorEncountered == false) {
            objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
			objMscEngineGenericOutput = objMscEngine.MoveInstall();
			if (objMscEngineGenericOutput.bSuccess == true) {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveInstallPassed;
				InstallWorker.ReportProgress(40, objReportProgress);
			} else {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveInstallFailed;
				objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
				InstallWorker.ReportProgress(0, objReportProgress);
				bErrorEncountered = true;
			}
		}

        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		//Create required files
		if (bErrorEncountered == false) {
            objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
			objMscEngineGenericOutput = objMscEngine.CreateBins();
			if (objMscEngineGenericOutput.bSuccess == true) {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveProcessFilesPassed;
				InstallWorker.ReportProgress(50, objReportProgress);
			} else {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.MoveProcessFilesFailed;
				objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
				InstallWorker.ReportProgress(0, objReportProgress);
				bErrorEncountered = true;
			}
		}

        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		//Create MJ service
		if (bErrorEncountered == false) {
            objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
			objMscEngineGenericOutput = objMscEngine.CreateNTService();
			if (objMscEngineGenericOutput.bSuccess == true) {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.CreateServicePassed;
				InstallWorker.ReportProgress(60, objReportProgress);
			} else {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.CreateServiceFailed;
				objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
				InstallWorker.ReportProgress(0, objReportProgress);
				bErrorEncountered = true;
			}
		}

        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		//Update system registry
		if (bErrorEncountered == false) {
            objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
			objMscEngineGenericOutput = objMscEngine.UpdateRegistry();
			if (objMscEngineGenericOutput.bSuccess == true) {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.UpdateRegistryPassed;
				InstallWorker.ReportProgress(85, objReportProgress);
			} else {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.UpdateRegistryFailed;
				objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
				InstallWorker.ReportProgress(0, objReportProgress);
				bErrorEncountered = true;
			}
		}

        System.Threading.Thread.Sleep(ac.c_nThreadSleepInterval);

		//Start new service
		if (bErrorEncountered == false) {
            objReportProgress = new MagicJackSvcCreator.Enums.ProgressData();
			objMscEngineGenericOutput = objMscEngine.StartNTService();
			if (objMscEngineGenericOutput.bSuccess == true) {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.StartServicePassed;
				InstallWorker.ReportProgress(100, objReportProgress);
			} else {
                objReportProgress.ProgressStatus = MagicJackSvcCreator.Enums.ProgressData.enProgressStatus.StartServiceFailed;
				objReportProgress.sExceptionMessage = objMscEngineGenericOutput.sExceptionMessage;
				InstallWorker.ReportProgress(0, objReportProgress);
				bErrorEncountered = true;
			}
		}

		System.Threading.Thread.Sleep(100);

	}

	private bool ValidateForm()
	{

		bool bIsValid = true;

		if (string.IsNullOrEmpty(objSysData.MJInsPath)) {
            MessageBox.Show(ac.c_sValSoft, ac.c_sMessageTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			bIsValid = false;
		}

		if (string.IsNullOrEmpty(objSysData.DevID)) {
            MessageBox.Show(ac.c_sValHard, ac.c_sMessageTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
			bIsValid = false;
		}

		return bIsValid;

	}


	private void StartApp()
	{
        objSysData = new MagicJackSvcCreator.SysData(BuildFormState());
		PopulateControls(objSysData);

	}


	private void CheckForUpdates()
	{

		try {
			UpdateManager um = new UpdateManager();
			decimal latestVersion = um.CheckForUpdates();


            if ((!(latestVersion == 0.0m)) && (latestVersion > ac.c_Version))
            {
                string message = ac.c_sUpdateMessage;
				string caption = "Version " + latestVersion.ToString("F1") + " Available";
				dynamic result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if ((result == DialogResult.Yes)) {
                    System.Diagnostics.Process.Start(string.Format(ac.c_sDownloadUpdateURI, latestVersion.ToString("F1").Replace(".", "")));
					System.Environment.Exit(0);
					//close app. user is going to update.
				}

			}

		} catch (Exception) {
			//Do nothing
		}

	}

    private MagicJackSvcCreator.FormState BuildFormState()
	{

        MagicJackSvcCreator.FormState objOut = new MagicJackSvcCreator.FormState();

		var _with3 = objOut;
		_with3.bForceDetection = cbForceDetection.Checked;

		return objOut;

	}


    private void PopulateControls(MagicJackSvcCreator.SysData sysdata)
	{
		pb1.Value = 0;

		if (!string.IsNullOrEmpty(sysdata.DevID)) {
            if (sysdata.DevID == ac.c_sFDDevID)
            {
                lblConnectStatus.Text = ac.c_sDetectionForced;
				lblConnectStatus.ForeColor = Color.Blue;
				cbForceDetection.Visible = true;
				btnForceHelp.Visible = true;
			} else {
                lblConnectStatus.Text = ac.c_sStatusConnected;
				lblConnectStatus.ForeColor = Color.Green;
				cbForceDetection.Visible = false;
				btnForceHelp.Visible = false;
			}
            lblDevID.Text = ac.c_slblDeviceID + sysdata.DevID;
		} else {
            lblConnectStatus.Text = ac.c_sStatusNotFound;
            lblDevID.Text = ac.c_sStrNull;
			lblConnectStatus.ForeColor = Color.Red;
			cbForceDetection.Visible = true;
		}

		if ((!string.IsNullOrEmpty(sysdata.DriveLtr) & !string.IsNullOrEmpty(sysdata.MJInsPath))) {
            lblSoftStatus.Text = ac.c_sSoftInstalled;
			lblSoftStatus.ForeColor = Color.Green;

            string softPath = sysdata.MJSoftwareVersion[0].Replace(ac.c_sMJExe, "");
			if (softPath.Length > 42) {
				softPath = softPath.Substring(0, 42) + "...";
			}
			lblSoftPath.Text = "Version " + sysdata.MJSoftwareVersion[1] + " located in " + softPath;

            lblDrvLtr.Text = ac.c_sDriveLetter + sysdata.DriveLtr;
		} else {
            lblSoftStatus.Text = ac.c_sSoftNotInstalled;
			lblSoftStatus.ForeColor = Color.Red;
            lblDrvLtr.Text = ac.c_sStrNull;
            lblSoftPath.Text = ac.c_sStrNull;
		}

		lblCreateSvc.Visible = false;
		lblMove.Visible = false;
		lblNTSvcStart.Visible = false;
		lblStop.Visible = false;
		lblUpdtRegistry.Visible = false;
		lblNotDone.Visible = true;
		lblNotDone2.Visible = true;

		pb1.Visible = false;

		if (sysdata.bIsSvcRunning) {
			lblNotDone.Visible = false;
			lblNotDone2.Visible = false;
			btnStart.Enabled = false;
			btnStart.Visible = false;
			lblAlready.Visible = true;
			lblAlready2.Visible = true;
			btnRemove.Visible = true;
			btnRemove.Enabled = true;
		} else {
			btnRemove.Visible = false;
			btnRemove.Enabled = false;
			lblAlready.Visible = false;
			lblAlready2.Visible = false;
			btnStart.Enabled = true;
			btnStart.Visible = true;
			lblNotDone.Visible = true;
			lblNotDone2.Visible = true;
		}

	}

	#endregion
    
    }
}
