using UnityEngine;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float movePower = 10f;
        public float kickBoardMovePower = 15f;
        public float jumpPower = 20f;

        [Header("References")]
        private Rigidbody2D rb;
        private Animator anim;

        [Header("States")]
        private int direction = 1;
        private bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;
        private bool isMovingLeft = false;
        private bool isMovingRight = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            Restart();

            if (!alive) return;

            HandleInputs();
        }

        void HandleInputs()
        {
            Hurt();
            Die();
            Attack();
            Jump();
            ToggleKickBoard();
            Run();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }

        void ToggleKickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                isKickboard = !isKickboard;
                anim.SetBool("isKickBoard", isKickboard);
            }
        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            bool moveLeft = Input.GetAxisRaw("Horizontal") < 0 || isMovingLeft;
            bool moveRight = Input.GetAxisRaw("Horizontal") > 0 || isMovingRight;

            if (moveLeft)
            {
                direction = -1;
                moveVelocity = Vector3.left;
            }
            else if (moveRight)
            {
                direction = 1;
                moveVelocity = Vector3.right;
            }

            transform.localScale = new Vector3(direction, 1, 1);

            if (!anim.GetBool("isJump"))
                anim.SetBool("isRun", moveLeft || moveRight);
            else
                anim.SetBool("isRun", false);

            float speed = isKickboard ? kickBoardMovePower : movePower;
            transform.position += moveVelocity * speed * Time.deltaTime;
        }

        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }

            if (!isJumping) return;

            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            isJumping = false;
        }

        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }

        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");

                float forceX = direction == 1 ? -5f : 5f;
                rb.AddForce(new Vector2(forceX, 1f), ForceMode2D.Impulse);
            }
        }

        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }

        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }

        // Mobile UI Controls
        public void JumpButton()
        {
            if (!anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
        }

        public void BtnLeftDown() => SetLeftMovement(true);
        public void BtnLeftUp() => SetLeftMovement(false);
        public void BtnRightDown() => SetRightMovement(true);
        public void BtnRightUp() => SetRightMovement(false);

        void SetLeftMovement(bool isPressed)
        {
            isMovingLeft = isPressed;
            if (!isPressed && !isMovingRight)
                anim.SetBool("isRun", false);
        }

        void SetRightMovement(bool isPressed)
        {
            isMovingRight = isPressed;
            if (!isPressed && !isMovingLeft)
                anim.SetBool("isRun", false);
        }

        public void AttackButton()
        {
            anim.SetTrigger("attack");
        }
    }
}