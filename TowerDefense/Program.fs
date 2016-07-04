open BaseGame

[<EntryPoint>]
let main argv =     
    use towerdefense = new TowerDefenseGame()
    towerdefense.Run()

    0 // return an integer exit code