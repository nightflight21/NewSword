using System;
using System.Numerics;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Steers the player left, right, up or down based on keyboard input.
    /// </summary>
    public class PlayerAttackAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private Actor _sword = new Actor();
        
        public PlayerAttackAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // declare basic speed and direction variables
                int SwordSide = 30;
                int directionX = 0;
                int directionY = 0;

                // detect vertical or y-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.I))
                {
                    directionY = -SwordSide;
                    AddSword(scene,50, 30,directionX,directionY);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.K))
                {
                    directionY = SwordSide;
                    AddSword(scene,50, 30,directionX,directionY);
                }

                // detect horizontal or x-axis direction
                else if (_keyboardService.IsKeyDown(KeyboardKey.J))
                {
                    directionX = -SwordSide;
                    AddSword(scene,30, 50,directionX,directionY);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.L))
                {
                    directionX = SwordSide;
                    AddSword(scene,30, 50,directionX,directionY);
                }
                else if(scene.GetAllActors("sword").Count >= 1){
                    //scene.RemoveActor("sword", _sword);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer attack.", exception);
            }
        }

        private void AddSword(Scene scene,int width, int height,int X,int Y){
            if(scene.GetAllActors("sword").Count<1){
                Actor camera = scene.GetFirstActor("camera");
                Vector2 position = camera.GetPosition();
                _sword.SizeTo(width, height);
                Console.WriteLine(position.X);
                _sword.MoveTo(position.X + X, position.Y + Y);
                _sword.Tint(Color.Red());
                scene.AddActor("sword",_sword);
            }
        }
    }
}