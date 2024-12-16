using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Unity.VisualScripting.FullSerializer;


namespace Platformer.Mechanics {
    [RequireComponent(typeof(Collider2D))]

    public class ResetTrigger : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            print("Trigger entered");
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player); else print("Test");
        }

        void OnPlayerEnter(PlayerController player)
        {
            print("Player entered resettrigger");

            Color original_player_color = Color.gray;

            player.GetComponent<SpriteRenderer>().color = original_player_color;
            player.maxSpeed = 4;
            player.jumpTakeOffSpeed = 4;

            // Set all tokens to active
            var tokens = UnityEngine.Object.FindObjectsOfType<TokenInstance>();

            print("Total tokens: " + tokens.Length);

            for (var i = 0; i < tokens.Length; i++)
            {


                // If token is collected, set it to not collected
                if (tokens[i].collected)
                {
                    tokens[i].gameObject.SetActive(true);
                    tokens[i].collected = false;
                    tokens[i].sprites = tokens[i].idleAnimation;
                    tokens[i].frame = 0;
                    tokens[i]._renderer.sprite = tokens[i].sprites[tokens[i].frame];
                }
            }

        }
    }
}


