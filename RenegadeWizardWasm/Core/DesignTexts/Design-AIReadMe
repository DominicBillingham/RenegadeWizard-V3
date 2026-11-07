Below is the full context needed to understand the game.

This is an text-based immersive simulator. The player types an action, such as:
"I swing at the Glorb with my Axe"

The game first breaks down the sentence into [ACTIONS] and [TARGETS].
Swing = AttackAction
Targets = Glorb, Axe

Actions define the high level overview of what happens, while targets define who it happens to.
Actions will usually require a roll, that affects the outcome.
Actions use an ActionContext class, that provides all information needed to perform the action.

Depending on the roll, a series of effects will occur. These are centralised logic containers that then apply state to Entities.
For example, the AttackAction has a DamageEffect that applies damage to the target.
But if the executor rolls poorly, the AttackAction may apply stress to the executor instead.

This project makes heavy use of unit tests, to make it easier to test the game logic.