namespace PhoneBook;
using System.Text.RegularExpressions;

internal class Validation
{
    internal static bool NameCheck(string Name)
    {
        if(String.IsNullOrEmpty(Name))
        {
            return false;
        }

        foreach(char c in Name)
        {
            if (!Char.IsLetter(c) && c != '/' && c != ' ')
                return false;
        }
        return true;
    }

    internal static bool EmailCheck(string email)
    {
        bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        if(isEmail)
             {
                return true;
             }

        return false;
    }

    internal static bool PhoneCheck(string phone)
    {
        if(String.IsNullOrEmpty(phone))
        {
            return false;
        }

        foreach(char c in phone)
        {
            if (!Char.IsLetter(c))
                return false;
        }
        return true;
    }
}