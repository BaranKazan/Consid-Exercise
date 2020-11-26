using System;
namespace Library.Helper
{
    public class ChangeInput
    {
        public static String AcronymTheTittle(String tittle)
        {
            string[] tittleSplit = tittle.Split();
            tittle += " (";
            foreach (string i in tittleSplit)
            {
                tittle += i.Substring(0, 1).ToUpper();
            };
            tittle += ")";
            return tittle;
        }
    }
}
