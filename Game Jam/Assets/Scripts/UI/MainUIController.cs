using JetBrains.Annotations;
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

        public void Victory()
            {
            print("Victory");

            //Disable all gameobjects with a component Button
            var buttons = UnityEngine.Object.FindObjectsOfType<UnityEngine.UI.Button>();

            for (var i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);

                // If the name of the button is "RespawnButton", set it to active
                if (buttons[i].name == "RestartButton")
                {
                    buttons[i].gameObject.SetActive(true);
                }
            }

            //Enable the victory panel
            SetActivePanel(2);
        }

        public void RestartGame(GameObject player)
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

            // Get elapsedTime from TimerScript
            var timer = GameObject.FindObjectOfType<Timer>();
            timer.elapsedTime = 0;

            // Set all buttons to active
            var buttons = UnityEngine.Object.FindObjectsOfType<UnityEngine.UI.Button>();

            for (var i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(true);

                // If the name of the button is "RestartButton", set it to not active
                if (buttons[i].name == "RestartButton")
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }

        void OnEnable()
        {
            SetActivePanel(0);

            // Disable all buttons but Respawn
            var buttons = UnityEngine.Object.FindObjectsOfType<UnityEngine.UI.Button>();

            for (var i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
        }
    }
}