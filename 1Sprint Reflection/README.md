#Sprint 4

CONTROLS: 
-WASD and arrow keys are used to move, NOTE: When in the inventory, WASD and arrow keys are instead used to move the cursor around the inventory
-V is used to shoot a projectile, number keys 1-6 are used to switch between Link's projectiles.
When pulling up the inventory, hovering the selector cursor over one of the projectiles and then exiting the inventory will equip it to link, 
in addition to being able to use the numerical keys to swap the current projectile.
-Clicking on the right half of the room switches to the next room, and clicking on the left half of the room switches to the previous room.
-Keys Z and N are used to attack with the sword.
-H is to pause/unpause
-L is to open the inventory/close the inventory


BUGS:
Room 17 transition still need work.
Transitioning from room 10 to 6 also has some issues with moving over a pure green section for a moment


PERTINENT information about our implementation:
The main things that were added in this sprint was sound, game states, link/enemy health, proper trap/wallmaster behavior, room transitions, the heads-up display/inventory, and enemy projectile collisions

Collision detector uses exhaustive checking to compare every object in room with every other object in room, once a collision is detected,
the two objects are passed to the collision delegator.

The delegator utilizes the ISprite sub-interfaces to identify each generic room object and then select the apropriate collsion handler

Collision handling is done with 8 pair-wise handlers

Room bounding is done with invisible blocks

The room class was based on slides from class, and it has Update(),
Draw(), and GetObjects() method. The roomloader parses an xml file and returns an object of type room. Collision detection is 
implemented using the Rectangle intersect method. 

we've also added a space at the top of the game which will display menu information



Reset has not been implemented yet(link will reset to the first room, but items and enemies do no respawn yet)

Intentional omissions:

sliding doors are replaced with locked doors
The room which contains a pushable block to access the old man room has been modified to accomodated for this. The dragon room 
has also been changed to have a key. 

Items that are only displayed once a room has been cleared are now  displayed in the room pre-clear state.

Clock Item is not in the game

small red and blue hearts: replaced funcionality with big read hearts


