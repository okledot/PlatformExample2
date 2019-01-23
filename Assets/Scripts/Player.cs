using UnityEngine;

public class Player : PhysicsObject
{
    [Header("Игровые объекты")]
    public GameObject rocket;
    public GameObject startRocket;
    public GameObject deathZone;
    public GameObject startPoint;

    [Header("Аттрибуты")]
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        gameObject.transform.position = startPoint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == deathZone)
        {
            velocity.y = 0;
            gameObject.transform.position = startPoint.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ActionPlatform")
            gameObject.transform.position = collision.gameObject.transform.position;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move.x));
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("SpeedY", velocity.y);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(rocket, startRocket.transform.position, transform.rotation);
        }

        targetVelocity = move * maxSpeed;

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.00f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }   
    }
}