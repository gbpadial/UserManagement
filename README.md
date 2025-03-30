# User management API (CQRS, FluentValidations, MediatR)
This project consists in a user management API using the CQRS pattern with MediatR and FluentValidations, and EntityFramework.InMemory ORM for demo purposes.

This project was built in .Net 8.0.

## Building the docker image
In the root folder, open your command tool and run:

```
docker build -t usermanagement .
```

## Running the docker image

Run the following command in a terminal:

```
docker run -p 8080:8080 usermanagement
```

And them, open it in your browser: 

```
http://localhost:8080/swagger/index.html
```