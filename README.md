# ACM GameJam F21 Project

## Theme: Pausing has Consequences
A sidescrolling platformer where pausing (in multiple different ways) makes your life miserable.
* Staying still for too long causes death (pausing motion)
* In one room, pausing the game will cause the enemies to speed up significantly
* In another room, pausing the game will randomize the location of the platforms

## Implementation
* Library for sidescrolling, animation, and player control
* Custom-built interface for pause consequences (`IConsequence`)
* Modified PlayerController and EnemyController to handle consequences
* Tile-painted map 
