using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class PlayerScript : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Animator animator;
        private float horizontalMove = 0f;
        private bool isFacingRight = true;
        [SerializeField] int sceneNumber;

        [Header("Movement Settings")]
        [Range(0, 10f)] public float speed = 1f;
        [Range(0, 15f)] public float jumpForse = 8f;

        [Header("Ground Checker Settings")]
        public bool isOnGround = false;
        [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;
        [Range(0, 5f)] public float checkGroundRadius = 0.3f;

        private PlayerStates State
        {
            get
            {
                return (PlayerStates)animator.GetInteger("State");
            }

            set
            {
                animator.SetInteger("State", (int)value);
            }
        }

        void Start()
        {
            rb = GetComponentInChildren<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (isOnGround && horizontalMove == 0)
            {
                State = PlayerStates.idle;
            }

            if (isOnGround && horizontalMove != 0)
            {
                State = PlayerStates.run;
            }

            if (!isOnGround)
            {
                State = PlayerStates.idle;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
            }

            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if (horizontalMove < 0 && isFacingRight)
            {
                Flip();
            }

            if (horizontalMove > 0 && !isFacingRight)
            {
                Flip();
            }
        }

        private void FixedUpdate()
        {
            Vector2 targetVelocity = new Vector2(horizontalMove * 5f, rb.velocity.y);
            rb.velocity = targetVelocity;
            CheckGround();
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(
                new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY),
                checkGroundRadius
            );

            if (colliders.Length > 1)
            {
                isOnGround = true;
            }
            else
            {
                isOnGround = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Respawn")
            {
                SceneManager.LoadScene(sceneNumber);
            }
        }
    }
}
