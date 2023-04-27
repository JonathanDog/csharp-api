**Owner Endpoints**

*GET api/owner*
- Returns all owners from owner table
- Request Body: NONE
- Request Response:
    {
        "statusCode": 200,
        "statusDescription": "Success, returning all owners",
        "owners": [
            {
                "ownerId": 2,
                "firstName": "John",
                "lastName": "Smith",
                "phoneNumber": "1112223333"
            }
        ],
        "pets": []
    }


*GET api/owner/{id}*
- Returns owner from owner table with specific id
- Body: NONE
- Succesfull Response:
    {
        "statusCode": 200,
        "statusDescription": "Success, found owner with id {id}",
        "owners": [
            {
                "ownerId": {id},
                "firstName": "John",
                "lastName": "Smith",
                "phoneNumber": "1112223333"
            }
        ],
        "pets": []
    }
- Not-Found Response:
    {
        "statusCode": 404,
        "statusDescription": "Not Found, owner id 3 returns null",
        "owners": [],
        "pets": []
    }

*POST api/owner*
- creates owner record in database
- Body:
  {
  "firstName": "John",
  "lastName": "Smith",
  "phoneNumber": "718-222-3333"
  }
- Success Response:
    {
    "statusCode" : 201,
    "statusDescription": "Success, created new pet with id 1",
    "owners": [
        {
            "ownerId" : 1,
            "firstName" : "John",
            "lastName" : "Smith",
            "phoneNumber" : "718-222-3333"
        }
    ],22
    "pets" : []
    }
- Unique phone number error response:
    {
        "statusCode": 400,
        "statusDescription": "Error, owner with phone number 1112223333 already exists",
        "owners": [],
        "pets": []
    }

*DELETE api/owner/{id}*
- Deletes a owner record with its id
- Body: NONE
- Success Response:
    {
        "statusCode": 200,
        "statusDescription": "Succesfully deleted owner with id {id}",
        "owners": [],
        "pets": []
    }
- Not-Found Response:
{
    "statusCode": 404,
    "statusDescription": "Nothing deleted, owner id {id} not found",
    "owners": [],
    "pets": []
}