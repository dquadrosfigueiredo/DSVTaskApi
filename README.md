This is a .Net8 WebApi created for my DSV application, which deals with Star Wars characters, planets, and spaceships.


It consists of three layers, the Controller layer, the Service layer, and the Repository layer. 
This was designed this way to separate concerns and be more maintainable and easier to test.

Some of the good practices I have employed are:
 - Dependency Injection
 - DTOs for transferring objects instead of internal entities
 - Repository Pattern with Service Layer
 - Logging
 - Swagger
 - Unit Test using Moq
