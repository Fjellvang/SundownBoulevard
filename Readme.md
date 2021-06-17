#Sundown boulevard

#### Getting Started:
To Run the project you need the following:
1. Ensure .Net 5 is installed on your machine.
2. A fresh MSSQL database.
	* Once acquired, input your connection string in appsettings.json.


#### Issues And Shortcomings:
1. A user can place a booking exactly at the closing hour. The restaurant might not find it amusing to stay open for an extra two hours. I reccomend the closing hour defined in appsettings
		are configured to last possible booking hour.


#### Nice to have:
1. Strongly typed Menu Ids:
		Currently menu IDs are simple ints, which mean you can pass a beer menu id to a function looking for a food menu id. In a better version we would have strongly typed ids like
		BeerId, or, StronglyTypedId<Beer> making functioncalls easier to reason about.
2. Better front end:
		It would have been cooler if the user was shown more data relating to the menus, instead of just a dropdown with the name. But i chose to focus on the back end side.
		The FE is super rudimentary