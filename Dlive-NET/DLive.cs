using DLiveNET.Classes.Helpers;
using DLiveNET.Classes.Objects;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DLiveNET
{
    public class DLive
    {
        // Variables
        private string authKey { get; set; }
        private string blockchainPrivKey { get; set; }
        private Permissions permissionObj { get; set; }

        public DLive(string authKey, string blockchainPrivKey = null) {
            this.authKey = authKey;
            this.blockchainPrivKey = blockchainPrivKey;
            permissionObj = new Permissions(null, this.authKey, this.blockchainPrivKey);
        }

        public void listenToChat(string username, Action callback) {

        }

        public void TestConnection()
        {
            SendRequestToDlive sendReq = new SendRequestToDlive("DLive", permissionObj);
            sendReq.GetResponse();
        }
    }
}
