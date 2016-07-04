module GameMap

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Collections.Generic
open Tile
open Entities

let InitializeMap (size: Vector2) = 
    let map = new Dictionary<int, Dictionary<int, Tile>>()
    let width = (size.X / 25.f) |> int
    let height = (size.Y / 25.f) |> int
    let tileSize = 50
    for i in 0 .. width do
        let tile = new  Dictionary<int, Tile>()
        let x = i|>int
        map.Add(x, tile)
        for o in 0 .. height do
            let y = o|>int
            let tile = {position = new Vector2(((i * tileSize) |> float32), ((o * tileSize) |> float32))}
            map.[x].Add(y, tile)
    map 

let update dt state =
    state

   
let draw (spritebatch: SpriteBatch) (state: GameState) =
    for KeyValue(key, value) in state.map do
        for  KeyValue(key, value) in value do
            Tile.draw spritebatch (value) state