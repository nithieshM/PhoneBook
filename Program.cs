namespace PhoneBook;

using Spectre.Console;

class Program
{
     enum Menu
        {
            AddInformation,
            DeleteInformation,
            UpdateInformation,
            ViewAllInformation,
            Quit
        }

    static void Main(string[] args)
    {
        var options = AnsiConsole.Prompt(
            new SelectionPrompt<Menu>()
            .Title("Welcome to my PhoneBook Application! \n What would you like to do?")
            .AddChoices(
                Menu.AddInformation,
                Menu.DeleteInformation,
                Menu.UpdateInformation,
                Menu.ViewAllInformation,
                Menu.Quit
            )
        );

        
    }
}
