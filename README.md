# Project-Feedback-REST-API

This project is a REST API that can be used for submitting feedback of school projects into a database. The API is implemented using ASP.NET and Entity Framework Core. Built-in logger is used for logging. The database is an Azure SQL Database.

## Running the API

The API can be tested out by running the solution file **ProjectFeedbackAPI.sln** in Visual Studio. The file is located in the project root. A Swagger UI can then be accessed in the url: **localhost:5298/swagger/index.html**, where the HTTP methods can be tried out.

## Database

The database used in the assignment is an Azure SQL Database. The database contains a table for storing projects. The table has columns "id", "name", "grade" and "feedback", which are the basic attributes of a school project feedback. <br>
The API connects to the database via a connection string, that is specified in the **appsettings.json** -file. No authentication is used for the sake of simplicity. Therefore the database id and password are left in the connection string.

## Structure

#### Program.cs

Handles the building and running of the API. The connection to the SQL database is also configured here.

#### ProjectsController.cs

A controller for the project -model. Contains the functionality of the HTTP methods.

#### Project.cs

Here, the SQL "Project" table is converted to a class called **Project**. The SQL table columns are defined here as members. Also, restrictions for each column are defined.

#### MyProjectDatabase.cs

Handles the functionality of communicating with the database.
