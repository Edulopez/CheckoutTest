
using CheckoutTest.Core.Entities;
namespace CheckoutTest.Core.Helpers
{
    public class SanitizerHelper
    {
        // original by patel.milanb
        public static string Paranoide(string dirtyString)
        {
            if (string.IsNullOrEmpty(dirtyString)) return "";
            string removeChars = " ?&^$#@!()+-,:;<>’\'-_*";
            string result = dirtyString;

            foreach (char c in removeChars)
            {
                result = result.Replace(c.ToString(), string.Empty);
            }

            return result;
        }

        public static void Paranoide(ShoppingListItem item)
        {
            if (item == null) return;
            item.Title = Paranoide(item.Title);
        }

        public static bool IsClean(string dirtyString)
        {
            if (string.IsNullOrEmpty(dirtyString)) return true;

            return dirtyString == Paranoide(dirtyString);
        }
    }
}
