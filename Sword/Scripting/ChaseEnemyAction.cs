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
                Actor player = scene.GetFirstActor("player");                       //grabs the player
                if(enemy.GetPosition().X < player.GetPosition().X + 200             //if enemy is within 200 pixels of the player
                && enemy.GetPosition().X > player.GetPosition().X - 200             //if enemy is within 200 pixels of the player
                && enemy.GetPosition().Y < player.GetPosition().Y + 200             //if enemy is within 200 pixels of the player
                && enemy.GetPosition().Y > player.GetPosition().Y - 200){           //if enemy is within 200 pixels of the player
                    if (enemy.GetCenterX() == player.GetCenterX())                  //if enemy has same x axis as player
                    {
                        enemy.MoveTo(player.GetPosition().X, enemy.GetPosition().Y - ((enemy.GetCenterY() - player.GetCenterY())/Math.Abs(enemy.GetCenterY() - player.GetCenterY())));                      //move enemy up or down
                    }
                    else if (enemy.GetCenterY() == player.GetCenterY())             //if enemy has same y axis as player
                    {
                        enemy.MoveTo(enemy.GetPosition().X - ((enemy.GetCenterX() - player.GetCenterX())/Math.Abs(enemy.GetCenterX() - player.GetCenterX())), player.GetPosition().Y);                    //move enemy left or right
                    }
                    else
                    enemy.MoveTo(                                                   //else enemy just moves towards player
                        enemy.GetPosition().X - ((enemy.GetCenterX() - player.GetCenterX())/Math.Abs(enemy.GetCenterX() - player.GetCenterX())), 
                        enemy.GetPosition().Y - ((enemy.GetCenterY() - player.GetCenterY())/Math.Abs(enemy.GetCenterY() - player.GetCenterY())));
                }                                                                   //this is to avoid any division by zero errors
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move enemy.", exception);
            }
        }
    }
}