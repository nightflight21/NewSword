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
                List<Actor> enemies = scene.GetAllActors("enemies");
                foreach (Actor actor in enemies)
                {
                    int health = actor.GetHealth();
                    if (health <= 0)
                    {
                        scene.RemoveActor("enemies", actor);
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