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
    }

    void FixedUpdate()
    {
        if (health > 0)
        {
            transform.position += transform.forward * 1 * Time.deltaTime;
            rigidBody.MovePosition(position);
        }
    }
}
