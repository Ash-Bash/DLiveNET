using DLiveNET.Classes.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

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

        /* public string GetResponse() {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverInfo.getHostname() + ":" + serverInfo.getPort());
            var auth = serverInfo.getHeader().authKey;
            //req.Credentials = new NetworkCredential(username, serverInfo.getHeader().authKey);
            req.Headers.Add(HttpRequestHeader.Authorization, auth);
            req.Headers.Add("gacid", serverInfo.getHeader().gacid);
            req.Headers.Add("fingerprint", serverInfo.getHeader().fingerprint);
            req.Headers.Add("Origin", serverInfo.getHeader().origin);
            //req.PreAuthenticate = true;
            req.KeepAlive = false;
            req.Timeout = 10000;
            req.ServicePoint.Expect100Continue = false;
            req.Referer = serverInfo.getHeader().referer;
            req.ContentType = serverInfo.getHeader().contentType;
            req.Method = serverInfo.getMethod();
            req.Accept = serverInfo.getHeader().accept;
            req.UserAgent = serverInfo.getHeader().userAgent;
            try
            {
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;

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
        }*/

        public void GetResponse() {
            TcpListener server = null;

            try
            {
                Int32 port = serverInfo.getPort();
                IPAddress ip = Dns.GetHostAddresses(new Uri(serverInfo.getHostname()).Host)[0];

                server = new TcpListener(ip, port);


                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public ServerInfo GetServerInfo() {
            return serverInfo;
        }
    }
}
