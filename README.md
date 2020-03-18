![BASICdB-Logo](https://github.com/tjjarz/BASICdB/blob/master/BASICdB-Logo-Hero.png)


>Basically, it's a database builder for narrative media series.

## Complete Endpoint Documentation
*https://documenter.getpostman.com/view/7631091/SzS2xoay?version=latest#intro* \
Follow the above link to see each endpoint you can interact with on this API and what information it is looking for. Do note that the area's marked `{{url}}` will need to be replaced with the accurate url that the database is running on. (Default url is `https://localhost:44304`)

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
MediaType: Book
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
        "MediaId": 1,
        "Title": "Sorcerer's Stone",
        "MediaType": "Book",
        "Description": "Harry Potter and the Sorcerer's Stone, the first book",
        "UserId": UserName
    },
    {
        "MediaId": 2,
        "Title": "Sorcerer's Stone",
        "MediaType": "Movie",
        "Description": "Harry Potter and the Sorcerer's Stone, the first movie",
        "UserId": UserName
    },
    {
        "MediaId": 3,
        "Title": "Goblet of Fire",
        "MediaType": "Book",
        "Description": "Harry Potter and the Goblet of Fire, the fourth(?) book",
        "UserId": UserName
    }
]
```
\
**View One Media:** `/api/media/{#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
{
        "MediaId": 1,
        "Title": "Sorcerer's Stone",
        "MediaType": "Book",
        "Description": "Harry Potter and the Sorcerer's Stone, the first book",
        "UserId": UserName
    }
```
\
**Update a Media** `/api/media`

*Expected Input:*
```
MediaId: 2
Title: Goblet of Fire
MediaType: Book
Description: Harry Potter and the Goblet of Fire, the fourth(?) book
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
"Successfully deleted"
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
**Delete a Character:** `/api/character{#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
no output expected
```

### Item Endpoints
**Create Item** `/api/item`

*Expected Input:*
```
Name: Harry's Wand
Type: Wand
Description: Harry Potter's magical stick.
```
\
**Get All Item** `/api/item`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
[
    {
        "Name": "Harry's Wand",
        "Type": "Wand",
        "Description": "Harry Potter's magical stick",
        "UserId": Username
    }
]
```
\
**Update a Item** `/api/item`

*Expected Input:*
```
ItemId:1
Name: Harry's Magic Wand
Type: Wand
Description: Harry Potter's powerful stick
```
*Expected Output:*
```
no output expected
```
\
**View One Item:** `/api/item/{#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
{
        "ItemId": 1,
        "Name": "Harry's Magic Wand",
        "Type": "Wand",
        "Description": "Harry Potter's powerful stick",
        "UserId": Username
    }
```
\
**Delete a Item** `/api/item/{#}`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
no output expected
```

### Character/Media Link Endpoints
\
**Add a Character/Media Link** `/api/CharMedia`

*Expected Input:*
```
CharId: 4
MediaId: 1
```
*Expected Output:*
```
no output expected
```
\
**Update a Character/Media Link** `/api/CharMedia`

*Expected Input:*
```
CharMediaId: 3
CharId: 2
MediaId: 2
```
*Expected Output:*
```
no output expected
```
\
**View One Character/Media Link:** `/api/CharMedia?charId={#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
[
    {
        "CharId": 1,
        "Name": "Harry Potter",
        "ShortDescription": "Harry",
        "Description": "Wizard Harry",
        "MediaId": 1,
        "Title": "Sorcerer's Stone",
        "Medium": "Book",
        "MediaDescription": "First in the saga of Harry Potter"
    },
    {
        "CharId": 1,
        "Name": "Harry Potter",
        "ShortDescription": "Harry",
        "Description": "Wizard Harry",
        "MediaId": 2,
        "Title": "Sorcerer's Stone",
        "Medium": "Movie",
        "MediaDescription": "First in the saga of Harry Potter"
    }
]
```
\
**Delete a Character/Media Link** `/api/CharMedia?charMediaId={#}`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
no output expected
```

### Character/Item Link Endpoints
\
**Add a Character/Item Link** `/api/CharItem`

*Expected Input:*
```
CharId: 3
ItemId: 1
```
*Expected Output:*
```
no output expected
```
\
**Update a Character/Item Link** `/api/CharItem`

*Expected Input:*
```
CharItemId:1
CharId: Harry's Magic Wand
ItemId: Wand
```
*Expected Output:*
```
no output expected
```
\
**View One Character/Item Link:** `/api/CharItem?charId={#}`

*Expected Input:*
```
no input expected
```
*Expected Output:*
```
[
    {
        "CharId": 1,
        "Name": "Harry Potter",
        "ShortDescription": "Harry",
        "ItemDescription": "Chooses the wizard",
        "Description": "Wizard Harry",
        "ItemId": 2,
        "ItemType": "Wizard tool",
        "ItemName": "Wand"
    },
    {
        "CharId": 1,
        "Name": "Harry Potter",
        "ShortDescription": "Harry",
        "ItemDescription": "Most powerful wand",
        "Description": "Wizard Harry",
        "ItemId": 1,
        "ItemType": "Wizard tool",
        "ItemName": "Elder Wand"
    }
]
```
\
**Delete a Character/Item Link** `/api/CharItem?charItemId={#}`

*Expected Input:*
```
no input required
```
*Expected Output:*
```
no output expected
```
