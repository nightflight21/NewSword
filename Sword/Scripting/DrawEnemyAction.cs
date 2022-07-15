using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Draws the enemy on the screen.
    /// </summary>
    public class DrawEnemyAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawEnemyAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Camera camera = scene.GetFirstActor<Camera>("camera");
                List<Actor> enemies = scene.GetAllActors("enemies");
                Console.WriteLine(enemies.Count);
                _videoService.Draw(enemies, camera);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw enemy.", exception);
            }
        }

    }
}