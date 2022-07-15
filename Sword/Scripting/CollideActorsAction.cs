using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Sword
{
    /// <summary>
    /// Detects and resolves collisions between actors.
    /// </summary>
    public class CollideActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public CollideActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
        List<Actor> enemies = scene.GetAllActors("enemies");                     //putting all enemies in a group
        foreach (Actor actor2 in enemies)
            try
            {
                // get the actors from the cast
                Actor actor1 = scene.GetFirstActor("player");
                //Actor actor2 = scene.GetFirstActor("enemies");                //gonna use a group instead
                
                // detect a collision between the actors.
                if (actor2.Overlaps(actor1))
                {
                    // resolve by changing the actor's color to something else
                    actor2.Tint(Color.Red());
                    actor1.SetHealth(actor1.GetHealth() - 1);
                    Console.WriteLine("You got hit! Your health is now " + actor1.GetHealth());
                    if (actor1.GetLeft() < actor2.GetRight())
                    {
                        actor1.MoveTo(actor1.GetLeft() + 10, actor1.GetTop());
                    }
                    else if (actor1.GetRight() > actor2.GetLeft())
                    {
                        actor1.MoveTo(actor1.GetRight() - 10, actor1.GetTop());
                    }
                    else if (actor1.GetTop() < actor2.GetBottom())
                    {
                        actor1.MoveTo(actor1.GetLeft(), actor1.GetTop() + 10);
                    }
                    else if (actor1.GetBottom() > actor2.GetTop())
                    {
                        actor1.MoveTo(actor1.GetLeft(), actor1.GetBottom() - 10);
                    }
                    //actor1.MoveTo(0, -10);
//this.GetLeft() < other.GetRight() && this.GetRight() > other.GetLeft() && this.GetTop() < other.GetBottom() && this.GetBottom() > other.GetTop()

                }
                else
                {
                    // otherwise, just make it the original color
                    actor2.Tint(Color.Blue());
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}