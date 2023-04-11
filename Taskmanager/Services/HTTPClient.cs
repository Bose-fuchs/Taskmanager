using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanager.Services
{
    public static class HTTPClient
    {
        public static HttpClient client = new HttpClient();
    }
}
