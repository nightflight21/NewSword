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
    public class RemoveActorAction : Byui.Games.Scripting.Action
    {
        public RemoveActorAction()
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
                        enemies.Remove(actor);
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