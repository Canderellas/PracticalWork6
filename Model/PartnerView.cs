using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class PartnerView
    {
        public PartnerView(Partner partner, int skidka)
        {
            this.partner = partner;
            this.skidka = skidka;
        }
        public Partner partner { get; set; }

        public int skidka { get; set; }
    }

}

