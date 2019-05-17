using DLiveNET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DLiveNET.Classes.Helpers
{
    public class SendRequestToDlive
    {
        // Variables
        private string username { get; set; }
        private Permissions permissionObj { get; set; }
        private ServerInfo serverInfo { get; set; }

        public SendRequestToDlive(string username, Permissions permissionObj) {
            this.username = username;
            this.permissionObj = permissionObj;

            HeaderInfo header = new HeaderInfo("*/*", permissionObj.getAuthKey(), "application/json", "", "undefined", "https://dlive.tv", "https://dlive.tv/" + username, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36");
            serverInfo = new ServerInfo("https://graphigo.prd.dlive.tv", 443, "/", "POST", header);
        }

        public String GetResponse() {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverInfo.getHostname() + ":" + serverInfo.getPort());
            //req.Credentials =   serverInfo.getHeader().authKey;
            req.PreAuthenticate = true;
            req.Headers.Add("authorization", serverInfo.getHeader().authKey);
            req.Headers.Add("gacid", serverInfo.getHeader().gacid);
            req.Headers.Add("fingerprint", serverInfo.getHeader().fingerprint);
            req.Headers.Add("Origin", serverInfo.getHeader().origin);
            req.Referer = serverInfo.getHeader().referer;
            req.ContentType = serverInfo.getHeader().contentType;
            req.Method = serverInfo.getMethod();
            req.Accept = serverInfo.getHeader().accept;
            req.UserAgent = serverInfo.getHeader().userAgent;
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                Stream resStream = res.GetResponseStream();
                if (resStream == null) return null;

                var streamReader = new StreamReader(resStream, Encoding.Default);
                var json = streamReader.ReadToEnd();

                resStream.Close();
                res.Close();

                return json;
            }
            catch (WebException we) {
                var resp = we.Response as HttpWebResponse;
                if (resp == null)
                    throw;
                return we.Message;
            }
        }

        public ServerInfo GetServerInfo() {
            return serverInfo;
        }
    }
}
