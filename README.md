# Astro Party II

## Brief Summary:
This is a recreation of the game Astro Party.

### Game Link:
https://yuxiang-huang.itch.io/astro-party-ii

### Development Log: (MM-DD-YYYY: "LOG")
* #### Yuxiang Huang:
    *  (08-26-2022): Today I began the project by making a simple rectangular map and controls for the player ship, including rotatation and shooting.
    *  (08-27-2022): Today I started by adding the ammo restraint for the ships. Each ship has at most three ammos and reload one every two seconds. In addition, I added the animation for how many ammo each ship has. After that, I changed the camera to orthographic and resize everything. Then I added laser beam to the game, including the first sound effect of the game. Next, I worked on the UI by having three chained screens. Lastly, I struggled with a bot and finally got it to work in the end of the day. Throughout the day, I also fixed a variety of issues I discovered while testing the game."
    *  (08-28-2022): "Today I made the minimum viable product for the ship screen. The player is able to choose at most four ships, making them player or bot. Then, I fixed their spawning positions and make bot attack the closest ship.
    *  (08-29-2022): Today I started by creating an end screen, which includes a rematch button and a back to ship screen button. Then, as I was going to write the code for displaying the winning message, I realized that it would be better to implement the team system first. Thus, I spent the rest of the morning working on the team system and resolving various issues that come with it. Later in the day, I spent an hour giving players the option to choose their prefered controls. Lastly, I fixed an issue by making the team button only appearing when player is on and optimize the text for the team numbers.
    *  (08-30-2022): Today I spent almost all my time working on the score board and finally got it to work.
    *  (08-31-2022): Today I started with displaying the winning message for the team mode. Then I added the solo mode where each player win points by killing other ships instead of being the last one alive. Also, I added features like team ships move together in the score board and better pictures. In addition, I fix issues in the score board and rematch button.
    *  (09-01-2022): Today I started by making an option for friendly fire in team mode. Then, I started the pilot hunting mode by making a controllable pilot. In addition, I perfect the scoreboard, AI moving, and capped the velocity of ships and pilots in the game.
    *  (09-02-2022): Today I spent a lot of time and finish almost everything except the maps and powerups. I perfected the score system after adding the pilot and did the UI for the pilot vs ship mode. Then I wrote a universal script for the bot and the ship that includes everything they share, so when I add the powerup system I don't need to write the code twice for each powerup. I also spent a lot of time perfecting the AI and the score board. I realize I shouldn't update the AI agent destination every frame and maintained the function for the score board after scaling. Lastly, I play tested the game and fixed issues that I find.
    *  (09-03-2022): Today I started by making an option for fixed spawn position. Then, I worked on the map system and set the foundation for adding more maps easily. There are two maps as for now and I can turn them on and off. Lastly, I added the laser indicator, which can be attracted by other ships and allow them to shoot laser beam once.
    *  (09-04-2022): Today I started by adding more sound effects to the game. Then, I worked on UI for the info screen and the power up screen. For power ups, I am able to spawn one in the middle of the map every round and make ships drop it when they have it but didn't use it yet. Lastly, I added the starting power up option for each ship. 
    *  (09-05-2022): Today I started by adding the double tap dash control for the player ships. Then I added a Sound Effect Manager that handles all the sound effects and added the sound effect for the ship, pilot and the preparation stage. Lastly, I spent a lot of time working on the asteroid system that contains four kinds of asteroids. I encapsulating the power up indicator in the asteroid and finish the spawning mechanics.
    *  (09-06-2022): Today I started by perfecting the asteroid system. One feature I added is that the larger asteroid will break up into smaller ones after destroyed. I also added an option for the player to choose the number of asteroids and the movement of the asteroid. Then, I remake the ships in order to change the collider and add the jouster and side cannon for tomorrow. Lastly, I am half way done with scatter shot.
    *  (09-07-2022): Today I spent all my time working on the power ups. I finished the scatter shot, and also the triple shot and the freezer. I display them on the info screen as well as giving the players the option to include them in the game or not and use them as starting power up. As usual, I fixed bugs I find throughout the day.
    
    *  (09-10-2022): Today I started by fixing the bugs I found when I play tested the game with my friends. Then I realized that I can apply material with code and merged all the ship prefabs into a player ship and a bot ship. With that, I started to add a fifth ship to the game and worked extensively with the scripts.
    *  (09-11-2022): Today I started by also mergeing the pilots like the ships. Then I worked on the display by changing the font. Lastly, I resized the map to be five times larger and adding the camera shrinking and expanding feature depending on where the ships are.
    
    *  (09-15-2022): Today I reworked the damage system in such a way that the powerUps can just call the function in mutualShip script and really reduce the code in the powerUp scripts. Then, using this new damage system, I added a new powerUp shield to the game.
    *  (09-16-2022): Today I play tested with my friends and fixed issues we encountered, including the long existing problem of mutltiple bullet hitting one enemy causing mutiple effects, the y value of powerUp indicators, and the power drop system. Then, I added the triple powerUp option and reworked the freezing algorithm to allow freezing time to stack. Lastly, I added esc as the pause button.
    *  (09-17-2022): Today I added two more options for the player: auto balance and bullet cancel. I also spent a lot of time working on the random starting power up option for both all players and individuals, as well as how they interact when both are on. Then, I added the triple power up option and adjusted the freeze algorithm for it to stack. Lastly, I adjusted the collider of the ships to prevent it from stucking on walls.
    *  (09-18-2022): Today I started by making a third map and finally realize the problem of making maps with five players. Then, I spent all my time transforming the rectangular map into a circular one and adjusted everyhting related to the map, including spawn position and rotation, spawning of asteroids and power up, border... Also, I published the game in itch.io today.
    
    *  (09-20-2022): Today I recloned the repository because the file changes left last time after build the game for publishing was too big to be commited. I fixed the camera resizing to correspond to the aspect ratio of the itch.io game screen. Lastly, I figured out that branching will allow to build the game without causing issues about commiting, and I cleaned all the folders I cloned for testing.
    *  (09-21-2022): Today I made a new map with rotating objects and made a new bot type.
    *  (09-22-2022): Today I made a map3, which is inspired by the three body problem. After adding it to the game, I decided to have two types of bot in the game and reworked the ship screen. Lastly, I checked and fixed issues of the bots.
    
    *  (09-24-2022): Today I made another powerUp called the proximity mine. Also, I worked on the effect of suicide on the score system.
    
    *  (09-26-2022): Today I reworked the Starting Power Up system so I can duplicate a screen easily for each player. Also, I started to make my own background pictures.
    *  (09-27-2022): Today I added map 4 to the game, which will spawn deadly laser beams of a pentagon randomly.
    
    *  (09-30-2022): Today I play tested the games with my friends and fixed issues along the way.
    
    *  (10-03-2022): Today I started by making breakable and unbreakable wall prefabs. Then, I used them to create map 5, which will spawn them in random orders but in same positions, and added map 5 to the map system.
    *  (10-04-2022): Today I made a new power up called bouncy bullet, which is bullet except that it bouncies when collide with a wall. As usual, I fixed issues I encounter along the way. 
    *  (10-05-2022): Today I made what might be the last power up I made for a long time. It is called jouster, which is destroy everything on contact with it. I fixed issues in the point system and the bullet today.
    
    *  (10-07-2022): Today I playtested the game with members in Stuy Game Devs and fixed issues along the way. Also, I removed the components in GameManager that deals with ship controls and merged it with the TextManager to form the ControlManager script that handles the ship screen.
        
    *  (10-09-2022): Today I started by finishing the ship screen. Then I worked on the Tutorial. I finished the prep screeen and laid the foundation for adding more directions.
    
     *  (10-11-2022): Today is probably going to be the last time I spent so much time on it for a long time. I started by fixing the minor issues I found when playtesting with my friends in CS Dojo. Then I buff bouncy bullet and nerf type two bot. After that, I finished the tutorial by adding some more directions. Lastly I fixed a major bug in bot tracing system and added another option called suicial bullet that determines if one's ship will be killed by its own bullet.
     *  (10-12-2022): Today I spent all my spare time on making a portal for the last map I am going to make for a long time. 
     *  (10-13-2022): Today I finished the last map I am going to make for a long time. 
     *  (10-14-2022): Today I switched all the background pictures to my own and playtested with members in Stuy Game Devs.
     
     *  (10-29-2022): Today I started with fixing the issues I found when play testing with my friends few days ago. I fixed the resetting of map 6, added more directions and ordered them in tutorial, and added pause text. Lastly, I remade map2 to be a more chaotic system with rotating blocks using rigidbody instead of translate.
     *  (10-30-2022): Today I added the translation of the scoreboard when the player point exceed the point required to win. Then, I added the tie breaker system and use functions to reduce code in ScoreManager. Lastly, I play tested and fix issues I found; mainly the AI tracing issue.

     *  (11-3-2022): Today I started by fixing issues I found after play tested with my firends. Then, I create a new mode call highlight where pilots don't get killed and players fight to keep the crown.
     
     *  (11-5-2022): Today I started perfecting the highlight mode by fixing the issues I encountered when play tested with my friends. I also replaced the crown object with a better online model and give indicator on the ship when it is highlighted. Lastly, I added different time options to the mode and ordered the time texts.
     *  (11-5-2022): Today I did a whole page of commits. I started by remaking the old map 2 and reorganizing the map screen. Then I made all change buttons for map screen and power up screen. Along the way, I optimised the mapManager and powerUpManager and also laied the foundation for the all starting powerup screen. I perfected the asteroid spawning system and gives a number option for the number of times a player can use a powerUp. Next, I made another map with fogs and as I was making the fixed/unfixed spawn option for this map, I decided to rework the entire system. Now all maps has a fixed spawn and unfixed spawn state and player can choose to include one, both, or neither of them in the map screen. 
