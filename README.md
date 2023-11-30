## Guitar Vendor

#### A web application that allows users to manage guitars and the stores that sell them.

#### By Brian Scherner

## Technologies Used

* C#
* .NET
* ASP.NET MVC
* MySQL
* EF Core
* EF Migrations

## Description

This application presents users with a splash page for a guitar vendor. Users are presented with a list of stores and a list of guitars. Users can navigate to `Manage guitars` or `Manage stores` to begin adding to their respective lists. **Note: a store will have to be added before a guitar can be added.** To add a store, users can navigate to a form where they enter a name and description for the store. They can then view the stores details by selecting it. Users can also edit the stores information, and delete it from the application if they wish.

To add a guitar, users can navigate to a form where they enter a guitar's brand, model, color, type, price, year, and then select a store to add it to. They can view a guitars details by selecting it. Users can also edit a guitar, and delete it from the application if they wish.

There is a many-to-many relationship between guitars and stores here. As in, a guitar can belong to many stores, and a store can sell many guitars. Users can add multiple stores to a guitar, and multiple guitars to a store. Users can also delete an individual guitar from a store, or an individual store from a guitar.

## Setup Instructions

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-01-welcome-to-c).

### Set Up and Run Project

1. Clone this repository to your desktop.
2. Open the terminal and navigate to this project's production directory called `GuitarVendor`.
3. Within the production directory `GuitarVendor`, create a new file called `appsettings.json`.
4. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. For the LearnHowToProgram.com lessons, always assume the `uid` is `root` and the `pwd` is `epicodus`.

```json
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=guitar_vendor_with_many_to_many;uid=root;pwd=epicodus;"
    }
}
```

5. Create the database using the migrations in the Guitar Vendor project. Open your terminal to the production directory called `GuitarVendor`, and run `dotnet ef database update`.
    * If you need to create your own migration, run the command `dotnet ef migrations add MigrationName`, where `MigrationName` is your custom name for the migration in UpperCamelCase format.

6. Within the production directory called `GuitarVendor`, run `dotnet watch run` in the command line to start the project in development mode with a watcher.
7. Open the browser to [https://localhost:5001](https://localhost:5001). If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this LearnHowToProgram lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-2-basic-web-applications/3-2-0-17-redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

When validating properties for models that are integers, the default message that displays is not necessarily clear or easy to understand. While it does technically work, I would like to address this issue.

## License

MIT

Copyright(c) 2023 Brian Scherner