# Recipies-Master
a 3D game do demonstrate the basics and advanced topics about unity like games networking (multiplayer)

- Setup URP with some configs volume effects .
- Add player controller with separation from visual game object . 
- Add our player visual 3d model with dynamic rotation .
- Add idle and walk animations .
- Using ready to use animator Controller .
- Setup Cinemachine to be above the main camera to ad noise .
- Setup medern input system package parallel with the legacy one to do game prototying and production level development .
- Make the player collide with other collider objects and how to make the player avoid the collider when the game attempt to move diagonally by make him move horizontally or vertically only .
- How to interact with specific game objects using layers not tags and how to deal with each of them separately .
- How to use events and listeners with delegates to avoid checking something if it happened or not yet within each frame .
- What is singletone design pattern .
- How to add the visual selected clear counter effect.
- How to be friendly with designers by collecting all assets into collections to organise the assets and be able to update when there are updates by the designers
- How to spown scriptable objects (Kitchen Objects) and identify them separately when they have been loaded in the scene .
- How to move the kitchen object from counter to another and make insure that there is no more than kitchen object on the counter.
- How to use interface to make reference for counters with player and make them both share the same functionalities logic and prepared for different implementations for each of them.
- How to make Prefab Variant from Prefab as a Base Prefab to create multiple prefabs from it (as a template) then we made Container Counter and make it and the cleare counter extends from the BaseCounter
- How to implement Interact with Clear Counters and Container Counters.
- How to make Prefab Variants (ContainerCounter_<KitchenObject>) from other Prefab Variant (Container Counter) 
- How to InteractAlternate to cut tomato (just for now) in cutting counter 
- How to InteractAlternate to the rest of cutable vegetable like cheese and cabbage
- How to add cut animation to CuttingRecipeInput with UI feedback (Bar)
- How to make the progress bar face the camera in many ways.
- How to make a Trash Counter to destroy the KitchenObject which is hand held by the player.
- How to make a Stove Counter to cook cookable ingredients using State machine (Swith case statement)
