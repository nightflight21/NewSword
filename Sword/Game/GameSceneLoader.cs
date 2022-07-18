using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Sword.Scenes.Shared;
using Sword;


namespace Sword.Scenes.Game
{
    /// <summary>
    /// Loads the actors and actions required for the game scene.
    /// </summary>
    public class GameSceneLoader : SceneLoader
    {
        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) { }

        public override void Load(Scene scene)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            float durationInSeconds = 0.3f; 
            int framesPerSecond = 60; 

            string[] filePaths = new string[6];
            filePaths[0] = "Assets/sprites/characters/tile000.png";
            filePaths[1] = "Assets/sprites/characters/tile001.png";
            filePaths[2] = "Assets/sprites/characters/tile002.png";
            filePaths[3] = "Assets/sprites/characters/tile003.png";
            filePaths[4] = "Assets/sprites/characters/tile004.png";
            filePaths[5] = "Assets/sprites/characters/tile005.png";

            // Instantiate the actors that are used in this example.
            //Image playerimage = new Image();
            Image player = new Image();
            player.SizeTo(50, 50);
            player.MoveTo(1280, 960);
            //player.Tint(Color.Green());
            player.SetHealth(5);
            player.Animate(filePaths, durationInSeconds, framesPerSecond);

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(2560, 1920);
            world.MoveTo(0, 0);

            Camera camera = new Camera(player, screen, world);

            // Instantiate the actions that use the actors.
            //DrawImageAction drawImageAction = new DrawImageAction(serviceFactory);
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            PlayerAttackAction playerAttackAction = new PlayerAttackAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            SpawnEnemyAction spawnEnemyAction = new SpawnEnemyAction(serviceFactory);
            CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            RemoveEnemyAction removeEnemyAction = new RemoveEnemyAction();
            GameOverAction gameOverAction = new GameOverAction(serviceFactory);
            MoveEnemyAction moveEnemyAction = new MoveEnemyAction();
            ChaseEnemyAction chaseEnemyAction = new ChaseEnemyAction();

            // Clear the given scene, add the actors and actions.
            scene.Clear();
            scene.AddActor("player", player);
            scene.AddActor("camera", camera);
            
            scene.AddAction(Phase.Input, steerPlayerAction);
            scene.AddAction(Phase.Input, playerAttackAction);
            scene.AddAction(Phase.Update, spawnEnemyAction);
            scene.AddAction(Phase.Update, movePlayerAction);
            scene.AddAction(Phase.Update, removeEnemyAction);
            scene.AddAction(Phase.Update, gameOverAction);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Update, collideActorsAction);
            scene.AddAction(Phase.Update, moveEnemyAction);
            scene.AddAction(Phase.Update, chaseEnemyAction);
            //scene.AddAction(Phase.Output, drawImageAction);
        }
    }
}

