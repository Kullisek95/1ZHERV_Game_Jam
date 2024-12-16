using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// A simple controller for switching between UI panels.
    /// </summary>
    public class MainUIController : MonoBehaviour
    {
        public GameObject[] panels;

        public void SetActivePanel(int index)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var active = i == index;
                var g = panels[i];
                if (g.activeSelf != active) g.SetActive(active);
            }
        }

        public void RespawnPlayer(GameObject player)
            {
            var controller = player.GetComponent<PlayerController>();

            Color original_player_color = Color.gray;

            controller.GetComponent<SpriteRenderer>().color = original_player_color;
            controller.maxSpeed = 4;
            controller.jumpTakeOffSpeed = 4;

            // Set position to 1 1 0
            player.transform.position = new Vector3(-1.981f, 1.677f, 1f);

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

        void OnEnable()
        {
            print(panels.Length);
            SetActivePanel(0);
        }
    }
}