using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    public Transform body;
    public Vector3 position;
    public int MinDist;
    public int MaxDist;

    public Transform player;

    public int health;

    public string side;
    public bool firing;

    public float fireRate = 5;
    private float nextFireEnemy = 5.0F;

    void Start()
    {
        transform.LookAt(player);
        body = transform;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health > 0)
        {
            position = body.transform.position + (1 * body.transform.forward + 0 * body.transform.up).normalized * 1 * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) >= MaxDist)
            {
                var rotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.1f);
            }
            else if (Vector3.Distance(transform.position, player.position) >= MinDist)
            {
                var rotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation * Quaternion.Euler(+0, 90, +0), Time.deltaTime * 0.1f);
            }
            else if(Vector3.Distance(transform.position, player.position) <= MinDist)
            {
                var rotation = Quaternion.LookRotation(player.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation * Quaternion.Euler(+0, 90, +0), Time.deltaTime * 0.1f);
            }
        }

        if (firing && health > 0)
        {
            if (side == "TriggerRight" && Time.time > nextFireEnemy)
            {
                nextFireEnemy = Time.time + fireRate;
                GetComponent<Gun>().Shoot(false, (Random.value > 0.5f));
                GetComponent<AudioSource>().Play();
            }
            else if(side == "TriggerLeft" && Time.time > nextFireEnemy)
            {
                nextFireEnemy = Time.time + fireRate;
                GetComponent<Gun>().Shoot(true, (Random.value > 0.5f));
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void FixedUpdate()
    {
        if (health > 0)
        {
            transform.position += transform.forward * 1 * Time.deltaTime;
            rigidBody.MovePosition(position);
        }
    }

    public void fire(string side, bool firing)
    {
        if (side == "TriggerRight")
        {
            GetComponent<Gun>().Shoot(false, (Random.value > 0.5f));
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<Gun>().Shoot(true, (Random.value > 0.5f));
            GetComponent<AudioSource>().Play();
        }
    }
}
