using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gymKing.kasiyer_forms
{
    public class sifreUretme
    {
        public static string GenerateRandomPassword()
        {
            Random random = new Random();
            string password = "";

            for (int i = 0; i < 6; i++)
            {
                password += random.Next(0, 10).ToString();
            }

            return password;
        }


    }
}
