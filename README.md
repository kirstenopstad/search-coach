# Search Coach

#### By Kirsten Opstad, Bodie Wood, Henry Sullivan, and Anton Chumachenko

#### A web app for tracking job application progress.

## Technologies Used

* C#
* .Net 6
* ASP.Net Core 6 MVC
* EF Core 6
* SQL
* MySQL
* MySQL Workbench
* LINQ
* Identity

## Description

A web app for tracking job search, displaying data from user-inputted search metrics.

### Objectives (MVP)

#### User Stories
– User can create and login to a user profile.
– When logged in, user can:
  - View all applications 
  - Add new applications
  - Update application details
  - Delete applications
– When logged in, the "splash" page includes:
  - Weekly application average
  - List of open Applications
  - Count of Companies Applied to

#### Schema
* Includes relational databases to track multiple job applications for a given user.
  schema: search_coach
  tables: User Profiles, Companies, Applications, Status
#### Classes
* Profile class joins users to profiles.
* Company class contains company name, one-to-many relationship with Application and has full CRUD functionality.
* Application class contains application data (companyId, role, salary, location, remote/hybrid/in-person, etc.) and has full CRUD functionality.
* Status class contains status details

<!-- ![Screenshot of Databases](imagelink) -->

<!-- [Link to operational site](http://www.kirstenopstad.github.com/<REPOSITORY NAME>) -->

#### Process

Day 1 – Companies & Applications 
Day 2 – 
Day 3 – 

### Goals
1. Meet MVP
2. Create & call SearchCoachQuotesAPI to deliver inspiration on splash page
3. Add method for displaying new job listings based on saved search
4. Integrate with Git / LinkedIn to track progress on skill-building, networking, etc.

## Setup/Installation Requirements

#### Get copy of MySQL database
1. Clone this repo to your workspace.
2. Open MySQLWorkbench [Click here for instructions to download]
3. Under Administration Tab, select Data Import/Restore
  * Select 'Import from Self Contained File'
  * Select ../animal-shelter-export.sql from the AnimalShelter directory
  <!-- ![Screenshot of MySQL Import Settings](INSERT SCREENSHOT LINK) -->
  * Select "New..." and set new schema name to **PROJECT-NAME**
  * Select 'Start Import'
4. You should now have a copy of the **PROJECT-NAME** database on your machine.

#### Open project
1. Navigate to the `Project Name` directory.
2. Create a file named `appsettings.json` with the following code. Be sure to update the Default Connection to your MySQL credentials.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[PROJECT-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}
```
3. Install dependencies within the `Project Name` directory
```
$ dotnet restore
````

4. To build & run program in development mode 
 ```
 $ dotnet run
 ```

5. To build & run program in production mode 
 ```
 dotnet run --launch-profile "production"
 ```

## Known Bugs

* No known bugs. If you find one, please email me at kirsten.opstad@gmail.com with the subject **[_Repo Name_] Bug** and include:
  * BUG: _A brief description of the bug_
  * FIX: _Suggestion for solution (if you have one!)_
  * If you'd like to be credited, please also include your **_github user profile link_**

## License

MIT License

Copyright (c) 2023 Kirsten Opstad, Bodie Wood, Henry Sullivan, and Anton Chumachenko

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
