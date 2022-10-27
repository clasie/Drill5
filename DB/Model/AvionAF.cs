using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBase.Model
{
    public class AvionAF
    {
        public string Immat = "";
        public string TypeAvion = "";
        public int? NbHVol = 0;
        override public string ToString() {
            return $"{Immat} {TypeAvion} {NbHVol}";
        }
    }
}
