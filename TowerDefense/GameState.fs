module GameState

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Collections.Generic
open GameMap
open Tile
open Entities


let update dt state =
    let spawner' = Spawner.update dt state
    let enemies' = fst spawner' |> List.map(fun enemy -> Enemy.update dt enemy state)
    let towers' = Tower.buildTower state.towers
    {
        state with 
            enemies = enemies' |> List.map(fun enemy -> Enemy.update dt enemy state)
            spawner = snd spawner'
            towers = towers'
    }

let draw (spritebatch: SpriteBatch) (state: GameState) =
    spritebatch.Draw(state.background, Vector2.Zero, Color.White)
    GameMap.draw spritebatch state
    state.enemies |>
        List.iter(fun enemy -> Enemy.draw spritebatch state.texture enemy)
    state.towers |>
        List.iter(fun tower -> Tower.draw spritebatch state.texture tower)
