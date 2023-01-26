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
***
## Description

A web app for tracking job search, displaying data from user-inputted search metrics.

### Objectives (MVP)

#### User Stories
* User can create and login to a user profile. 
* When logged in, user can:
  * View all applications 
  * Add new applications 
  * Update application details 
  * Delete applications 
* When logged in, the "splash" page includes:
  * Weekly application average 
  * List of Applications 
  * Count of Companies Applied to 

#### Schema
* Includes relational databases to track multiple job applications for a given user.
  schema: search_coach
  tables: User Profiles, Companies, Applications, Status

#### Classes
* Profile class joins users to profiles.
* Company class contains company name, one-to-many relationship with Application and has full CRUD functionality.
* Application class contains application data (companyId, role, salary, location, remote/hybrid/in-person, etc.) and has full CRUD functionality.
* Status class contains status details

### Goals
1. ✅ Meet MVP
2. ✅ Create & call SearchCoachQuotesAPI to deliver inspiration on splash page
3. Only show open applications on splash page
4. (Stretch) Add method for displaying new job listings based on saved search
5. (Stretch) Integrate with Git / LinkedIn to track progress on skill-building, networking, etc.
***
## Process
[Check out our workflow on Figma](https://www.figma.com/file/GfiIBt7LRBAZO8jV8HCKsW/Search-Coach?node-id=0%3A1)
### Schema 
![Screenshot of Schema](SearchCoach/wwwroot/img/schema.png)
### Schedule
Day 1 – Companies & Applications | HS + KO on back end | AC + BW on front end

Day 2 – Splash Page & Authentication | HS + KO on back end | AC + BW on front end

Day 2 – Splash Page & Troubleshooting Stats Bugs | HS + KO on back end | AC + BW on front end

Day 4 – Build quotes API & add random quote to app | all hands on the API buildout & call

***
## Setup/Installation Requirements

#### Connect to SearchCoachAPI
1. Clone the `SearchCaochApi` to your machine
[Link to SearchCaochApi Repo](https://www.figma.com/file/GfiIBt7LRBAZO8jV8HCKsW/Search-Coach?node-id=0%3A1https://github.com/kirstenopstad/SearchCoachApi)
2. Navigate to the `SearchCoachApi` project directory
3. Create a file named `appsettings.json` with the following code. Be sure to update the Default Connection to your MySQL credentials.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=search_coach_api;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
4. Install dependencies by running in the project directory
```
$ dotnet restore
```
5. Build local copy of database by running in the project directory
```
$ dotnet ef database update
```
6. Build & run API in development by running in the project directory
 ```
 $ dotnet run
 ```


dotnet watch run

#### Open project
1. Navigate to the `SearchCoach` directory.
2. Create a file named `appsettings.json` with the following code. Be sure to update the Default Connection to your MySQL credentials.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=search_coach;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}
```
3. Install dependencies within the `SearchCoach` directory
```
$ dotnet restore
```

4. To build & run program in development mode 
 ```
 $ dotnet run
 ```

5. To build & run program in production mode 
 ```
 dotnet run --launch-profile "production"
 ```
***
## Known Bugs

* No known bugs. If you find one, please email me at kirsten.opstad@gmail.com with the subject **[_Repo Name_] Bug** and include:
  * BUG: _A brief description of the bug_
  * FIX: _Suggestion for solution (if you have one!)_
  * If you'd like to be credited, please also include your **_github user profile link_**
***
## License

MIT License

Copyright (c) 2023 Kirsten Opstad, Bodie Wood, Henry Sullivan, and Anton Chumachenko

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
