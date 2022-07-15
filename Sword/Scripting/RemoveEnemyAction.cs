using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Removes the Actor if their health reaches 0 or below.
    /// </summary>
    public class RemoveEnemyAction : Byui.Games.Scripting.Action
    {
        public RemoveEnemyAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                List<Actor> enemies = scene.GetAllActors<Actor>("enemies");
                foreach (Actor enemy in enemies)
                {
                    int health = enemy.GetHealth();
                    if (health <= 0)
                    {
                        scene.RemoveActor("enemies", enemy);
                    }
                }
            }
            
            catch (Exception exception)
            {
                callback.OnError("Couldn't remove actor.", exception);
            }
        }
    }
}