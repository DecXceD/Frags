# Frags - ASP.NET Core MVC Fragrance Shop

The project is an online fragrance shop where users can:
- Browse fragrances
- View fragrance details
- Filter, search and sort fragrances
- Add fragrances to a shopping cart (session-based)
- View brands and categories
- View contact information
- Manage content through an admin panel (fragrances, brands, categories, contact)

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5
- Razor Views
- ASP.NET Identity
- xUnit (unit testing)
- Moq (mocking for tests)
- EF Core InMemory (testing database)

## Architecture

The project follows a layered architecture:

- Frags.Data – database models, DbContext, configurations, seeding
- Frags.Services – business logic (services)
- Frags – presentation layer (controllers + views)
- Frags.Tests – unit tests for services

## Models

### Fragrance
- Id (primary key)
- Name
- Price
- ImageUrl
- Description
- Gender
- CategoryId (foreign key)
- Category (access the related category)
- BrandId (foreign key)
- Brand (access the related brand)

### Brand
- Id
- Name
- Fragrances (collection of related fragrances)

### Category
- Id (primary key)
- Name
- Fragrances (collection of related fragrances)

### Contact
- Id
- Email
- Phone

### CartItem
- Id
- FragranceId
- Fragrance
- Quantity
- SessionId

### IdentityUser
- Used for authentication and roles (Admin/User)

## ViewModels

### BrandFormModel
- Id
- Name

### CategoryFormModel
- Id
- Name

### CategoryViewModel
- Id
- Name
- Fragrances (collection of CategoryViewModel)

### FragranceFormModel
- Id
- Name
- Price
- ImageUrl
- Description
- BrandId
- Brands (collection of BrandFormModel)
- CategoryId
- Categories (collection of CategoryFormModel)
- Gender

### FragranceViewModel
- Id
- Name
- Price
- ImageUrl
- Description
- Brand
- BrandId
- Category
- CategoryId
- Gender

### FragranceShopModel
- Fragrances (collection of FragranceViewModel)
- TotalItems

### ContactFormModel
- Id
- Email
- Phone

### ContactViewModel
- Id
- Email
- Phone

## Services

- BrandService – CRUD for brands  
- CategoryService – CRUD for categories  
- FragranceService – CRUD for fragrances + filtering + sorting + pagination  
- CartService – session-based shopping cart  
- ContactService – contact information management 

## Controllers

**HomeController**  
- Handles the home page and general site navigation

**ShopController**  
- Handles the shopping experience - browsing fragrances, viewing details, filtering, sorting

**Brands Controller**
- Handles brand-related actions - list brands, details for all related fragrances

**Categories Controller**
- Handles category-related actions - list categories, details for all related fragrances

**Contact Controller**
- Handles contact-related actions - list, edit

**Cart Controller**
- Handles shopping cart actions - view cart, add to cart, remove from cart, update quantity

**Admin Controller**
- Handles administrative actions - list functions for managing fragrances, brands, categories (Admin only)

**ManageBrandsController**
- Handles CRUD operations for brands (Admin only)

**ManageCategoriesController**
- Handles CRUD operations for categories (Admin only)

**ManageFragrancesController**
- Handles CRUD operations for fragrances (Admin only)

## Views

**Home**  
- Index.cshtml - home page  
- Privacy.cshtml - privacy policy

**Shop**  
- Index.cshtml - home page with all fragrances  
- Details.cshtml - fragrance details

**Brands**
- Index.cshtml - home page with all brands
- Details.cshtml - brand details with related fragrances

**Categories**
- Index.cshtml - home page with all categories
- Details.cshtml - category details with related fragrances

**Contact**
- Index.cshtml - contact information
- Edit.cshtml - form to edit contact information

**Cart**
- Index.cshtml - shopping cart

**Shared**  
- _Layout.cshtml - common layout for all pages  
- _LoginPartial.cshtml - partial view for login/logout links

**Other**  
- _ViewImports.cshtml - imports for all views (e.g., namespaces)
- _ViewStart.cshtml - sets the default layout for views

## Views in Admin Area

**Admin**  
- Index.cshtml - admin dashboard with links to ManageFragrances, ManageCategories, ManageBrands

**ManageFragrances**  
- Index.cshtml - list of fragrances  
- Details.cshtml - fragrance details  
- Create.cshtml - form to create a new fragrance  
- Edit.cshtml - form to edit an existing fragrance  
- Delete.cshtml - confirmation page for deleting a fragrance

**ManageCategories**
- Index.cshtml - list of categories
- Create.cshtml - form to create a new category
- Delete.cshtml - confirmation page for deleting a category

**ManageBrands**
- Index.cshtml - list of brands
- Create.cshtml - form to create a new brand
- Delete.cshtml - confirmation page for deleting a brand

**Other**
- _ViewImports.cshtml - imports for all views in the Admin area (the same as the main area)
- _ViewStart.cshtml - sets the default layout for Admin views (the same as the main layout)

## Navigation

**Home/Main Page**  
- `/Home` - displays the home page  
- `/Home/Index` - displays the home page

**Shop**  
- `/Shop` - displays all fragrances  
- `/Shop/Details/{id}` - shows fragrance details

**Brands**  
- `/Brands` - displays all brands  
- `/Brands/Details/{id}` - shows brand details

**Categories**  
- `/Categories` - displays all categories  
- `/Categories/Details/{id}` - shows category details

**Privacy**  
- `/Home/Privacy` - displays the privacy policy

**Contact**  
- `/Contact` - displays contact information  
- `/Contact/Edit` - form to edit contact information

**Admin**  
- `/Admin/Admin` - displays the admin dashboard (a simple page with links to ManageFragrances, ManageCategories, ManageBrands)
- `/Admin/ManageFragrances` - displays the fragrance management page  
- `/Admin/ManageFragrances/Create` - form to create a new fragrance  
- `/Admin/ManageFragrances/Edit/{id}` - form to edit an existing fragrance  
- `/Admin/ManageFragrances/Details/{id}` - shows fragrance details  
- `/Admin/ManageFragrances/Delete/{id}` - confirmation page for deleting a fragrance
- `/Admin/ManageCategories` - displays the category management page
- `/Admin/ManageCategories/Create` - form to create a new category
- `/Admin/ManageCategories/Delete/{id}` - confirmation page for deleting a category
- `/Admin/ManageBrands` - displays the brand management page
- `/Admin/ManageBrands/Create` - form to create a new brand
- `/Admin/ManageBrands/Delete/{id}` - confirmation page for deleting a brand

**Cart**  
- `/Cart` - displays the shopping cart

**Authentication**  
- `/Identity/Account/Register` - user registration page  
- `/Identity/Account/Login` - user login page
- `/Identity/Account/Manage` - user account management page

## Database
- Entity Framework Core (Code First)
- SQL Server
- Migrations enabled
- Seeded data:
  - Categories
  - Brands
  - Fragrances
  - Contact information

## Setup Instructions
1. Clone the repository  
2. Open the solution in Visual Studio  
3. Restore NuGet packages  
4. Run Update-Database in the Package Manager Console to apply migrations and seed the database  
5. In `Program.cs`, set an email and a password to create a default admin user
6. In `FragsDbContext`, set an email and a phone number to seed contact information
7. Start the application  

The project runs using the default configuration. If needed, the connection string can be changed from `appsettings.json` to access the database from MSSQL instead of SQL Server Object Explorer.

## Testing

- xUnit unit tests  
- Moq for mocking  
- EF Core InMemory database

## Future Improvements
- Orders and checkout  
- Reviews

## Author
Alexander Isaev (DecXceD)  

Student project for ASP.NET Advanced course.