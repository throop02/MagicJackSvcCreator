using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MagicJackSvcCreator
{
    public class UpdateManager
    {

        private Constants appConstants;

        public UpdateManager()
        {
            
            appConstants = new Constants();

        }

        private string GetUpdatePage(string Url)
        {

            WebRequest wrq = WebRequest.Create(Url);
            HttpWebResponse wrp = (HttpWebResponse)wrq.GetResponse();
            StreamReader sr = new StreamReader(wrp.GetResponseStream());
            string Text = sr.ReadToEnd();
            sr.Close();
            wrp.Close();
            return Text;

        }

        public decimal CheckForUpdates()
        {

            decimal updateVersion = 0.0m;


            try
            {
                string updatePageContent = GetUpdatePage(appConstants.c_sUpdateCheckURI);

                updatePageContent = updatePageContent.Substring(updatePageContent.IndexOf(appConstants.c_sAppUpdateTag) + appConstants.c_sAppUpdateTag.Length);
                updatePageContent = updatePageContent.Substring(0, updatePageContent.IndexOf("|"));

                updateVersion = Convert.ToDecimal(updatePageContent);


            }
            catch (Exception)
            {
            }

            return updateVersion;

        }

    }
}
