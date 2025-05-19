using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClearSky
{
    public class DemoCollegeStudentController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                KickBoard();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;

            bool moveLeft = Input.GetAxisRaw("Horizontal") < 0 || isMovingLeft;
            bool moveRight = Input.GetAxisRaw("Horizontal") > 0 || isMovingRight;

            if (!isKickboard)
            {
                anim.SetBool("isRun", false);

                if (moveLeft)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;
                    transform.localScale = new Vector3(direction, 1, 1);

                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);
                }

                if (moveRight)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;
                    transform.localScale = new Vector3(direction, 1, 1);

                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);
                }

                transform.position += moveVelocity * movePower * Time.deltaTime;
            }
            else
            {
                if (moveLeft)
                {
                    direction = -1;
                    moveVelocity = Vector3.left;
                    transform.localScale = new Vector3(direction, 1, 1);
                }

                if (moveRight)
                {
                    direction = 1;
                    moveVelocity = Vector3.right;
                    transform.localScale = new Vector3(direction, 1, 1);
                }

                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
            
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

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
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
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

        public void JumpButton()
        {
            if (!anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
        }

        private bool isMovingLeft = false;
        private bool isMovingRight = false;

        public void BtnLeftDown() {
            RunLeft(true);
        }

        public void BtnLeftUp() {
            RunLeft(false);
        }

        public void BtnRightDown() {
            RunRight(true);
        }

        public void BtnRightUp() {
            RunRight(false);
        }

        public void RunLeft(bool isPressed)
        {
            isMovingLeft = isPressed;

            if (isPressed)
            {
                direction = -1;
                transform.localScale = new Vector3(direction, 1, 1);

                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);
            }
            else
            {
                if (!isMovingRight) // jika tidak menekan kanan juga
                    anim.SetBool("isRun", false);
            }
        }

        public void RunRight(bool isPressed)
        {
            isMovingRight = isPressed;

            if (isPressed)
            {
                direction = 1;
                transform.localScale = new Vector3(direction, 1, 1);

                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);
            }
            else
            {
                if (!isMovingLeft) // jika tidak menekan kiri juga
                    anim.SetBool("isRun", false);
            }
        }

        public void AttackButton()
        {
            anim.SetTrigger("attack");
        }

    }

}