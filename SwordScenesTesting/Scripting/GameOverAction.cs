using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Sword.Scenes.Over;


namespace Sword
{
    /// <summary>
    /// Removes the Actor if their health reaches 0 or below.
    /// </summary>
    public class GameOverAction : Byui.Games.Scripting.Action
    {
        public GameOverAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                Actor player = scene.GetFirstActor("player");
                
                int health = player.GetHealth();
                if (health <= 0)
                {
                    player.Tint(Color.Gray());

                }
                else
                {
                    player.Tint(Color.Blue());
                }
            }
            
            catch (Exception exception)
            {
                callback.OnError("Couldn't Game over.", exception);
            }
        }
    }
}