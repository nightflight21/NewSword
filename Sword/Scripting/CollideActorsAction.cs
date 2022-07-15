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
            try
            {
                // get the actors from the cast
                Actor actor1 = scene.GetFirstActor("player");
                Actor actor2 = scene.GetFirstActor("enemy");
                
                // detect a collision between the actors.
                if (actor2.Overlaps(actor1))
                {
                    // resolve by changing the actor's color to something else
                    actor2.Tint(Color.Green());
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