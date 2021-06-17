# Sundown Boulevard

This is a simple table booking system for an imaginary restaurant SundownBoulevard.

Currently the restaurant has 10 tables, it opens at 16 and closes at 22 and tables will always be booked for 2 hours. Should these requirements change they can be modified in the appsettings section:

```
    "BookingSettings": {
        "TotalTables": 10,
        "TableBookingDuration": 2,
        "OpeningHour": 16,
        "ClosingHour": 22,
        "BeerMenuEndpoint": "https://api.punkapi.com/v2/beers",
        "FoodMenuEndpoint": "https://www.themealdb.com/api/json/v1/1/random.php"
    },
```

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
2. Since only booked tables are stored in the Database, the data of exactly how many guests are arriving is omitted. We deem this okay for now as the waiter will only have had set the table for 1 extra guest.
    * This could be solved by extending the database, saving the number of guests.
3. Similar to 2. right now it is assumed  that a table will always only have room for 2 guests. Should this requirement change the code will have to be extended.

