# BeerNet
This is the web API

It supports GET POST and DELETE for recipes, hops, fermentables, yeasts, and adjuncts.

To insert an object, use the following URL:
localhost:50422/beernet/hop
With a payload of:
{name: "Azaca", aau: 5.5}

It will return with a response:
{Success: true, Message: "the new ID of the inserted hop"}

To update it:
localhost:50422/beernet/hop/the ID to update
Payload:
{name: "New Name", aau: 7.7}

The objects in the backend of the API have up to 2 id fields: Object Id and string idString.
ObjectId: This is the ObjectId id from MongoDB
idString: This is the ToString of ObjectId.
