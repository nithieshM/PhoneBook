# PhoneBook Application

## Overview

This is a simple console-based PhoneBook application written in C#. The application allows users to manage their contacts by adding, deleting, updating, and viewing contact information.

## Features

- **Add Information**: Add a new contact with name, email, and phone number.
- **Delete Information**: Delete an existing contact by providing its ID.
- **Update Information**: Update the details of an existing contact.
- **View All Information**: Display all contacts stored in the PhoneBook.

## Requirements

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 5.0 or higher)
- PostgreSQL database

## Installation

1. Clone the repository to your local machine:

    ```bash
    git clone <repository-url>
    ```

2. Navigate to the project directory:

    ```bash
    cd PhoneBook
    ```

3. Restore the dependencies:

    ```bash
    dotnet restore
    ```

4. Update the database connection string in `PostgresContext.cs` to match your PostgreSQL database settings.

5. Build the application:

    ```bash
    dotnet build
    ```

6. Run the application:

    ```bash
    dotnet run
    ```

## Usage

Upon running the application, you will be presented with a menu offering various options to manage your contacts. Use the arrow keys to navigate through the menu and press Enter to select an option.

- **Add Information**: Enter the contact's name, email, and phone number. The application will validate the input before adding the contact.
- **Delete Information**: Enter the ID of the contact you want to delete. Confirm the deletion when prompted.
- **Update Information**: Enter the ID of the contact you want to update. Provide the new details for the contact.
- **View All Information**: Display all contacts stored in the PhoneBook.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
