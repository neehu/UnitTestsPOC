using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IClientRepository _clientRepos { get; set; }

        public InstallerHelper(IClientRepository clientRepos)
        {
            _clientRepos = clientRepos;

        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _clientRepos.getDownloadedFile(string.Format("http://example.com/{0}/{1}", customerName,installerName), _setupDestinationFile);
                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}