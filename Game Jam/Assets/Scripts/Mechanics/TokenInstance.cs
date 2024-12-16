using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player); else print("Test");
        }

        void OnPlayerEnter(PlayerController player)
        {
            print("Collision detected");

            var current_color = player.GetComponent<SpriteRenderer>().color;

            Color Gray = new Color(128, 128, 128);
            Color Bronze = new Color(205 / 255f, 127 / 255f, 50 / 255f);
            Color Green = new Color(50 / 255f, 205 / 255f, 50 / 255f);
            Color Blue = new Color(30 / 255f, 144 / 255f, 255 / 255f);
            Color Purple = new Color(147 / 255f, 112 / 255f, 219 / 255f);
            Color Gold = new Color(255 / 255f, 215 /255f, 0 / 255f);
            Color Red = new Color(255 / 255f, 69 / 255f, 0 / 255f);
            Color Black = new Color(0 / 255f, 0 / 255f, 0 / 255f);


            if (current_color == Color.gray)
            {
                print("Color is gray");
                // Set color to brozne
                player.GetComponent<SpriteRenderer>().color = Bronze;
                player.maxSpeed = 5;
                player.jumpTakeOffSpeed = 5;
            } else if (current_color == Bronze)
            {
                print("Color is bronze");
                // Set color to green
                player.GetComponent<SpriteRenderer>().color = Green;
                player.maxSpeed = 6;
                player.jumpTakeOffSpeed = 6;
            }
            else if (current_color == Green)
            {
                print("Color is green");
                // Set color to blue
                player.GetComponent<SpriteRenderer>().color = Blue;
                player.maxSpeed = 7;
                player.jumpTakeOffSpeed = 7;
            }
            else if (current_color == Blue)
            {
                print("Color is blue");
                // Set color to purple
                player.GetComponent<SpriteRenderer>().color = Purple;
                player.maxSpeed = 7.5f;
                player.jumpTakeOffSpeed = 7.5f;
            }
            else if (current_color == Purple)
            {
                print("Color is purple");
                // Set color to gold
                player.GetComponent<SpriteRenderer>().color = Red;
                player.maxSpeed = 8;
                player.jumpTakeOffSpeed = 8;
            }
            else if (current_color == Red)
            {
                print("Color is red");
                // Set color to red
                player.GetComponent<SpriteRenderer>().color = Gold;
                player.maxSpeed = 10;
                player.jumpTakeOffSpeed = 10;
            }

            if (collected) {
                // If player collects
                // Change player color
                print("Item already collected");
                return;
            }
            
            //disable the gameObject and remove it from the controller update list.
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            else
            {
                print("Controller is null");
            }
            //send an event into the gameplay system to perform some behaviour.
            var ev = Schedule<PlayerTokenCollision>();
            ev.token = this;
            ev.player = player;
        }
    }
}