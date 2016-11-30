using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Helpers.Encription;

namespace Telmexla.Servicios.DIME.Helpers.ExtenMethods
{
    public static class ExtensionMethods
    {

        public static string ToUpperNoSpecialChars(this string str)
        {
            str = str.ToUpper();
            string con = "áàäéèëíìïóòöúùuÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ'¡!#@$%&/()=?¿´`¨+*/.~´(){}[]";
            string sin = "aaaeeeiiiooouuuAAAEEEIIIOOOUUUcC                             ";
            for (int i = 0; i < con.Length; i++)
            {
                str = str.Replace(con[i], sin[i]);
            }
            str = str.Replace(" ", "");
            return str;
        }

        public static string ToSpecialSha(this string str)
        {
            GeneralEncriptor genEncriptor = new GeneralEncriptor();
            return genEncriptor.GetEncriptedData(str);
        }


    }
}
