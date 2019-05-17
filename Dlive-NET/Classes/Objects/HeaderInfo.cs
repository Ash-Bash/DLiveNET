using System;
using System.Collections.Generic;
using System.Text;

namespace DLiveNET.Classes.Objects
{
    public class HeaderInfo
    {

        // Variables
        public string accept { get; set; }
        public string authKey { get; set; }
        public string contentType { get; set; }
        public string fingerprint { get; set; }
        public string gacid { get; set; }
        public string origin { get; set; }
        public string referer { get; set; }
        public string userAgent { get; set; }

        public HeaderInfo(string accept, string authKey, string contentType, string fingerprint, string gacid, string origin, string referer, string userAgent) {
            this.accept = accept;
            this.authKey = authKey;
            this.contentType = contentType;
            this.fingerprint = fingerprint;
            this.gacid = gacid;
            this.origin = origin;
            this.referer = referer;
            this.userAgent = userAgent;
        }
    }
}
