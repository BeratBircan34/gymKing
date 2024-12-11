using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.yonetici_forms
{
    public class sifreUret
    {
        public static string GenerateRndPassword()
        {
            Random rnd = new Random();
            string passwordd = "";

            for (int i = 0; i < 6; i++)
            {
                passwordd += rnd.Next(0, 10).ToString();
            }

            return passwordd;
        }
    }
}
