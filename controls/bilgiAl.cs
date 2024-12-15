using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.controls
{
    public abstract class bilgiAl
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EMail { get; set; }
        public string TelNo { get; set; }


        public abstract void bilgi(string id);


    }
}
