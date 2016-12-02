using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Helpers.Encription
{
    public class GeneralEncriptor
    {

        private const string _salt = "C53rv0Al3j00nCl4r00nDate01ofAugustof2016";

        private string CalculateHashedData(String data)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(data + _salt));
                string hashed = Convert.ToBase64String(computedHash);
                hashed = VoltearString(hashed);
                computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(data + _salt + hashed));
                hashed = Convert.ToBase64String(computedHash);
                hashed = VoltearString(hashed);
                computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(data + _salt + hashed));
                return Convert.ToBase64String(computedHash);
            }
        }




        public string GetEncriptedData(String data)
        {

            return CalculateHashedData(data) + CalculateHashedData(data + CalculateHashedData(data)) +
                CalculateHashedData(data + CalculateHashedData(data) + CalculateHashedData(data + CalculateHashedData(data)));

        }


        private static string VoltearString(String target)
        {

            char[] array = target.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }


    }
}
