using DLiveNET.Classes.Helpers;
using DLiveNET.Classes.Objects;
using System;
using System.IO;

namespace DLiveNET
{
    public class DLive
    {
        // Variables
        private string authKey { get; set; }
        private string blockchainPrivKey { get; set; }
        private Permissions permissionObj { get; set; }
        private SendRequestToDlive sendReq { get; set; }

        public DLive(string authKey, string blockchainPrivKey = null) {
            this.authKey = authKey;
            this.blockchainPrivKey = blockchainPrivKey;
            permissionObj = new Permissions(null, this.authKey, this.blockchainPrivKey);
            sendReq = new SendRequestToDlive("Oblivifrek", permissionObj);
        }

        public void listenToChat(string username, Action callback) {

        }

        public String TestConnection() {
            return sendReq.GetResponse();
        }
    }
}
