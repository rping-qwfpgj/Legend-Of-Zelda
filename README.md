#Sprint 3

Controls: WASD and arrow keys are used to move. V is used to shoot a projectile, number keys 1-6 are used to switch between link's projectiles. Clicking on the
right half of the room switches to the next room, and clicking on the left half of the room switches to the previous room. Keys Z and N are used to attack.



# Sprint2

Logic for Link: 
Link was the most challenging part of this Sprint to implement due to the amount of actions he must take. The team spent much of our time planning out his design, which 
led to us implementing the State Design Pattern for him. The Factory and command design patterns are also used, but these are used for other categories of game objects as
well. Link, as an object, has multiple instance variables storing current sprite, state, his current position, if he is damaged, etc. Whenever a command related to Link 
is called, it will call a corressponding function in Link.cs is called(for example, AttackCommand calls Link's Attack() function). Within these functions, Link's 
currentState has an appropriate function called(i.e. Link's Attack function will call currentState.Attacl()). Once the state class is entered, a few things may happen.
The first one is that nothing may happen. This will occur if the player tries to have Link do an action that is not allowed in the current state he is in(for example, 
if Link is already attacking, he cannot attack in the middle of it). OTherwise, the state class will change Link's state class and call the SpriteFactory to draw
an appropriate sprite. For the TakeDamage functions of the state classes, these will just set Link's isDamaged field to true or false.

There are some extra parts of Link not covered by this simple description. The main one is that we created an enum, Throwables, in his class to easily track what 
projectile weapons he has equipped.

Logic for Controls:
There is a KeyboardController class which holds a list of Keys binded to Command classes. The controller's update function will
loop through this list of Keys and execute the command if a key is pressed. We did take action to make it so a command will not
be repeatedly executed if a key is held down for more than a moment.

Logic for Enemies/NPC:
Similar to Link, enemies/NPCs have a SpriteFactory. The main class for Enemies, Enemey, has a list of insubstantiated instance of all
enemy sprite classes. It then has an int variable that represents which index of this list it should go to to Draw/Update a sprite.
The Dragon boss proved to be slightly challenging to implenet due to the need to make its attacking orbs constantly moving and changing,
which was accomplished by giving it its own list to swap between which version of the attack orbs to draw. However, the largest hurdle
regarding enemies was the Goriya, due to the need to implement its boomerang throw. This resulted in a sprite class that is quite long,
and will likely be refactored in the future to be shorter.







