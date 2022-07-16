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
                    Actor player = scene.GetFirstActor("player");
                    Random rnd = new Random();
                    Actor enemy = new Actor();
                    enemy.SizeTo(50, 50);
                    float x = rnd.Next(0,2560);
                    float y = rnd.Next(0,1920);
                    if (x <= player.GetCenterX() && x > (player.GetCenterX() - 100))
                    {x = (player.GetCenterX()-100);}
                    else if (x > player.GetCenterX() && x < player.GetCenterX() + 100)
                    {x = player.GetCenterX() + 100;}
                    if (y <= player.GetCenterY() && y > player.GetCenterY() - 100)
                    {y = player.GetCenterY()-100;}
                    else if (y > player.GetCenterY() && y < player.GetCenterY() + 100)
                    {y = player.GetCenterY() + 100;}
                    enemy.MoveTo(x, y);
                    enemy.Tint(Color.Green());
                    enemy.SetHealth(2);
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