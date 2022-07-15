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
        List<Actor> enemies = scene.GetAllActors("enemies");                    //putting all enemies in a group
        foreach (Actor actor2 in enemies)                                       //for each enemy in the group
            try
            {
                // get the actors from the cast
                Actor actor1 = scene.GetFirstActor("player");                   //grabs the player
                //Actor actor2 = scene.GetFirstActor("enemies");                //gonna use a group instead
                
                // detect a collision between the actors.
                if (actor2.Overlaps(actor1))                                    //if the player and enemy over lap
                {
                    // resolve by changing the actor's color to something else
                    actor2.SetHealth(actor2.GetHealth() - 1);                  //subtract 1 from the enemy's health
                    actor1.Tint(Color.Red());                                   //player flickers red to indicate damage
                    actor1.SetHealth(actor1.GetHealth() - 1);                   //player takes 1 damage
                    Console.WriteLine("You got hit! Your health is now " + actor1.GetHealth()); //owie
                    Console.WriteLine("The enemy's health is now " + actor2.GetHealth());
                    if (actor1.GetLeft() > (actor2.GetLeft() + 25))             //if player is to the right of the enemy
                    {
                        actor1.MoveTo(actor2.GetRight() + 25, actor1.GetTop()); //player gets knocked right
                    }
                    else if (actor1.GetRight() < (actor2.GetLeft() + 25))       //if the player is left of the enemy,
                    {
                        actor1.MoveTo(actor2.GetLeft() - 75, actor1.GetTop());  //player gets knocked left
                    }
                    if (actor1.GetTop() > (actor2.GetBottom() - 25))            //you get the idea lol
                    {
                        actor1.MoveTo(actor1.GetLeft(), actor2.GetBottom() + 25);
                    }
                    else if (actor1.GetBottom() < (actor2.GetTop() + 25))
                    {
                        actor1.MoveTo(actor1.GetLeft(), actor2.GetTop() - 75);
                    }
                }
                else
                {
                    // otherwise, just make it the original color
                    actor1.Tint(Color.Blue());
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}