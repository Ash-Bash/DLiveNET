using System;
using System.Collections.Generic;
using System.Text;

namespace DLiveNET.Classes.Objects
{
    public class ServerInfo
    {

        // Variables
        private string hostname { get; set; }
        private int port { get; set; }
        private string path { get; set; }
        private string method { get; set; }
        private HeaderInfo header { get; set; }

        public ServerInfo(string hostname, int port, string path, string method, HeaderInfo header) {
            this.hostname = hostname;
            this.port = port;
            this.path = path;
            this.method = method;
            this.header = header;
        }

        public string getHostname() {
            return hostname;
        }

        public int getPort() {
            return port;
        }

        public string getPath() {
            return path;
        }

        public string getMethod() {
            return method;
        }

        public HeaderInfo getHeader() {
            return header;
        }
    }
}
