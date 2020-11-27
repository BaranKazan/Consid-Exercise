using System;
namespace Library.Helper
{

    /*
     * This class handles the input the output changes of the text.
     */
    public class TextConverter
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

        /*
         * Removed the time out of the date.
         */
        public static String DateWithoutTime(DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
