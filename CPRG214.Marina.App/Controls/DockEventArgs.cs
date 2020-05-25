using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPRG214.Marina.App.Controls
{
    public class DockEventArgs : EventArgs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool WaterService { get; set; }
        public bool ElectricalService { get; set; }
    }
}