Frags - ASP.NET Core MVC Fragrance Shop

The project is an online fragrance shop where users can:
- Browse fragrances
- View fragrance details
- Manage fragrances through CRUD operations(will be limited to admin users in the second part of the project)

Technologies Used:
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Razor Views
- ASP.NET Identity

Models:
Fragrance
- Id(primary key)
- Name
- Price
- ImageUrl
- Description
- Gender
- CategoryId(foreign key)
- Category(access the related category)

Category
- Id(primary key)
- Name
- Fragrances(collection of related fragrances)

IdentityUser
- Used for authentication (ASP.NET Identity)

Controllers:
FragrancesController 
- Handles fragrance-related actions (details, create, edit, delete)

HomeController 
- Handles the home page and general site navigation

ShopController 
- Handles the shopping experience (browsing fragrances)

Views:
Home
- Index.cshtml (home page)
- Privacy.cshtml (privacy policy)

Shop
- Index.cshtml (home page with featured fragrances)
- Details.cshtml (fragrance details)

Manage Fragrances
- Index.cshtml (list of fragrances)
- Details.cshtml (fragrance details)
- Create.cshtml (form to create a new fragrance)
- Edit.cshtml (form to edit an existing fragrance)
- Delete.cshtml (confirmation page for deleting a fragrance)

Shared
- _Layout.cshtml (common layout for all pages)
- _LoginPartial.cshtml (partial view for login/logout links)

Navigation:
Home/Main Page
-`/Home` - Displays the home page
-`/Home/Index` - Displays the home page

Privacy
-`/Home/Privacy` - Displays the privacy policy

Shop
-`/Shop` - Displays all fragrances
-`/Shop/Details/{id}` - Shows fragrance details

Manage Fragrances
-`/Fragrances` - Displays the fragrance management page
-`/Fragrances/Details/{id}` - Shows fragrance details
-`/Fragrances/Create` - Form to create a new fragrance
-`/Fragrances/Edit/{id}` - Form to edit an existing fragrance
-`/Fragrances/Delete/{id}` - Confirmation page for deleting a fragrance

Authentication
-`/Identity/Account/Register` - User registration page
-`/Identity/Account/Login` - User login page

Database:
- Entity Framework Core
- SQL Server
- Code First approach
- Migrations enabled
- Seeded initial data (categories and fragrances, default admin user will be added in the second part of the project)

Setup Instructions:
1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Run Update-Database in the Package Manager Console to apply migrations and seed the database
5. Start the application

The project runs using the default configuration. If needed - the connection string can be changed from appsettings.json in order to access the database from MSSQL instead of SQL Server Object Explorer.

Future Improvements (ASP.NET Advanced):
- Admin roles and authorization
- Shopping cart system
- Orders and checkout
- Filtering and searching
- Improved UI/UX

Author:
Alexander Isaev(DecXceD)

Student project for ASP.NET Fundamentals course.