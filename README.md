# Sweet Base

Project for visual programming made with ASP.net, Entity Framework and Linq.
Includes two joined tables -- Producents and Products. 
One can view, filter, add, edit and delete producents and products.

## Running
To create a database from packet manager console run:
`update-database`
(you can also create your own migration if you changed something in db schema:
`add-migration <name>`)

Then run program from the SweetBase directory:
`dotnet run seeddata`
to initialize the database with some values.

It may be needed to install:
```
Install-Package Microsoft.EntityFrameWorkCore.Sqlite
Install-Package Microsoft.EntityFrameWorkCore.Tools
Install-Package Microsoft.EntityFrameWorkCore
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.10
```
with the packet manager console first.

## Files
`Models` directory includes definition of objects representing database entities.
`Views` contains the pages for viewing, creating, editing and deleting entries and their components such as a search bar and layout
`Controllers` define the logic for each page
`Migrations` allow to create a database easily.
`DataMock.cs` initializes a db with some values.
`Program.cs` is the main file

---
© Anna Panfil 2023
