# TruckAPI (Technical Assesment)
Written for TBA Group 

## Scope

Create an API in the framework/language of your choice that contains the following routes:

GET /Trucks
POST /Truck

These endpoints should accept/return a JSON object that contains the following
information:

| Field Name |Data Type  |
|--|--|
| ID | Guid |
| Registration | String |
|GrossWeight | Numeric |
| TareWeight | Numeric |
| NetWeight | Numeric |
| Haulier | String | 

This information needs to be stored in a database of your choice.

## Working Endpoints
- [GET] /Trucks  - Returns all trucks in the db.
- [GET] /Truck/[ID] - Returns single truck with a matching ID.
- [POST] /Trucks - Adds a new truck record.
- [PUT] /Truck - Updates an existing truck record.
- [DELETE] /Truck - Deletes an existing truck record.

 ## Notes
 - This is written in C# using .NET 8.0 with SQLExpress as the DB of choice.
- This includes the GET, POST, PUT and DELETE methods.
- Tested using the both SwaggerUI as well as Postman

## Potential Improvements
- More security in the accessing of the API
- Input validation
- Updating multiple records in 1 request.
 