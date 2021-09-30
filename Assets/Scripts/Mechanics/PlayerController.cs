using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using UnityEngine.UI;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        // Audio
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        /*internal new*/ public AudioSource audioSource;
        
        // Movement
        Vector2 move;
        public float maxSpeed = 5;
        public float moveSpeed = 30;
        public float jumpTakeOffSpeed = 4;
        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        bool jump;
        /*internal new*/ public Collider2D collider2d;
        private static readonly int Grounded = Animator.StringToHash("grounded");
        
        // Sprite
        public bool facingRight = true;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        private static readonly int VelocityX = Animator.StringToHash("velocityX");
        
        // Utils
        public Health health;
        public bool paused;
        public float timer = 60; // Time to die
        public GameObject pauseMenu;
        private GameObject menu;
        public bool menuShown;
        public Text time;

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            // Handle timer
            timer -= Time.deltaTime;
            time.text = ((int) timer).ToString(CultureInfo.InvariantCulture);
            if (timer < 10)
            {
                time.color = Color.red;
            }
            else
            {
                time.color = Color.white;
            }
            if (timer < 0)
            {
                // Kill player
                Schedule<PlayerDeath>();
                timer = 60;
                Schedule<PlayerDeath>();
            }
            
            // Handle pausing
            if (Input.GetButtonDown("Pause"))
            {
                paused = !paused;
            }
            
            // If not paused, do movement stuff, otherwise show the menu
            if (!paused)
            {
                Destroy(menu);
                menuShown = false;
                
                move.x = moveSpeed * Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                // Reset things
                move.x = 0;
                velocity.x = 0;
                move.y = 0;
                velocity.y = 0;
                timer = 60;

                // If first tick since paused, show the menu
                if (!menuShown)
                {
                    menuShown = true;
                    menu = Instantiate(pauseMenu, new Vector3(), Quaternion.identity);
                    //menu.transform.parent.SetParent(GameObject.Find("Main Camera").transform, false);
                }
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool(Grounded, IsGrounded);
            animator.SetFloat(VelocityX, Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = Time.deltaTime * maxSpeed * move;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}
