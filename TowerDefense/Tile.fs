module Tile

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Entities

let update dt state =
   state
   
let draw (spritebatch: SpriteBatch) (tile: Tile) (state: GameState)=
    spritebatch.Draw(state.tileBackground, tile.position, Color.White)