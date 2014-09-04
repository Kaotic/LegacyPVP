using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyPVP.Logic.LegacyPVPLogic
{
    public class Update
    {
        public List<Download> downloads { get; set; }
    }
    public class Download
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public bool IsPre { get; set; }
        public bool IsBeta { get; set; }
        public bool IsImportantPatch { get; set; }
        public bool IsLatestPatch { get; set; }
        public string DownloadLink { get; set; }
    }
}
