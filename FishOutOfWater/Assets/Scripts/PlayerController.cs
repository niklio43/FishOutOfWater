using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle movement and player taking damage
public class PlayerController : MonoBehaviour 
{
    private bool aboveMaxHeight;
    private bool maxHeightReached;
    private float moveSpeed;
    private float Vertical, Horizontal;
    private Vector2 PlayerPos;
    private Vector2 GroundHeight;

    private GameObject Gun;
    private Rigidbody2D Body;
    private PlayerHealth playerHealth;
    private GunController gunController;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        moveSpeed = 10.0f;
        maxHeightReached = false;
        Body = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        Gun = GameObject.FindGameObjectWithTag("Gun");
        spriteRenderer = GetComponent<SpriteRenderer>();
        gunController = Gun.GetComponent<GunController>();
    }

    void Update()
    {
        PlayerPos = transform.position;
        if (playerHealth.state == States.Alive) //Player alive = movement enabled
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            if (Horizontal > 0)
            {
                Vertical = 0;
                transform.eulerAngles = new Vector3(0, 0, 0);
                gunController.Fire(-Horizontal, Vertical);
            }
            else if (Vertical > 0)
            {
                Horizontal = 0;
                transform.eulerAngles = new Vector3(0, 0, 90);
                gunController.Fire(Horizontal, -Vertical);
            }
            if (Horizontal < 0)
            {
                Vertical = 0;
                transform.eulerAngles = new Vector3(0, 180, 0);
                gunController.Fire(-Horizontal, Vertical);
            }
            else if (Vertical < 0)
            {
                Horizontal = 0;
                transform.eulerAngles = new Vector3(0, 0, -90);
                gunController.Fire(Horizontal, -Vertical);
            }

            if (Vertical == 0 && Horizontal == 0)
            {
                Body.gravityScale = 8f;
            }
            else
            {
                Move();
            }
        }
    }

    private void FixedUpdate()
    {
        //Handle the max height the player can fly above the ground
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1), -Vector2.up);

        if (hit.collider.CompareTag("Ground"))
        {
            GroundHeight = hit.point;

            if (PlayerPos.y - GroundHeight.y > 5.0f)
            {
                maxHeightReached = true;
            }
            else
            {
                maxHeightReached = false;
            }
            if (PlayerPos.y - GroundHeight.y > 5.5f)
            {
                aboveMaxHeight = true;
            }
            else
            {
                aboveMaxHeight = false;
            }
        }
    }

    public void Move()
    {
        if (maxHeightReached)
        {   
            //Bug fix, might remove if better solution comes to mind
            if (Input.GetKey(KeyCode.DownArrow)) 
            {
                Vertical = -1;
            }
            else
            {
                Vertical = 0;
            }
        }
        if (aboveMaxHeight && maxHeightReached)
        {
            Vertical = -1;
        }
        Body.gravityScale = 0f;
        Body.velocity = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);
    }

    public void Dead()
    {
        spriteRenderer.color = Color.red;
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(20);
        }
    }
}
