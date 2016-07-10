module Tower

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Entities


let update dt  (tower: Tower) (gamestate: GameState) =
    gamestate
  
let draw (spritebatch: SpriteBatch) (texture: Texture2D) (tower: Tower) =
    spritebatch.Draw(texture, new Rectangle(tower.position.X |> int, tower.position.Y |> int, 32, 32), Color.Blue)
    ()

let getTileByMousePosition (position: Point) =
    let titleX = (position.X / 50 |> int) * 50 + 10 |> float32
    let titleY = (position.Y / 50 |> int) * 50 + 10 |> float32
    let position' = new Vector2(titleX, titleY)
    position'

let buildTower (towers: List<Tower>) = 
    let mouseState = Mouse.GetState()
    match mouseState.LeftButton with
        | ButtonState.Pressed -> 
            let position = getTileByMousePosition mouseState.Position
            let newTower = {position = position; range = 10.f; damage = 10.f; attackSpeed = 1.f; price = 10;}
            let towers' = newTower :: towers
            towers'
        | _ -> towers