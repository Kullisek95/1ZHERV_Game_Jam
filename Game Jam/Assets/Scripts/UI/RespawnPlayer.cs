
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Unity.VisualScripting.FullSerializer;


namespace Platformer.UI
{
    public class RespawnPlayer : MonoBehaviour
    {

        void RespawnPlayerFunction()
        {
            var player = GetComponent<PlayerController>();

            print("Player resetting");

            Color original_player_color = Color.gray;

            player.GetComponent<SpriteRenderer>().color = original_player_color;
            player.maxSpeed = 4;
            player.jumpTakeOffSpeed = 4;

        }
    }
}


