using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicJackSvcCreator
{
    public class Constants
    {

        //should be in format n.n
		public decimal c_Version = 2.3m;

		public string c_sVersionRelease = "12/24/2013";
		//PNP Device names
		public string c_sDevName0 = "USB Internet Phone by TigerJet";
        public string c_sDevName1 = "USB Audio Device";
		public string c_sDevName2 = "TigerJet HardDisk USB Device";
		public string c_sDevName3 = "TigerJet CD-ROM USB Device";

		//WMI query constants
		public string c_sPNPObjName = "Name";
		public string c_sPNPObjDevID = "PnPDeviceID";

		public string c_sSQLPnP = "SELECT * FROM  Win32_PnPEntity";
		//Messages and labels
		public string c_sStatusConnected = "MagicJack detected";
        public string c_sStatusNotFound = "MagicJack not detected." + System.Environment.NewLine + "Please connect device and restart MSC.";
		public string c_sSoftNotInstalled = "MagicJack software is not installed/detected.";
		public string c_sSoftInstalled = "MagicJack software installation detected";
		public string c_sValSoft = "MagicJack software installation was not detected.";
		public string c_sValHard = "Cannot detect MagicJack hardware device.";
		public string c_sOperSucc = "The Windows Service has been successfully removed.";
		public string c_sOperFail = "Errors encountered during operation!";
		public string c_sDefaultDevID = "USB MagicJack device (default ID)";
		public string c_sUnknownLit = "Hardware status unknown.";
		public string c_sErrFilesMissing = "Required files (wrk001.rsc and wrk002.rsc) are missing.";
        public string c_sForceDetectionInfo = "Use this option if your MagicJack is currently " + System.Environment.NewLine + "plugged in and working, but isn't being detected.";
		public string c_sForceDetectionMessage = "Force Detection";
		public string c_sRemoveMessage = "Remove Service";
		public string c_sRemoveInfo = "The service may not be completely removed until you restart your computer.";
		public string c_sMSCTitle = "MagicJack Service Creator ";
		public string c_sMessageTitleError = "Error";
		public string c_sDetectionForced = "Detection Forced";
		public string c_sFDDevID = "N/A";
		public string c_slblDeviceID = "Device ID: ";
		public string c_sInstallPath = "Install path: ";
		public string c_sDriveLetter = "MagicJack drive letter: ";

		public string c_sMJVersion = "Version: ";
		//Symbols and default primatives
		public string c_sStrNull = "";
		public string c_sStrSpc = " ";

		public string c_sStrBksl = "\\";
		//File names and locations, registry keys and locations, service and executable names
			//the name of the OEM MJ process
		public string c_sMJProcess = "magicJack";
		public string c_sMJSetup = "mjsetup";
		public string c_sMJFolder = "\\mjusbsp";
		public string c_sMJDeviceFolder = "\\magicJack";
		public string c_sSvcCreator = "\\wrk001.rsc";
		public string c_sSvcLauncher = "\\wrk002.rsc";
		public string c_sInstsrvExe = "\\instsrv.exe";

		public string c_sSrvanyExe = "\\srvany.exe";
		public string c_sRegApp = "Application";
		public string c_sMJLoader = "magicJackLoader.exe";
		public string c_sRegPath = " /scf _magicJackPersonalDataRoot ";
		public string c_sMJExe = "\\magicJack.exe";
		public string c_sRegUpdtLoc = "SYSTEM\\CurrentControlSet\\services\\MagicJack";
		public string c_sRegParameters = "Parameters";
		public string c_sRegCDL = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
		public string c_sRegLoc = "Software\\talk4free\\magicJack Outlook AddIn\\Softphone\\";
		public string c_sRegRoot = "PersonalDataRootDir";

		public string c_sRegAppPath = "AppPath";
		public string c_sMJLink = "magicJack.lnk";
			//the name of the new service
		public string c_sNTSvcName = "magicJack";
		public string c_sCDLoader = "cdloader";

		public string c_sAutorun = "autorun.exe";
		public string c_sRemove = "remove";

		public string c_sDriveMJSoft = "magicJack";
		//Update Check
		public string c_sUpdateMessage = "A newer version of MagicJack Service Creator is available. Would you like to download it now?";
		public string c_sUpdateCheckURI = "http://www.evanvaughan.com/default.aspx?pageid=32F377E9DBD140AA";
		public string c_sDownloadUpdateURI = "http://www.evanvaughan.com/files/03ab/MSC_{0}.zip";

		public string c_sAppUpdateTag = "|0001 - MagicJack Service Creator: ";

		public int c_nThreadSleepInterval = 1700;

    }
}
