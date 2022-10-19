using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;

    private float Distance;
    private float LastShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if(Distance < 1.0f && Time.time > LastShoot +0.25f)
        {
            LastShoot = Time.time;

            Debug.Log("Shoot");
        }
    }
}
