# User management API (CQRS, FluentValidations, MediatR)
This project consists in a user management API using the CQRS pattern with MediatR and FluentValidations, and EntityFramework.InMemory ORM for demo purposes.

## Building the docker image
In the root folder, open your command tool and run:

```
docker build -t usermanagement .
```

After that, open Docker dashboard, access "Images" tab and them you'll can see the *usermanagement* image right there. Run it with **Local Host** 5000 port, and you are ready to go.

## Using with Postman
You can grab the postman collection for this project inside **Docs** folder. It has some requests to use with this project, like:
* Get all users;
* Create user;
* Delete user;
* Update user;
* Get by email;
