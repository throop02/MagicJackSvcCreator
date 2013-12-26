using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicJackSvcCreator
{
    interface ILibProvider
    {

        byte[] GetLib(MagicJackSvcCreator.Enums.LibProvEnum.enLibModule target);

    }
}
