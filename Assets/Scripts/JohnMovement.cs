using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BullePrefab;
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private bool Front;
    private float LastShoot;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Run();

        Jump();

        Shoot();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    private void Run()
    {
        float direction = transform.localScale.x;

        if (Horizontal < 0.0f)
        {
            direction = -1.0f;
        } 
        else if (Horizontal > 0.0f)
        {
            direction = 1.0f;
        }

        transform.localScale = new Vector3(direction, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
    }

    private void Jump()
    {
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        Grounded = Physics2D.Raycast(transform.position, Vector3.down, 0.1f) ? true : false;

        if (Input.GetKeyDown(KeyCode.Z) && Grounded)
        {
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.X) && Time.time > LastShoot + 0.25f)
        {
            Vector3 direction;

            direction = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;

            GameObject bullet = Instantiate(BullePrefab, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);

            LastShoot = Time.time;
        }
    }
}
