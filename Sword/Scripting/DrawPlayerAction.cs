using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Draws the player on the screen.
    /// </summary>
    public class DrawPlayerAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawPlayerAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Camera camera = scene.GetFirstActor<Camera>("camera");
                //Actor player = scene.GetFirstActor("player");
                List<Image> players = scene.GetAllActors<Image>("player");
                _videoService.Draw(players, camera);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw player.", exception);
            }
        }

    }
}