using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerResetCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public ResetTrigger reset_trigger;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(reset_trigger.resetCollisionAudio, reset_trigger.transform.position);
        }
    }
}