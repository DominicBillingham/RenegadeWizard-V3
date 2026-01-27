### Howdy!
You're taking a look at my .NET Blazor WASM text-based immersive-sim video game. It uses the full power of OOP for maximum flexibility, with modern UX for text input. That's a lot of words, here's an example:

It's mostly a combat simulator, where every action can have a truly cascading set of results depending on the <action> [adjectives] and {entities}

> I <kick> the [immortal] {goblin} out of the [fallHazard] window -> The goblin should fall to his death, rather than just taking damage

> I <throw> the [burning] {goblin} at the [huge] {giant} -> The goblin should set you on fire, and the giant, becuase both touch the burning goblin.

> I <eat> the [huge] [immortal] {goose} -> Normally eating a goose would instantly kill it (and heal you!), but the huge modifier prevent this!

### BUT HOW ?!?!?
In order to solve the problem, I first had to break it down very carefully. At the core, an <action> is actually a series of smaller "effects"
The <kick> action is actually a ForceMoveEffect, DamageEffect, and then a CollisionEffect if it hits another entity.
This allows me to combine together effects, for example, a <shoot> action could use a new ProjectileEffect and a Damage Effect.

With effects established, now it was time for the [adjectives]. Adjectives directly affect what happens inside an effect.
In the code, they are simply tags on an {entity}. When an <action> is taken, each effect looks at the tags on the affected entity.
The tags themselves have no logic, but their prescence directs the logic flow of an effect.

If a creautre has the [Tenacious] tag, then DamageEffects cant reduce a creature below 0 hitpoints. Likewise, the [Immortal] simply makes them fully immune to damage.
This does mean effects become a stack of IF Statements, but I decided having the logic centralised was far better due to the operation order of [adjectives] mattering so much.

### Modern UX
In order to make a text-based game in the 21st centuary, some UX considerations were needed.
1. Users must be able to enter their actions using natural language. 
2. It must allow for minor spelling mistakes
3. Typing shouldn't be a chore

To resolve these UX considerations, I did the following:
1. Using loose template fitting, it finds the actions, entities and adjectives in a sentence.
2. Using Levinstien Distance (Spelling mistake is totally intended), names can have a slight mistmatch and still work
3. Inspired by actual terminals, features such as autocomplete make entering commands quick and easy.

### Fun stuff
Text is a bit boring, nowadays people want animations, sparks, flashing lights. So that's why the terminal uses a mix of fonts, CSS animations, and pretty gradients to give a more "dynamic" and "alive" feel to the experience.
To accomplish this, I created MINI MARKUP LANGUAGE. The idea's probably been done 1000x time but I had fun making my own shorthand string to HTML converter.
A sentence like this can suddenly have #blu blue text with just these pair of hastags # before going back to normal!
(Pretend it's blue, this is a readme)
I expanded this MML to handle replacing words with a variety of synonyms, a commentator on the players actions, and text animiations.
I'm working on adding sound effects, and more UX JUICE to make it feel just right.

### Why Blazor WASM
I wanted to use C# for the project but wanted a fully client based solution. This ideally should be a react application that can then be turned into a static, but I wanted to refine my C# skills some more.
