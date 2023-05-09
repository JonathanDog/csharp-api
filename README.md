### Pet-API
#Purpose
This API allows you to store pets and owners in a database. For example if a pet gets lost and their pet id is on their collar. You can search up the id through the api and be able to get the contact information of the owner.  

**Owner Endpoints**

*GET api/owner*
- Returns all owners from owner table
- Request Body: NONE
- Request Response:
    `{
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
    }`


*GET api/owner/{id}*
- Returns owner from owner table with specific id
- Body: NONE
- Succesfull Response:
    `{
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
    }`
- Not-Found Response:
    `{
        "statusCode": 404,
        "statusDescription": "Not Found, owner id 3 returns null",
        "owners": [],
        "pets": []
    }`

*POST api/owner*
- creates owner record in database
- Body:
  `{
  "firstName": "John",
  "lastName": "Smith",
  "phoneNumber": "718-222-3333"
  }`
- Success Response:
    `{
    "statusCode" : 201,
    "statusDescription": "Success, created new owner with id 1",
    "owners": [
        {
            "ownerId" : 1,
            "firstName" : "John",
            "lastName" : "Smith",
            "phoneNumber" : "718-222-3333"
        }
    ],
    "pets" : []
    }`
- Unique phone number error response:
    `{
        "statusCode": 400,
        "statusDescription": "Error, owner with phone number 1112223333 already exists",
        "owners": [],
        "pets": []
    }`

*DELETE api/owner/{id}*
- Deletes a owner record with its id
- Body: NONE
- Success Response:
    `{
        "statusCode": 200,
        "statusDescription": "Succesfully deleted owner with id {id}",
        "owners": [],
        "pets": []
    }`
- Not-Found Response:
`{
    "statusCode": 404,
    "statusDescription": "Nothing deleted, owner id {id} not found",
    "owners": [],
    "pets": []
}`


**Pet Endpoints**

*GET api/pet*
- Returns all pets from pet table
- Request Body: NONE
- Request Response:
   ` {
        "statusCode": 200,
        "statusDescription": "Success, returning all pets",
        "owners": [],
        "pets": [
            {
                "petId": 2,
                "petName": "Martha",
                "petType": "Dog",
                "ownerId": "1"
            }
        ]
    }`


*GET api/pet/{id}*
- Returns pet from pet table with specific id
- Body: NONE
- Succesfull Response:
    `{
        "statusCode": 200,
        "statusDescription": "Success, found owner with id {id}",
        "owners": [],
        "pets": [
            {
                "petId": {id},
                "petName": "Martha",
                "petType": "Dog",
                "ownerId": "1"
            }
        ]
    }`
- Not-Found Response:
   ` {
        "statusCode": 404,
        "statusDescription": "Not Found, pet id {id} returns null",
        "owners": [],
        "pets": []
    }`

*POST api/pet*
- creates owner record in database
- Body:
  `{
	"petName": "Martha",
	"petType": "Dog",
	"ownerId": "1"
  }`
- Success Response:
   ` {
    "statusCode" : 201,
    "statusDescription": "Success, created new pet with id 1",
    "owners": [],
    "pets": [
            {
                "petId": {id},
                "petName": "Martha",
                "petType": "Dog",
                "ownerId": "1"
            }
        ]
    }`

*DELETE api/pet/{id}*
- Deletes a pet record with its id
- Body: NONE
- Success Response:
    `{
        "statusCode": 200,
        "statusDescription": "Succesfully deleted owner with id {id}",
        "owners": [],
        "pets": []
    }`
- Not-Found Response:
`{
    "statusCode": 404,
    "statusDescription": "Nothing deleted, pet id {id} not found",
    "owners": [],
    "pets": []
}`
