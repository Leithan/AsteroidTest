# Asteroids Clone Test
small project to showcase project structure and code practices

Using Unity 2021.1.20f1

StartScene is the one to open first to play the game. Youre a small ship, using directional keys to go forward or rotate to the sides, you cant go back! Press space to fire. Asteroids and enemy ships will spawn periodically. Save your high score!

# Architecture

I used a new approach for me, an architecture based on factories creating objects from a ModelView and a Controller. The Controller is where the logic resides, and the ModelView is where the Unity GameObject plus the data is. So you can use the prefabs to setup how an object looks and what variables you can change. The factories are based on GenericFactory, which uses generics to have less boilerplate code and show what IModelView and what BaseController the factory will make objects from.
I also have Providers that act as service locators and instantiators for the various factories and resources from scriptable objects.
There are 2 scriptable objects to get info from, ResourcesSO and GameSettingsSO. ResourcesSO has a list of all the prefabs and an enum that indexes them. You can have multiple prefabs share enums, which means the factories could use some logic to get different enemy ships, for example.
GameLogic is the main game logic code. Basically uses a lightweight singleton so it can be located by any class that needs access to its resources. Better ways to accomplish this exist, either by a DI framework or even a service locator, but game entry points are usually a single instance thru the game, so there was not much to gain in terms of time limits.
I think the code is pretty self-explanatory, GameLogic spawns the player ship, asteroids and enemies. Ships spawn bullets. All share a BaseMovableBehaviour (all are IMoveable classes) so when big objects are destroyed,an explosion spawns. Player controls are baked into the PlayerModelView, which is a part that should be improved by having InputControllers decoupled.
