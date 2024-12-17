using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Unity.VisualScripting.FullSerializer;
using Platformer.UI;



namespace Platformer.Mechanics
{
    [RequireComponent(typeof(Collider2D))]


    public class VictoryTrigger : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            // Toggle main menu
            var metaGameController = GameObject.FindObjectOfType<MetaGameController>();
            if (metaGameController != null)
            {
                metaGameController.ToggleMainMenu(true);
                // Set active panel to 2
                metaGameController.mainMenu.SetActivePanel(2);

                metaGameController.mainMenu.Victory();
            }
        }
    }
}


