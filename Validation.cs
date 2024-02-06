namespace PhoneBook;

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
}