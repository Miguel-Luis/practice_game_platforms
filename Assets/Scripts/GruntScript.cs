using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BullePrefab;

    private float Distance;
    private float LastShoot;
    private int Health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (John == null) return;

        FollowThePlayer();

        Shoot();
    }

    private void FollowThePlayer()
    {
        Vector3 direction = John.transform.position - transform.position;

        transform.localScale = direction.x >= 0.0f ? new Vector3(1.0f, 1.0f, 1.0f) : new Vector3(-1.0f, 1.0f, 1.0f);
    }

    private void Shoot()
    {
        Distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if(Distance < 1.0f && Time.time > LastShoot + 0.45f)
        {
            Vector3 direction;

            direction = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;

            GameObject bullet = Instantiate(BullePrefab, transform.position + direction * 0.1f, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetDirection(direction);

            LastShoot = Time.time;
        }
    }

    public void Hit()
    {
        Health--;

        if (Health == 0) Destroy(gameObject);
    }
}
