module GameState

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Collections.Generic
open GameMap
open Tile
open Entities


let update dt state =
   state

let draw (spritebatch: SpriteBatch) (state: GameState) =
    spritebatch.Draw(state.background, Vector2.Zero, Color.White)
    GameMap.draw spritebatch state
    ()