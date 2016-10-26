I created a semi functional prototype of the game. Right now the player can roam around the game.
 
- On each house, there is a trigger. When the player collides with the trigger, it changes the level(scene) to a simple dialoge view. We can add conversation between the player and stranger at the door. These conversation can be education a topic that the player is going to learn from. 

- When the conversation is over, the level is changed to questions/answer scene.

- QA_scene has multiple questions each having four possible answers.

- As of right now, I can't get the answers to lock, so the player can't change the answer they picked.

- Once the player have answered all questions, the levels changes back to the game level.


Here is what an ideal implementation should be or what we want to get close to:

- The 'QuestionController' script takes another script that has questions/answers in it.

- We can then take the 'QuestionController' and assign it all the door triggers. This makes the whole process modular by allowing us to plug in different questions/answers scripts depending on the difficulity level.
----------------------------------------------------------------------

** Ideas / Suggestion for the game **
-------------------------------------
I think it would work better if we allow our player to freely roam the game world.
This will allow us to add other gameplay elements as well.
The enemy(serial killer) can work with the number of questions player got right. If the player fail to answer three questions correctly. The enemy will kill the player. Rather than the enemy constantly running after the player and our player having to constantly run, I think this method would be easier to implement and give us (the players) to visually enjoy the game.

We can have cars driving on the roads. If the player collides with a car, they are dead. (Think of it like the frogger/crossy road games)

The end goal of the game would be to get to the police station. This afcourse would be open to the player but the player must have visited certain amout to homes. I think we can have each house give our player a clue at the end of the quiz. For example, the homeowner would say to the player that the serial killer wears a purple scarf. Another one might tell the player where the killer hangsout. All of these clues can help the police catch the killer.
