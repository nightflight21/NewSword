using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Moves the player within the game world while scrolling the screen.
    /// </summary>
    public class SpawnEnemyAction : Byui.Games.Scripting.Action
    {
        private ISettingsService settingsService;
        public SpawnEnemyAction(IServiceFactory serviceFactory)
        {
            this.settingsService = serviceFactory.GetSettingsService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if(scene.GetAllActors("enemies").Count<5){
                    Random rnd = new Random();
                    Actor enemy = new Actor();
                    enemy.SizeTo(50, 50);
                    enemy.MoveTo(rnd.Next(0,2560), rnd.Next(0,1920));
                    enemy.Tint(Color.Green());
                    scene.AddActor("enemies",enemy);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't spawn enemies.", exception);
            }
        }
    }
}