# MeetupAPI

## Configuration

After commit __[*][pc] Add MeetupContext and Cleaning__:

```sh
PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer
PM > Install-Package Microsoft.EntityFrameworkCore.Tools
PM> update-database -v
```

## Postman
```sh
GET https://localhost:44344/api/meetup
```

After commit __[*][pc] Add controller for meetups__:
```sh
PM> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

After commit __[*][pc] GET method for single meetup__:
```sh
GET https://localhost:44344/api/meetup/4devs
GET https://localhost:44344/api/meetup/web-summit
GET https://localhost:44344/api/meetup/test
```


After commit __[*][pc] Add POST method for Meetup__

```sh
POST https://localhost:44344/api/meetup/
Raw - Json:
{
    "name": "JsEvent",
    "organizer": "chrome",
    "date": "2020-03-03T15:30:00",
    "isPrivate": false
}
```

After commit __[*][pc] Simple validation atributes__

```sh
Request:

POST https://localhost:44344/api/meetup/
Raw - Json:
{
}

Response:

{
    "Name": [
        "The Name field is required."
    ],
    "Organizer": [
        "The Organizer field is required."
    ]
}
```

After commit __[*][pc] Add PUT method for meetup__
```sh
PUT https://localhost:44344/api/meetup/test


404 Not Found

```

