using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rigidBody;
    public Transform body;
    public Vector3 position;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        body = transform;
        rigidBody = GetComponent<Rigidbody>();
        //rigidBody = transform.Find("Model").Find("group7").Find("pCylinder3").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            position = body.transform.position + (1 * body.transform.forward + 0 * body.transform.up).normalized * -1 * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (health > 0)
        {
            rigidBody.MovePosition(position);
        }
    }
}
