 # GameShelf
 
GameShelf is an ASP.NET Core MVC web application designed to help users manage and organize their personal video game collections in one place.
 
 ## Highlights

- Track games with details like title, developer, publisher, release date, and price
- Organize by platform (PlayStation, Xbox, PC, Switch) and genre
- Rate games out of 10 and mark completion status
- Simple CRUD operations demonstrating ASP.NET Core MVC fundamentals
- Clean interface
  
### Why I made this

Honestly, I got tired of buying games on sale and then completely forgetting I owned them. Plus I wanted a real project to practice what I was learning in my ASP.NET Core course - models, views, controllers, Entity Framework, the whole deal. Building something practical made the concepts stick better than just following tutorials.

### What's inside

**Core functionality:**
- Full CRUD operations for Games, Platforms, and Genres
- Form validation using data annotations
- Dropdown lists for selecting platforms and genres
- Database persistence with Entity Framework Core
- Responsive UI that works on mobile

**Tech stack:**
- ASP.NET Core 9.0 MVC
- Entity Framework Core with SQL Server
- Razor views for templating

**Database models:**
- **Games** - Title, developer, publisher, release date, price, personal rating (1-10), completion status
- **Platforms** - Gaming systems (PlayStation, Xbox, PC, etc.)
- **Genres** - Game categories (Action, RPG, Strategy, etc.)

## How to use it

Pretty straightforward:

1. **Set up platforms first** - Add your gaming systems (PlayStation 5, PC, Nintendo Switch, etc.)
2. **Add some genres** - Create categories like RPG, Action, Puzzle, Strategy
3. **Start adding games** - Fill in the details for each game in your collection
4. **Rate and track** - Give games a rating out of 10 and mark which ones you've completed

Browse your collection, edit entries, delete games you got rid of. Standard CRUD operations.

**Validation attributes used:**
- `[Required]` - Field must have a value
- `[StringLength]` - Limits text length
- `[Range]` - Limits number range
- `[DataType]` - Specifies data type
- `[Display]` - Sets display name

## What I learned

This was my first real ASP.NET Core MVC project, so I got hands-on practice with:

1. **MVC Pattern** - Separation of Model, View, Controller
2. **Routing** - How URLs map to controller actions
3. **Model Binding** - Automatic form data to object conversion
4. **Validation** - Data annotations and ModelState
5. **Razor Syntax** - Mixing HTML with C#
6. **ViewBag** - Passing additional data to views
7. **Entity Framework** - Database CRUD operations
