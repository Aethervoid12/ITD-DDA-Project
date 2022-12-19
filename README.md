# ITD-DDA-Project
## Introduction
Our project, CarnivalVR, is aimed to simulate 100% of what the player will experience as the real world carnival.

In CarnivalVR, player can explore and enjoy various types of its features and interactions, such as the carnival envrionment, plus mini games which require
players to react fast or equipped with some luck to achieve high score.

The entire experience is short and sweet (takes about less than 20 minutes to finish), so the player won't have to worry to much about motion sickness for
wearing the VR headset for too long.

## ITD Deliverables
### List of CarnivalVR Features and its Interactions
#### Boxy Ninja Slasher Game
The game simulates the traditional Fruit Ninja Slasher Game. Player are required to slash as many blocks as they can within 60 seconds to earn points.

*FYI: Here are all the possible slicable projectiles you will encountered during the game*

RGB Block: These are normal colored blocks, and they will give 1 point each upon slicing 

Frost Pill: It slows down the projectile falling speed for 8 seconds

Powerup Pill: It doubles the points of every projectiles

Black Sphere: A hazardous projectile that will deduct 2 points upon slicing

#### Tin Can Destruction
This game resembles the typical game you will find in the Carnival. The rule is simple, knock down as much tin cans as you can by throwing the baseball
onto the pile of tin cans to earn points.

The player got 3 shots for every round, and each knocked down tin can will give 5 points.

If the player managed to knock down 16 out of 18 cans within three shots, they may be proceed to the next round with the same set of rules.

The game loops every round until the player fails to knock down 16 out of 18 cans within three shots, then the gameover message will be popped up.

### Key Controls
#### Player Controls
Moving around: 

Teleporting:

#### Interacting with objects
Grabbing objects:

Throwing objects:


### Platform(s) required to run the application

### Limitations / Bugs in the application
#### Boxy Ninja Slasher Game
The trajectory of the mesh prefabs cutting is not completely correct.
(If I cut the cube vertically, it would split apart differently not exactly a vertical slice.)

There is only 1 gaming option in this project.
(Fruit Ninja has different options (Classic, Arcade, Zen)



## DDA Deliverables
### Application Flow
Upon loading the application, the player will be greeted will the tutorial level.

From there, the use will need to sign up / log into the game using their email and password. These information will be stored in the database for 
authentication and CRUD purposes.

Upon completing the tutorial level, the use will be brought the main game. Which the database will keep track of the player's time spent, the score
for each mini game, and etc... The information will be recorded and presented in the form of player profile, in game leaderboard and dashboard.

## Credits / References

Model of the carnival stall: https://sketchfab.com/3d-models/side-stalls-fa330c8f231d42ef933e420eb08fe8c8

Model of the baseball: https://sketchfab.com/3d-models/worn-baseball-ball-fdf3de6ae225421ea78961b897b9608a

Model of the tin can: https://sketchfab.com/3d-models/tin-can-640b0c8287274629a7f4ff3ce74a5999

Model of the instruction / leader board: https://sketchfab.com/3d-models/game-leaderboard-e523e6e113c54452956b9407c074ae3f





