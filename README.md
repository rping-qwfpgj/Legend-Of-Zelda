#Sprint 3

Controls: 
WASD and arrow keys are used to move. V is used to shoot a projectile, number keys 1-6 are used to switch between Link's projectiles.
Clicking on the right half of the room switches to the next room, and clicking on the left half of the room switches to the previous room.
Keys Z and N are used to attack. 

Bugs:
current implmenmtation of enemyProjectilePlayer handler cannot be used due to design choices with enemyProjectiles
Goriya is not throwing boomerang
enemies are able to be hit out of bounds
Link's attack into wall state creates collision edge cases in which he may be corrected to outside of the level

Pertinent information about our implementation:
The main things that were added in this sprint was room loading, the room class, collisions. 
A GetHitbox() method was added to all the sprites for the collision purposes, as well as making new interfaces that inherit ISprite
to determine the type of object that has collided.

Collision detector uses exhaustive checking to compare every object in room with every other object in room, once a collision is detected,
the two objects are passed to the collision delegator.

The delegator utilizes the ISprite sub-interfaces to identify each generic room object and then select the apropriate collsion handler

Collision handling is done with 8 pair-wise handlers

Room bounding is done with invisible blocks

The room class was based on slides from class, and it has Update(),
Draw(), and GetObjects() method. The roomloader parses an xml file and returns an object of type room. Collision detection is 
implemented using the Rectangle intersect method. 

we've also added a space at the top of the game which will display menu information






