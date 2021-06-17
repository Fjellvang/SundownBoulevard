



Nice to have:

	- Strongly typed Menu Ids:
		Currently menu IDs are simple ints, which mean you can pass a beer menu id to a function looking for a food menu id. In a better version we would have strongly typed ids like
		BeerId, or, StronglyTypedId<Beer> making functioncalls easier to reason about.