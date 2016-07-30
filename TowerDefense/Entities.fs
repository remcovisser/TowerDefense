module Entities

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Collections


type Tile = {
    position: Vector2
}

type Enemy = {
    position: Vector2
    health: int
    speed: float32
    points: int
}

type Tower = {
    position: Vector2
    range: int
    damage: float32
    attackSpeed: float32
    price: int
}

type Spawner = {
    enemy1SpawnRate: float32
    enemy1Cooldown: float32
}

type GameState = {
    texture: Texture2D
    background: Texture2D
    tileBackground: Texture2D
    map: System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<int, Tile>>
    enemies: List<Enemy>
    spawner: Spawner
    towers: List<Tower>
}