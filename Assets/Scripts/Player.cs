using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerData playerData { get; private set; }


    public Animator animator;
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public float jumpForce = 10f;
    public float dashSpeed = 10f;
    public int health = 200;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Transform startingPoint;
    public Transform endingPoint;
    //public bool goingBack { get; set; }
    private Rigidbody2D rb;

    public GameObject projectile;
    public bool firstInit;
    private bool facingRight = true;
    public VectorValue startingPosition;
    public Camera MainCamera;

    public Spellbook Spellbook;
    public Canvas SpellMenuCanvas;
    bool IsSpellMenuOpen = false;
    bool StartedCastingSpell = false;


    // Start is called before the first frame update
    private void OnEnable()
    {
        playerData = PlayerPersistence.LoadData();

    }

    private void OnDisable()
    {
        PlayerPersistence.StoreData(this);

    }
    void Start()
    {
        Spellbook = new Spellbook(gameObject);
        SpellMenuCanvas.GetComponent<SpellMenuCanvasScript>().SetupButtons();

        rb = gameObject.GetComponent<Rigidbody2D>();

        if (playerData.direction == "goingRight")
        {
            //Vector3 offset = new Vector3(1f, -1.5f, transform.position.z);
            //transform.position = startingPoint.position;
        }
        else if (playerData.direction == "goingLeft")
        {
            //transform.position = startingPosition.initialValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(groundCheck.position.x, groundCheck.position.y), new Vector2(groundCheck.position.x + 0.5f, groundCheck.position.y - 0.51f), groundLayer);
        Jump();
        Dash();
        CastSpell();
        OpenSpellMenu();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
       
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
            Flip();
        else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
            Flip();

        transform.position += movement * Time.deltaTime * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("Jumping", true);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (facingRight)
                rb.AddForce(new Vector2(dashSpeed, 0f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(-dashSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OpenSpellMenu() {
        if(Input.GetKey(KeyCode.Tab) && !IsSpellMenuOpen && !StartedCastingSpell){
            IsSpellMenuOpen = true;
            SpellMenuCanvas.enabled = true;
        } else if(!Input.GetKey(KeyCode.Tab) && IsSpellMenuOpen) {
            IsSpellMenuOpen = false;
            SpellMenuCanvas.enabled = false;
        }
    }

    void CastSpell()
    {
        if (Input.GetMouseButtonDown(0) && !IsSpellMenuOpen)
        {
            // responsible for spells which are cast continuously or require a cast time, other spells are "casted" directly from here
            StartedCastingSpell = true;
            this.Spellbook.StartCastSpell();
        }

        if (Input.GetMouseButtonUp(0) && StartedCastingSpell)
        {
            // spells  which are cast continuously or require a cast time are "charged" for as long as the player presses the button and are "fired" here
            StartedCastingSpell = false;
            this.Spellbook.EndCastSpell();
        }
    }
}
