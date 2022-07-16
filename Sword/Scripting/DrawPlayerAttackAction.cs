using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Draws the PlayerAttack on the screen.
    /// </summary>
    public class DrawPlayerAttackAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawPlayerAttackAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Camera camera = scene.GetFirstActor<Camera>("camera");
                List<Actor> sword = scene.GetAllActors("sword");
                Console.WriteLine(sword.Count);
                _videoService.Draw(sword);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw PlayerAttack.", exception);
            }
        }

    }
}