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
        foreach (Actor enemy in enemies)                                       //for each enemy in the group
            try
            {
                // get the actors from the cast
<<<<<<< HEAD
                Actor player = scene.GetFirstActor("player");                   //grabs the player
                //Actor enemy = scene.GetFirstActor("enemies");                //gonna use a group instead
                Actor sword = scene.GetFirstActor("sword");                     //grabs the sword
=======
                Actor actor1 = scene.GetFirstActor("player");                   //grabs the player
                Color current = actor1.GetColor();
                //Actor actor2 = scene.GetFirstActor("enemies");                //gonna use a group instead
>>>>>>> 95f7c3601e4dd0b43741e3270678744d12c47167
                
                // detect a collision between the actors.
                if (enemy.Overlaps(player))                                    //if the player and enemy over lap
                {
                    // resolve by changing the actor's color to something else
                    //enemy.SetHealth(enemy.GetHealth() - 1);                 //subtract 1 from the enemy's health
                    player.Tint(Color.Red());                                   //player flickers red to indicate damage
                    player.SetHealth(player.GetHealth() - 1);                   //player takes 1 damage
                    Console.WriteLine("You got hit! Your health is now " + player.GetHealth()); //owie
                    //Console.WriteLine("The enemy's health is now " + enemy.GetHealth());
                    if (player.GetLeft() > (enemy.GetLeft() + 25))             //if player is to the right of the enemy
                    {
                        player.MoveTo(enemy.GetRight() + 25, player.GetTop()); //player gets knocked right
                    }
                    else if (player.GetRight() < (enemy.GetLeft() + 25))       //if the player is left of the enemy,
                    {
                        player.MoveTo(enemy.GetLeft() - 75, player.GetTop());  //player gets knocked left
                    }
                    if (player.GetTop() > (enemy.GetBottom() - 25))            //you get the idea lol
                    {
                        player.MoveTo(player.GetLeft(), enemy.GetBottom() + 25);
                    }
                    else if (player.GetBottom() < (enemy.GetTop() + 25))
                    {
                        player.MoveTo(player.GetLeft(), enemy.GetTop() - 75);
                    }
                }
                else
                {
                    // otherwise, just make it the original color
<<<<<<< HEAD
                    player.Tint(Color.Blue());
                }
                // detect a collision between the actors.
                if(scene.GetAllActors("sword").Count >= 1)
                if (sword.Overlaps(enemy))                                    //if the player and enemy over lap
                {
                    enemy.SetHealth(enemy.GetHealth() - 1);                     //subtract 1 from the enemy's health
                    enemy.Tint(Color.Red());                                   //player flickers red to indicate damage
                    Console.WriteLine("The enemy's health is now " + enemy.GetHealth());
                    if (enemy.GetLeft() > (player.GetLeft() + 25))             //if enemy is to the right of the player
                    {
                        enemy.MoveTo(player.GetRight() + 75, enemy.GetTop()); //enemy gets knocked right
                    }
                    else if (enemy.GetRight() < (player.GetLeft() + 25))       //if the enemy is left of the player,
                    {
                        enemy.MoveTo(player.GetLeft() - 125, enemy.GetTop());  //enemy gets knocked left
                    }
                    if (enemy.GetTop() > (player.GetBottom() - 25))            //you get the idea lol
                    {
                        enemy.MoveTo(enemy.GetLeft(), player.GetBottom() + 75);
                    }
                    else if (enemy.GetBottom() < (player.GetTop() + 25))
                    {
                        enemy.MoveTo(enemy.GetLeft(), player.GetTop() - 125);
                    }
=======
                    actor1.Tint(current);
>>>>>>> 95f7c3601e4dd0b43741e3270678744d12c47167
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}