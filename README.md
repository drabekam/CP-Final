# CP-Final
Used for the CP final Project



Overview

  - Develop an API that allows 4 controllers to interact with four tables (1 each)
  - Usinbg the code first approach set up the required tables


- For each of the controllers
  - implement CRUD
    -  Create: Add new records to the table.
    -  Read: Retrieve one or multiple records. Implement methods to get a single record by ID and to get all records.
    -  pdate: Modify existing records.
    -  Delete: Remove records from the table.
   
- File  strucutre
main(whatevername).csproj - The project file with configuration and dependencies for your .NET application.

TeamMemberController.cs - Controller for CRUD operations on the Team Member Information table.

HobbiesController.cs - Controller for CRUD operations on the Team Member Hobbies table.

FavoriteFoodsController.cs - Controller for CRUD operations on the Team Member Favorite Foods table.

FavoriteSeasonController.cs - Controller for CRUD operations on the Team Member Favorite Season table.

TeamMember.cs - Model for the Team Member Information table.

Hobby.cs - Model for the Team Member Hobbies table.

FavoriteFood.cs - Model for the Team Member Favorite Foods table.

FavoriteSeason.cs - Model for the Team Member Favorite Season table.

ApplicationDbContext.cs - The Entity Framework Core context class for database interaction.

Migrations (Folder) - Contains migration files for database schema creation and updates.

Program.cs and Startup.cs (or appsettings.json for .NET 6+) - Files for configuring and launching the ASP.NET application.

appsettings.json - Contains configuration settings like database connection strings.

.gitignore - Specifies untracked files to be ignored by Git.

README.md - Documentation for your project, setup instructions, and other information.





Order of creation

1. Define the models needed
2. Set up DB context files needed
3. configure the startup classes
4. create migration
5. apply migration to create the database
6. develop controllers
7. test
8. create the video
