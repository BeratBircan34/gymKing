using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.controls
{
    

    public class pt_islemKontrol
    {
        public static bool islemYapildiMi { get; set; }
        
        void setFalse(bool tf)
        {
            islemYapildiMi = tf;
        }
        
        public pt_islemKontrol(bool tf)
        {
            setFalse(tf);
        }
    }
}
