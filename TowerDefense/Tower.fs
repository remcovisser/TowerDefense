module Tower

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Entities


let getTileByMousePosition (position: Point) =
    let position' = 
        match GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width with
            (900, 1440) -> 
                let titleX = ((position.X * 2) / 50 |> int) * 50 + 10 |> float32
                let titleY = ((position.Y * 2) / 50 |> int) * 50 + 10 |> float32
                let positionRounded = new Vector2(titleX, titleY)
                positionRounded
            | _ ->
                let titleX = (position.X / 50 |> int) * 50 + 10 |> float32
                let titleY = (position.Y / 50 |> int) * 50 + 10 |> float32
                let positionRounded = new Vector2(titleX, titleY)
                positionRounded
    position'

let addRemoveTowers (towers: List<Tower>) = 
    let mouseState = Mouse.GetState()
    match mouseState.LeftButton, mouseState.RightButton with
        | ButtonState.Pressed, ButtonState.Released -> 
            let position = getTileByMousePosition mouseState.Position
            let newTower = {position = position; range = 3; damage = 10.f; attackSpeed = 1.f; price = 10;}
            let towers' = newTower :: towers
            towers'
        | ButtonState.Released, ButtonState.Pressed -> 
            let position = getTileByMousePosition mouseState.Position
            let towers' = towers |> List.filter(
                fun tower ->
                    tower.position.X <> position.X || tower.position.Y <> position.Y
            )
            towers'
        | _ -> towers

let shoot (towers: List<Tower>) (enemies: List<Enemy>) =
    towers |>
        List.iter(fun tower ->
            enemies |> List.iter(fun enemy ->
                match (enemy.position.X - tower.position.X) ** 2.f + (enemy.position.Y - tower.position.Y) ** 2.f <= ((tower.range |> float32) * 50.f) ** 2.f with
                | true ->
                    printfn "shoot!"
                    ()
                | false -> 
                    printfn ""
                    ()
            )
        )
    ()


let update dt (gamestate: GameState) =
    shoot gamestate.towers gamestate.enemies
    addRemoveTowers gamestate.towers
    
let draw (spritebatch: SpriteBatch) (texture: Texture2D) (tower: Tower) =
    spritebatch.Draw(texture, new Rectangle(tower.position.X |> int, tower.position.Y |> int, 32, 32), Color.Blue)
    ()