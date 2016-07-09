module Enemy

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Entities


let update dt  (enemy: Enemy) (gamestate: GameState) =
    let position =
        match enemy.position.X, enemy.position.Y with
            | (x , y) when (x <= 560.f) && (y <= 60.f) -> new Vector2(x + enemy.speed * dt, y)
            | (x , y) when (x >= 100.f) && (x < 1015.f) && (y <= 460.f) -> new Vector2(x, y + enemy.speed * dt)
            | (x , y) when (x >= 560.f) && (x < 1015.f) && (y >= 460.f) ->  new Vector2(x + enemy.speed * dt, y)
            | (x , y) when (x >= 1015.f) && (y > 230.f) -> new Vector2(x, y - enemy.speed * dt)
            | (x , y) when (x >= 1015.f) && (y <= 230.f) -> new Vector2(x + enemy.speed * dt, y)
    {
        enemy with 
            position = position
    }

let draw (spritebatch: SpriteBatch) (texture: Texture2D) (enemy: Enemy) =
    spritebatch.Draw(texture, new Rectangle(enemy.position.X |> int, enemy.position.Y |> int, 16, 16), Color.Red)
    ()