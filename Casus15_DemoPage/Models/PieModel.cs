using Casus15_DemoPage.FaceRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casus15_DemoPage.Models
{
    public class PieModel
    {
        public int Teacher { get; set; }
        public int SmartBoard { get; set; }
        public int Laptop { get; set; }

        public int FacesLookingAtScreen { get; set; }
    }
}