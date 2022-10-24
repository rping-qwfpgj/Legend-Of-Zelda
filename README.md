#Sprint 3

Controls: 
WASD and arrow keys are used to move. V is used to shoot a projectile, number keys 1-6 are used to switch between Link's projectiles.
Clicking on the right half of the room switches to the next room, and clicking on the left half of the room switches to the previous room.
Keys Z and N are used to attack. 

Bugs:
N/A

Pertinent information about our implementation:
The main things that were added in this sprint was room loading, the room class, collisions. 
A GetHitbox() method was added to all the sprites for the collision purposes, as well as making new interfaces that inherit ISprite
to determine the type of object that has collided. The room class was based on slides from class, and it has Update(),
Draw(), and GetObjects() method. The roomloader parses an xml file and returns an object of type room. Collision detection is 
implemented using the Rectangle intersect method. Collision handling has 18 different cases for every kind of collision
that can happen (block block, link block, link enemy, enemy block, etc.)






