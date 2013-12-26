using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicJackSvcCreator.Enums
{
    public class ProgressData
    {

        public enum enProgressStatus
        {
            KillMJPassed,
            KillMJFailed,
            MoveInstallPassed,
            MoveInstallFailed,
            MoveProcessFilesPassed,
            MoveProcessFilesFailed,
            CreateServicePassed,
            CreateServiceFailed,
            UpdateRegistryPassed,
            UpdateRegistryFailed,
            StartServicePassed,
            StartServiceFailed
        }

        public enProgressStatus ProgressStatus;

        public string sExceptionMessage;
    }

    public class LibProvEnum
    {

        public enum enLibModule
        {
            Instsrv,
            Srvany
        }

    }
}
