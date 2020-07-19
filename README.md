This C# .NET core (2.2.0) solution is a simulator of a toy robot that moves on a tabletop. The development of this project is driven by unit tests. These are included in this repository.
A full requirements specification can be found here:

Design Patterns Used:

1. Command : A class is used to represent user input data, validate it and return appropriate object types or error messages. The class has no dependencies and it's methods are unit tested before being set to work with the rest of the application.
2. Instructions and Valid Commands : Follow the on screen instructions to place a robot and move it around the board. To exit the application at any time type EXIT (this must be in uppercase)
3. PLACE X,Y,FACING : This puts the toy on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. If the toy is already placed, issuing another valid PLACE command will place the toy in the newly specified location.
4. MOVE : This moves the toy one unit forward in the direction it is currently facing.
5. LEFT : This rotates the toy 90 degrees to the left (i.e. counter-clockwise) without changing the position.
6. RIGHT : This rotates toy 90 degrees to the right (i.e. clockwise) without changing the position.
7. REPORT : This announces the X,Y and direction of the toy by printing to the console.

Installing and Running:

Clone the code and open it in Visual studio. Run the solution and test it.

Unit Testing

Tests were run using the nuget packages: NUnit 3.11.0 and Adapter: 3.11.0

