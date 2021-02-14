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
GET https://localhost:44344/api/meetup/4devs
```

After commit __[*][pc] Add controller for meetups__:
```sh
PM> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

