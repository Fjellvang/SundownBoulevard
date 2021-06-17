# Sundown boulevard

#### Technologies:
* ASP.Net Core 5
* MS EntityFramework
* NUnit
* Boostrap
* Javascript.

#### Getting Started:
To Run the project you need the following:
1. Ensure .Net 5 is installed on your machine.
2. Open ``Sundown Boulevard.sln``
3. A fresh MSSQL database.
	* Once acquired, input your connection string in appsettings.json.
4. Run the project and happy ordering.

#### Database Migrations
Database migration are applied automatically when you run the project, if the connection string is configured correctly.

#### Improvement Proposals
1. Strongly typed Menu Ids:
	* Currently menu IDs are simple ints, which mean you can pass a beer menu id to a function looking for a food menu id. In a better version we would have strongly typed ids like
		BeerId, or, StronglyTypedId<Beer> making functioncalls easier to reason about.
2. Better front end:
	* Currently Only BE validates, which creates a less than ideal UX, FE validation would be nice.
	* It would have been cooler if the user was shown more data relating to the menus, instead of just a dropdown with the name.
	* I would have preferred to have written the FE in Typescript, but due to time constraints i used basic JS setup with the .net template.


#### Issues And Shortcomings:
1. A user can place a booking exactly at the closing hour. The restaurant might not find it amusing to stay open for an extra two hours. I recommend the closing hour defined in appsettings
		are configured to last possible booking hour.

