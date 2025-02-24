using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;

    // [SerializeField] private float moveAmmount = 1f;
    [SerializeField] private float jumpAmmount = 1f;
    public Vector2 Velocity;
    public bool playerIsAlive = true;
    private bool playerFalling = false;
    public Animator animator;
    [SerializeField] private Vector3 upAngel;
    [SerializeField] private Vector3 downAngel;
    [SerializeField] AudioSource audioFly;
    [SerializeField] AudioSource audioFall;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // audioFly = GetComponent<AudioSource>();
        // audioFall = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerIsAlive)
        {
            animator.SetBool("isFly", true);
            MoveMethod();
        }
        else
        {
            animator.SetBool("isFly", false);
            if (!playerFalling)
            {
                audioFall.Play();
                playerFalling = true;
            }
        }
    }

    private void MoveMethod()
    {
        if (!GameMenu.isPaused)
        {
            // transform.Translate(new Vector2(moveAmmount, 0) * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioFly.Play();
                transform.rotation = Quaternion.Euler(upAngel);
                // Velocity = rb2d.linearVelocity = new Vector2(moveAmmount, 0);
                rb2d.AddForce(Vector2.up * jumpAmmount, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(upAngel);
            }
            else
            {
                transform.rotation = Quaternion.Euler(downAngel);
            }
        }
    }
}