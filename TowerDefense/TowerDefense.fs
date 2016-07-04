module BaseGame

open System
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open GameState
open GameMap
open Entities

type TowerDefenseGame() as this =
    inherit Game()
    
    let graphics = new GraphicsDeviceManager(this)
    let mutable spritebatch = Unchecked.defaultof<SpriteBatch>
    let mutable state = Unchecked.defaultof<GameState>
    let mapsize = new Vector2(1300.f, 700.f)

    override this.Initialize() = 
        graphics.PreferredBackBufferHeight <- mapsize.Y |> int
        graphics.PreferredBackBufferWidth <- mapsize.X |> int
        graphics.ApplyChanges();
        this.IsMouseVisible <- true;
        do base.Initialize()


    override this.LoadContent() =
        do spritebatch <- new SpriteBatch(this.GraphicsDevice)
        let plainTexture = new Texture2D(this.GraphicsDevice, 1, 1)
        plainTexture.SetData([|Color.White|])
        let background = this.Content.Load<Texture2D> "Background.jpg"
        let tileBackground = this.Content.Load<Texture2D> "Tile.png"
        let map = GameMap.InitializeMap mapsize
        do state <- {
            texture = plainTexture
            background = background
            tileBackground = tileBackground
            map = map
        }
      
    override this.Update(gameTime) =
        let dt = gameTime.ElapsedGameTime.TotalSeconds |> float32
        do state <- GameState.update dt state 
       
  
    override this.Draw(gameTime) =
        do this.GraphicsDevice.Clear Color.Black
        spritebatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        GameState.draw spritebatch state
        spritebatch.End()