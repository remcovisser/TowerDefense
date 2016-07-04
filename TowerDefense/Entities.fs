module Entities

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Collections.Generic


type Tile = {
    position: Vector2
}


type GameState = {
    texture: Texture2D
    background: Texture2D
    tileBackground: Texture2D
    map: Dictionary<int, Dictionary<int, Tile>>
}