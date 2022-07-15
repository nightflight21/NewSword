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
                if(enemy.GetPosition().X < player.GetPosition().X + 100){
                    enemy.MoveTo(enemy.GetPosition().X + 1, enemy.GetPosition().Y);
                }
                    else if (enemy.GetPosition().X > player.GetPosition().X - 100){
                        enemy.MoveTo(enemy.GetPosition().X - 1, enemy.GetPosition().Y);
                    }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move enemy.", exception);
            }
        }
    }
}