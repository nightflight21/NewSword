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
            
            // Instantiate the actors that are used in this example.
            Actor player = new Actor();
            player.SizeTo(50, 50);
            player.MoveTo(1280, 960);
            player.Tint(Color.Blue());
            player.SetHealth(5);

            Actor screen = new Actor();
            screen.SizeTo(640, 480);
            screen.MoveTo(0, 0);

            Actor world = new Actor();
            world.SizeTo(2560, 1920);
            world.MoveTo(0, 0);

            Camera camera = new Camera(player, screen, world);

            // Instantiate the actions that use the actors.
            SteerPlayerAction steerPlayerAction = new SteerPlayerAction(serviceFactory);
            PlayerAttackAction playerAttackAction = new PlayerAttackAction(serviceFactory);
            MovePlayerAction movePlayerAction = new MovePlayerAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);
            SpawnEnemyAction spawnEnemyAction = new SpawnEnemyAction(serviceFactory);
            CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            RemoveEnemyAction removeEnemyAction = new RemoveEnemyAction();
            GameOverAction gameOverAction = new GameOverAction();
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
        }
    }
}

