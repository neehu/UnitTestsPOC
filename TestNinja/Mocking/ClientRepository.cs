using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class ClientRepository : IClientRepository
    {
        private WebClient _client { get; set; }

        public ClientRepository()
        {
            _client = new WebClient();
        }
        public void getDownloadedFile(string url, string path)
        {
            _client.DownloadFile(url, path);
        }
    }
}
