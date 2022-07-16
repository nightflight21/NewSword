using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword.Scenes.Game
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorsAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;
        private DrawPlayerAction _drawPlayerAction;
        private DrawEnemyAction _drawEnemyAction;
        private DrawPlayerAttackAction _drawPlayerAttackAction;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
            _drawPlayerAction = new DrawPlayerAction(serviceFactory);
            _drawEnemyAction = new DrawEnemyAction(serviceFactory);
            _drawPlayerAttackAction = new DrawPlayerAttackAction(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // Get the actors from the cast.
                Camera camera = scene.GetFirstActor<Camera>("camera");
                
                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.
                _videoService.ClearBuffer();
                _videoService.DrawGrid(160, Color.Gray(), camera);
                _drawEnemyAction.Execute(scene, deltaTime, callback);
                _drawPlayerAction.Execute(scene, deltaTime, callback);
                _drawPlayerAttackAction.Execute(scene, deltaTime, callback);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}