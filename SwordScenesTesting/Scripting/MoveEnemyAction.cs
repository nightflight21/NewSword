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
    public class MoveEnemyAction : Byui.Games.Scripting.Action
    {
        public MoveEnemyAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            List<Actor> enemies = scene.GetAllActors("enemies");                    //putting all enemies in a group
            foreach (Actor enemy in enemies)                                        //for each enemy in the group
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                //Actor enemy = scene.GetFirstActor("enemies");                     //dont need this
                
                // move the player and clamp it to the boundaries of the world.
                //enemy.Move();
                enemy.ClampTo(world);    
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}