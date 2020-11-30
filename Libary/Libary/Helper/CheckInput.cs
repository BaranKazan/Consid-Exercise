using System;
using System.Text.RegularExpressions;

namespace Library.Helper
{

    /*
     * This class contains methods that can check the input from the user.
     */

    public class CheckInput
    {

        public static bool checkAuthor(String author)
        {

            String strRegex = @"^(?![\s.]+$)[a-zA-Z\s.]{4,50}$";

            Regex re = new Regex(strRegex);

            return re.IsMatch(author) && author != null && !author.Equals("");
        }

        public static bool checkTitle(String title)
        {
            return title != null && !title.Equals("");
        }

        public static bool checkPages(int? page)
        {
            return page != null && page > 0;
        }

        public static bool checkRunTimeMinutes(int? runTimeMinute)
        {
            return runTimeMinute != null && runTimeMinute > 0;
        }

        public static bool checkType(String type)
        {
            String strRegex = "^([a-zA-Z ])*$";

            Regex re = new Regex(strRegex);

            return re.IsMatch(type) && type != null && type.Equals("");
        }

        public static bool checkCategoryName(String categoryName)
        {
            String strRegex = "^([a-zA-Z ])*$";

            Regex re = new Regex(strRegex);

            return re.IsMatch(categoryName) && categoryName != null && categoryName.Equals("");

        }

        public static bool checkFirstName(String firtsName)
        {
            String strRegex = "([A-Z][a-z]+)$";

            Regex re = new Regex(strRegex);

            return re.IsMatch(firtsName) && firtsName != null && firtsName.Equals("");
        }

        public static bool checkLastName(String lastName)
        {
            String strRegex = "([A-Z][a-z]+)$";

            Regex re = new Regex(strRegex);

            return re.IsMatch(lastName) && lastName != null && lastName.Equals("");
        }

    }
}
