module Spawner

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Entities


let update dt (gamestate: GameState) =
    match (gamestate.spawner.enemy1Cooldown >= gamestate.spawner.enemy1SpawnRate) with
        | true ->  
            (gamestate.enemies @ [{position = new Vector2(0.f, 60.f); health = 100; speed = 50.f; points = 1}], 
            {enemy1SpawnRate = gamestate.spawner.enemy1SpawnRate; enemy1Cooldown = 0.f})
        | false -> 
            (gamestate.enemies, 
            {enemy1SpawnRate = gamestate.spawner.enemy1SpawnRate; enemy1Cooldown = gamestate.spawner.enemy1Cooldown + (1.0f*dt)})

let draw (spritebatch: SpriteBatch) (state: GameState) =
    ()