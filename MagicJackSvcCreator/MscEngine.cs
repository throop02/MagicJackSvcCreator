using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace MagicJackSvcCreator
{
    public class MscEngine
    {

        #region "Globals"

            private MagicJackSvcCreator.SysData m_SysData;
            private Constants appConstants;

        #endregion


        #region "Constructors"


        public MscEngine(MagicJackSvcCreator.SysData objSysData)
        {
            m_SysData = objSysData;
            appConstants = new Constants();

        }

        #endregion


        #region "Methods"

            public GenericEngineOutput CreateBins()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();


                try
                {
                    //instsrv.exe
                    ILibProvider provider = new LibProvider();
                    using (MemoryStream ms = new MemoryStream(provider.GetLib(Enums.LibProvEnum.enLibModule.Instsrv)))
                    {
                        using (FileStream fs = File.OpenWrite(this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sInstsrvExe))
                        {
                            ms.WriteTo(fs);
                        }
                    }

                    //srvany.exe
                    using (MemoryStream ms = new MemoryStream(provider.GetLib(Enums.LibProvEnum.enLibModule.Srvany)))
                    {
                        using (FileStream fs = File.OpenWrite(this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sSrvanyExe))
                        {
                            ms.WriteTo(fs);
                        }
                    }

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput UpdateRegistry()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();
                RegistryKey regKey = null;
                RegistryKey regkey2 = null;
                RegistryKey regkey3 = null;

                try
                {
                    regKey = Registry.LocalMachine.OpenSubKey(appConstants.c_sRegUpdtLoc, true);
                    regKey.CreateSubKey(appConstants.c_sRegParameters);
                    regKey.Flush();
                    regKey.Close();

                    regkey2 = Registry.LocalMachine.OpenSubKey(appConstants.c_sRegUpdtLoc + appConstants.c_sStrBksl + appConstants.c_sRegParameters, true);
                    regkey2.SetValue(appConstants.c_sRegApp, (this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sMJExe + appConstants.c_sRegPath + this.m_SysData.DriveLtr + appConstants.c_sMJDeviceFolder));
                    regkey2.Flush();
                    regkey2.Close();

                    regkey3 = Registry.CurrentUser.OpenSubKey(appConstants.c_sRegCDL, true);
                    regkey3.DeleteValue(appConstants.c_sCDLoader);
                    regkey3.Flush();
                    regkey3.Close();

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput StartNTService()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();
                ServiceController con = new ServiceController(appConstants.c_sNTSvcName);

                try
                {
                    con.Start();
                    con.WaitForStatus(ServiceControllerStatus.Running);

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput StopNTService()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();
                ServiceController con = new ServiceController(appConstants.c_sNTSvcName);

                try
                {
                    if (con.Status == ServiceControllerStatus.Running)
                    {
                        con.Stop();
                        con.WaitForStatus(ServiceControllerStatus.Stopped);
                    }

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput CreateNTService()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();

                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sInstsrvExe;
                    p.StartInfo.Arguments = appConstants.c_sNTSvcName + appConstants.c_sStrSpc + this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sSrvanyExe;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput DeleteNTService()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();

                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sInstsrvExe;
                    p.StartInfo.Arguments = appConstants.c_sNTSvcName + appConstants.c_sStrSpc + appConstants.c_sRemove;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput StartOEMMJ()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();
                string sMJSoftwareLoc = appConstants.c_sStrNull;

                try
                {
                    sMJSoftwareLoc = this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sStrBksl + appConstants.c_sMJLoader;

                    dynamic p = new Process();
                    p.StartInfo.FileName = sMJSoftwareLoc;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    p.Start();

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput KillMJ()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();

                try
                {
                    Process[] myProcesses = null;
                    Process myProcess = null;

                    myProcesses = Process.GetProcessesByName(appConstants.c_sMJProcess);
                    foreach (Process myProcess_loopVariable in myProcesses)
                    {
                        myProcess = myProcess_loopVariable;
                        myProcess.Kill();
                    }

                    myProcesses = Process.GetProcessesByName(appConstants.c_sMJSetup);
                    foreach (Process myProcess_loopVariable in myProcesses)
                    {
                        myProcess = myProcess_loopVariable;
                        myProcess.Kill();
                    }

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

            public GenericEngineOutput MoveInstall()
            {

                GenericEngineOutput objOut = new GenericEngineOutput();
                string sPath = this.m_SysData.MJInsPath.Substring(0, (this.m_SysData.MJInsPath.IndexOf(appConstants.c_sMJLoader)));
                DirectoryInfo d2 = new DirectoryInfo(sPath);
                DirectoryInfo d1 = new DirectoryInfo(this.m_SysData.WindowsPath + appConstants.c_sMJFolder);
                Computer myComputer = new Computer();
                DirectoryInfo desktop = new DirectoryInfo(myComputer.FileSystem.SpecialDirectories.Desktop);

                try
                {
                    if (d1.Exists)
                    {
                        d1.Delete(true);
                    }

                    d1.Create();

                    foreach (FileInfo fs in d2.GetFiles())
                    {
                        fs.CopyTo(this.m_SysData.WindowsPath + appConstants.c_sMJFolder + appConstants.c_sStrBksl + fs.Name);
                    }

                    d2.Delete(true);

                    foreach (FileInfo fs2 in desktop.GetFiles())
                    {
                        if (fs2.Name == appConstants.c_sMJLink)
                        {
                            fs2.Delete();
                        }
                    }

                }
                catch (Exception ex)
                {
                    objOut.bSuccess = false;
                    objOut.sExceptionMessage = ex.Message.ToString();

                }

                return objOut;

            }

        #endregion

    }

    public class GenericEngineOutput
    {

        public GenericEngineOutput()
        {
            bSuccess = true;
            sExceptionMessage = "";
        }

        public string sExceptionMessage;

        public bool bSuccess;
    }

}
