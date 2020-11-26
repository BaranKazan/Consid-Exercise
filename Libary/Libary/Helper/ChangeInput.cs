using System;
namespace Library.Helper
{

    /*
     * This class handles the input changes that are required.
     */
    public class ChangeInput
    {

        //Adds a acronym right next to the tittle.
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
