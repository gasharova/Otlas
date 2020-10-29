using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using TMPro;

// [RequireComponent(typeof(AudioSource))]
namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        public TextMeshProUGUI textCoins;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>#
        ///
        public float initialPlayerSpeed = 1;
        private float playerSpeed;
        public float maxSpeed = 2;
        public float decreaseSpeed;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;


        public bool musicIsOff = true;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            playerSpeed = initialPlayerSpeed; //set player speed
        }

        protected override void Update()
        {
            // Initial background music
            if (musicIsOff) {
                BackgroundAudio.PlaySound("MainTheme");
                musicIsOff = false;
            }

            if (controlEnabled)
            {
                //move.x = Input.GetAxis("Horizontal"); //this was the previous arrow key input
                move.x = playerSpeed; //set player speed

                //As long as the speed is under max, increase slowly
                if (playerSpeed > maxSpeed)
                {
                    playerSpeed -= decreaseSpeed;
                }


                /*
                if (coinNum == 1)
                {
                    //Reset all backgrounds away
                    background1.transform.position = new Vector3(background1.transform.position.x, -100, background1.transform.position.z);
                    background2.transform.position = new Vector3(background2.transform.position.x, -100, background2.transform.position.z);
                    background3.transform.position = new Vector3(background3.transform.position.x, -100, background3.transform.position.z);
                    background4.transform.position = new Vector3(background4.transform.position.x, -100, background4.transform.position.z);

                    //Move the one we want
                    background1.transform.position = new Vector3(background1.transform.position.x, 0, background1.transform.position.z);

                    // Music for the specific background
                    BackgroundAudio.PlaySound("DarkForest");
                }
                if (Input.GetKey("1"))
                {
                    //Reset all backgrounds away
                    background1.transform.position = new Vector3(background1.transform.position.x, -100, background1.transform.position.z);
                    background2.transform.position = new Vector3(background2.transform.position.x, -100, background2.transform.position.z);
                    background3.transform.position = new Vector3(background3.transform.position.x, -100, background3.transform.position.z);
                    background4.transform.position = new Vector3(background4.transform.position.x, -100, background4.transform.position.z);

                    //Move the one we want
                    background1.transform.position = new Vector3(background1.transform.position.x, 0, background1.transform.position.z);

                    // Music for the specific background
                    BackgroundAudio.PlaySound("DarkForest");
                }
                if (Input.GetKey("2"))
                {
                    //Reset all backgrounds away
                    background1.transform.position = new Vector3(background1.transform.position.x, -100, background1.transform.position.z);
                    background2.transform.position = new Vector3(background2.transform.position.x, -100, background2.transform.position.z);
                    background3.transform.position = new Vector3(background3.transform.position.x, -100, background3.transform.position.z);
                    background4.transform.position = new Vector3(background4.transform.position.x, -100, background4.transform.position.z);

                    //Move the one we want
                    background2.transform.position = new Vector3(background2.transform.position.x, 0, background2.transform.position.z);

                    // Music for the specific background
                    BackgroundAudio.PlaySound("RockyHills");
                }
                if (Input.GetKey("3"))
                {
                    //Reset all backgrounds away
                    background1.transform.position = new Vector3(background1.transform.position.x, -100, background1.transform.position.z);
                    background2.transform.position = new Vector3(background2.transform.position.x, -100, background2.transform.position.z);
                    background3.transform.position = new Vector3(background3.transform.position.x, -100, background3.transform.position.z);
                    background4.transform.position = new Vector3(background4.transform.position.x, -100, background4.transform.position.z);

                    //Move the one we want
                    background3.transform.position = new Vector3(background3.transform.position.x, 0, background3.transform.position.z);

                    // Music for the specific background
                    BackgroundAudio.PlaySound("PeacefulMountains");
                }
                if (Input.GetKey("4"))
                {
                    //Reset all backgrounds away
                    background1.transform.position = new Vector3(background1.transform.position.x, -100, background1.transform.position.z);
                    background2.transform.position = new Vector3(background2.transform.position.x, -100, background2.transform.position.z);
                    background3.transform.position = new Vector3(background3.transform.position.x, -100, background3.transform.position.z);
                    background4.transform.position = new Vector3(background4.transform.position.x, -100, background4.transform.position.z);

                    //Move the one we want
                    background4.transform.position = new Vector3(background4.transform.position.x, 0, background4.transform.position.z);

                    // Music for the specific background
                    BackgroundAudio.PlaySound("Waterfalls");
                }
                */

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
                move.x = 0;
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

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
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