using System;
using System.Collections.Generic;
using System.Text;

namespace DLiveNET.Classes.Objects
{
    public class Permissions
    {
        // Variables
        private string authKey { get; set; }
        private string blockchainPrivKey { get; set; }
        private object sender { get; set; }

        public Permissions(string sender, string authKey, string blockchainPrivKey) {
            this.authKey = authKey;
            this.blockchainPrivKey = blockchainPrivKey;
            this.sender = sender;
        }

        public string getAuthKey() {
            return authKey;
        }

        public string getBlockchainPrivKey() {
            return blockchainPrivKey;
        }

        public object getSender() {
            return sender;
        }
    }
}
