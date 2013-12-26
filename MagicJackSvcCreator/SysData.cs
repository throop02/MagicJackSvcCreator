using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Management;

namespace MagicJackSvcCreator
{
    public class SysData
    {

        #region "Globals"

            private MagicJackSvcCreator.FormState m_FormState;
            private Constants appConstants;

        #endregion


        #region "Properties"

            public string DevID
            {
                get { return Detect_MagicJack(); }
            }

            public string[] MJSoftwareVersion
            {
                get
                {
                    string[] output = new string[2];
                    output[0] = appConstants.c_sStrNull;
                    string mjVersion = "(unknown)";
                    try
                    {
                        string versionPath = this.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sMJExe;
                        if (this.NTServiceExists(appConstants.c_sNTSvcName) == false)
                        {
                            versionPath = this.MJInsPath.Replace("\\" + appConstants.c_sMJLoader, appConstants.c_sMJExe);
                        }
                        output[0] = versionPath;
                        mjVersion = FileVersionInfo.GetVersionInfo(versionPath).FileVersion.Replace(",", ".");

                    }
                    catch (Exception)
                    {
                    }
                    output[1] = mjVersion;
                    return output;
                }
            }

            public string MJInsPath
            {
                get { return GetInstallInfo()[0].ToString(); }
            }

            public string DriveLtr
            {
                get { return GetInstallInfo()[1].ToString(); }
            }

            public string PgmFilesPath
            {
                get { return GetPFRoot(); }
            }

            public string WindowsPath
            {
                get { return GetWinRoot(); }
            }

            public string MyPath
            {
                get { return GetMyPath(); }
            }

            public bool bIsSvcRunning
            {
                get { return NTServiceExists(appConstants.c_sNTSvcName); }
            }

            public bool bAppFilesValidated
            {
                get { return ValidateAppFiles(); }
            }

        #endregion

        #region "Constructors"

            public SysData(MagicJackSvcCreator.FormState objFormState)
            {
                m_FormState = objFormState;
                appConstants = new Constants();
            }

        #endregion


        #region "Methods"

            private bool NTServiceExists(string sServiceName)
            {

                bool bExists = false;
                ServiceController con = new ServiceController(sServiceName);

                try
                {
                    if ((con.Status == ServiceControllerStatus.Running 
                        | con.Status == ServiceControllerStatus.Stopped 
                        | con.Status == ServiceControllerStatus.Paused 
                        | con.Status == ServiceControllerStatus.ContinuePending 
                        | con.Status == ServiceControllerStatus.PausePending 
                        | con.Status == ServiceControllerStatus.StartPending 
                        | con.Status == ServiceControllerStatus.StopPending))
                    {
                        bExists = true;
                    }

                }
                catch (Exception)
                {
                    bExists = false;

                }

                return bExists;

            }


            private bool ValidateAppFiles()
            {

                bool bSuccess = true;
                FileInfo d2 = new FileInfo(this.MyPath + appConstants.c_sSvcCreator);
                FileInfo d1 = new FileInfo(this.MyPath + appConstants.c_sSvcLauncher);

                try
                {
                    if (!d1.Exists)
                    {
                        bSuccess = false;
                    }

                    if (!d2.Exists)
                    {
                        bSuccess = false;
                    }

                }
                catch (Exception)
                {
                    bSuccess = false;

                }

                return bSuccess;

            }

            private string GetPFRoot()
            {

                string sPath = null;
                sPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                return sPath;

            }

            private string GetWinRoot()
            {

                string sPath = null;
                sPath = System.Environment.SystemDirectory.Substring(0, 2);
                return sPath;

            }

            private string GetMyPath()
            {

                string sPath = null;
                sPath = System.Environment.CurrentDirectory;
                return sPath;

            }

            private string Detect_MagicJack()
		    {
            
			    ManagementObjectSearcher searcher = new ManagementObjectSearcher(appConstants.c_sSQLPnP);
			    string sDevID = appConstants.c_sStrNull;

			    try {
				    foreach ( ManagementObject PnPDevice in searcher.Get()) {
                        if ((PnPDevice.GetPropertyValue(appConstants.c_sPNPObjName).ToString() == appConstants.c_sDevName0 |
                            PnPDevice.GetPropertyValue(appConstants.c_sPNPObjName).ToString() == appConstants.c_sDevName1 |
                            PnPDevice.GetPropertyValue(appConstants.c_sPNPObjName).ToString() == appConstants.c_sDevName2 |
                            PnPDevice.GetPropertyValue(appConstants.c_sPNPObjName).ToString() == appConstants.c_sDevName3))
                        {
                            sDevID = PnPDevice.GetPropertyValue(appConstants.c_sPNPObjDevID).ToString();
						    break;
					    }
				    }


			    } catch (Exception) {
			    }

			    if ((sDevID == appConstants.c_sStrNull)) {
				    if (GetVolumeDriveLetter() != appConstants.c_sStrNull) {
					    sDevID = appConstants.c_sDefaultDevID;
				    }
			    }

			    if (sDevID.Length > 48) {
				    sDevID = sDevID.Substring(0, 48);
				    sDevID += "...";
			    }

			    if (m_FormState.bForceDetection == true && sDevID == appConstants.c_sStrNull) {
				    sDevID = appConstants.c_sFDDevID;
			    }

			    return sDevID;

		    }

            private string GetVolumeDriveLetter()
            {

                string sOutput = appConstants.c_sStrNull;
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d_loopVariable in allDrives)
                {
                    if (d_loopVariable.IsReady)
                    {
                        if (d_loopVariable.VolumeLabel == appConstants.c_sDriveMJSoft)
                        {
                            sOutput = d_loopVariable.Name;
                            break;
                        }
                    }
                }

                return sOutput;

            }

            private string[] GetInstallInfo()
            {

                string[] arrOutput = new string[2];
                string[] arrSubs = null;
                RegistryKey regKey = null;

                try
                {
                    arrOutput[0] = appConstants.c_sStrNull;
                    arrOutput[1] = appConstants.c_sStrNull;

                    regKey = Registry.CurrentUser.OpenSubKey(appConstants.c_sRegLoc, false);
                    arrSubs = regKey.GetSubKeyNames();
                    regKey = Registry.CurrentUser.OpenSubKey(appConstants.c_sRegLoc + arrSubs[0].ToString(), false);
                    arrOutput[0] = regKey.GetValue(appConstants.c_sRegAppPath).ToString();

                    try
                    {
                        arrOutput[1] = regKey.GetValue(appConstants.c_sRegRoot).ToString().Substring(0, 2);
                    }
                    catch (Exception)
                    {
                        arrOutput[1] = regKey.GetValue(appConstants.c_sRegAppPath).ToString().Substring(0, 2);
                    }

                    regKey.Close();

                }
                catch (Exception)
                {
                    arrOutput[0] = appConstants.c_sStrNull;
                    arrOutput[1] = appConstants.c_sStrNull;

                }

                return arrOutput;

            }

        #endregion

    }
}
