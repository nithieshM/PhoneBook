namespace PhoneBook;

using Spectre.Console;

internal class Program
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
        var appStatus = true;

        while (appStatus)
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

            switch (options)
            {
                case Menu.AddInformation:
                    Controller.AddInformation();
                    break;

                case Menu.DeleteInformation:
                    Controller.DeleteInformation();
                    break;

                case Menu.UpdateInformation:
                    Controller.UpdateInformation();
                    break;

                case Menu.ViewAllInformation:
                    Controller.ViewAllInformation();
                    break;

                case Menu.Quit:
                    Console.WriteLine("Sayonara!");
                    appStatus = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice Entered.");
                    break;
            }
        }
    }
}