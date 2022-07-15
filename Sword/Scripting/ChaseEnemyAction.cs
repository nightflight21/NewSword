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
    public class ChaseEnemyAction : Byui.Games.Scripting.Action
    {
        public ChaseEnemyAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            List<Actor> enemies = scene.GetAllActors("enemies");                    //putting all enemies in a group
            foreach (Actor enemy in enemies)                                        //for each enemy in the group
            try
            {
                Actor player = scene.GetFirstActor("player");
                if(enemy.GetPosition().X < player.GetPosition().X + 200 && enemy.GetPosition().X > player.GetPosition().X - 200 && enemy.GetPosition().Y < player.GetPosition().Y + 200 && enemy.GetPosition().Y > player.GetPosition().Y - 200){
                    if (enemy.GetCenterX() == player.GetCenterX())
                    {
                        enemy.MoveTo(player.GetPosition().X, enemy.GetPosition().Y - ((enemy.GetCenterY() - player.GetCenterY())/Math.Abs(enemy.GetCenterY() - player.GetCenterY())));
                    }
                    else if (enemy.GetCenterY() == player.GetCenterY())
                    {
                        enemy.MoveTo(enemy.GetPosition().X - ((enemy.GetCenterX() - player.GetCenterX())/Math.Abs(enemy.GetCenterX() - player.GetCenterX())), player.GetPosition().Y);
                    }
                    else
                    enemy.MoveTo(
                        enemy.GetPosition().X - ((enemy.GetCenterX() - player.GetCenterX())/Math.Abs(enemy.GetCenterX() - player.GetCenterX())), 
                        enemy.GetPosition().Y - ((enemy.GetCenterY() - player.GetCenterY())/Math.Abs(enemy.GetCenterY() - player.GetCenterY())));
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move enemy.", exception);
            }
        }
    }
}