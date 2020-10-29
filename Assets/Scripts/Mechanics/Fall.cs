using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class Fall : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;

        internal PatrolPath.Mover mover;
       // internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
           // control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                Schedule<PlayerDeath>();
            }
        }
        /*
        void Update()
        {
            if (control.gameObject.activeSelf)
            {
                if (path != null)
                {
                    if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);

                    control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
                }
            }
        }
        */
    }
}
