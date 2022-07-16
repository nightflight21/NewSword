using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to scroll a world while the player moves.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
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

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
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

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
