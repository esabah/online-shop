
# Online Shop  - Assesment Project
Including 3 services : Customer, Product and Order.

## Used External Libraries

- MediatR.
- MassTransit.
- RabbbitMq.Client.
- AutoMapper.

# Creating & Running Docker Images 

Use following command for building and running docker containers.
```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
(Be sure Docker deamon is up before running command)
```
This will create and run 4 docker containers one for each service and one for the rabbit mq.
After running images you can check services on following links.

-Product Service: http://localhost:8086/swagger/index.html

-Customer Service: http://localhost:8085/swagger/index.html

-Order Service : http://localhost:8087/swagger/index.html

-Rabbit Console: http://localhost:15672/

# Building Application & Running Tests Locally

Use following command for build application locally:
```
dotnet restore online-shop.sln

dotnet build online-shop.sln

```
Use following command for running unit test:

```
dotnet test online-shop.sln

```
Use following command formatting code after editing:

```
dotnet format ./online-shop.sln

```
# Diagrams


[Class diagram of Customer Service](/Diagrams/CustomerServiceClassDiagram.png)

[Class diagram of Order Service](/Diagrams/OrderServiceClassDiagram.png)

[Class diagram of Product Service](/Diagrams/ProductServiceClassDiagram.png)

[Data Model Diagram] (/Diagrams/Data Diagram.pdf)



