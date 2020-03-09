# BASICdB
>Basically, it's a database builder for narrative media series.

## A Few Notes
1. All '*Expected Input*' fields will be written in the *x-www-form-urlencoded* bulk edit format.
2. *Expected Input* will be filled with dummy data.

## Endpoints
### User Endpoints
**Create Account:** `/api/account/register`

*Expected Input:* 
```
UserName:ExampleUser
Email:test@case.com
Password:P4ssword!
ConfirmPassword:P4ssword!
```
*Expected Output:*
```
no output expected
```
\
**Login (get token):** `/token`

*Expected Input:*
```
UserName:newUser
Password:P4ssword!
grant_type:password
```
*Expected Output:*
```
{
    "access_token": "token here",
    "token_type": "bearer",
    "expires_in": 1209599,
    "userName": "newUser",
    ".issued": "Sat, 07 Mar 2020 15:20:09 GMT",
    ".expires": "Sat, 21 Mar 2020 15:20:09 GMT"
}
```

### Media Endpoints
**Create Media** `/api/media`

*Expected Input:*
```
MediaId:1
Title:Sorcerer's Stone
Medium:3
Description:Harry Potter and the Sorcerer's Stone, the first book
```
\
**Get All Media** `/api/media`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
[
    {
        "User": null,
        "MediaId": 1,
        "Title": "Sorcerer's Stone",
        "Medium": 3,
        "Description": "Harry Potter and the Sorcerer's Stone, the first book",
        "UserId": null
    },
    {
        "User": null,
        "MediaId": 2,
        "Title": "Goblet of Fire",
        "Medium": 5,
        "Description": "Harry Potter and the Goblet of Fire, the fourth(?) book",
        "UserId": null
    }
]
```
\
**Update a Media** `/api/media`

*Expected Input:*
```
MediaId:1
Title:Goblet of Fire
Medium:5
Description:Harry Potter and the Goblet of Fire, the fourth(?) book
```
*Expected Output:*
```
no output expected
```
\
**Delete a Media** `/api/media/{#}`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
no output expected
```


### Character Endpoints
**View All Characters:** `api/character`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
[
    {
        "Item": [],
        "Media": [],
        "User": null,
        "CharId": 1,
        "Name": "Sword in the Stone",
        "ShortDescription": "Sword in stone",
        "Description": "Legend has it, whoever can pull the sword out of this stone will be destined for greatness...",
        "UserId": null
    },
    {
        "Item": [],
        "Media": [],
        "User": null,
        "CharId": 2,
        "Name": "Hermione Granger",
        "ShortDescription": "Hermione Granger of Gryffindor",
        "Description": "Hermione is the smart student in the main bunch",
        "UserId": null
    }
]
```
\
**View One Character:** `/api/character/{#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
{
    "CharId": 2,
    "Name": "Hermione Granger",
    "ShortDescription": "Hermione Granger of Gryffindor",
    "Description": "Hermione is the smart student in the main bunch"
}
```
\
**Create a Character:** `api/character/`

*Expected Input:*
```
Name:Hermione Granger
ShortDescription:Hermione Granger of Gryffindor
Description:Hermione is the smart student in the main bunch
```
*Expected Output:*
```
no output expected
```
\
**Delete a Character:** `/api/character`
*Expected Input:*
```
no input expected
```
*Expected Output:*
```
no output expected
```

### Item Endpoints
