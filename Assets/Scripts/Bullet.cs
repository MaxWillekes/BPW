using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Collider ownCollider;
    public bool enter = true;

    void Start()
    {
        ownCollider = gameObject.AddComponent<BoxCollider>();
        ownCollider.isTrigger = true;
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "pCylinder3")
        {
            other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>().health -= Random.Range(10, 25);
            Debug.Log(other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>().health);

            if ( other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>().health <= 0)
            {
                other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
                other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().drag = 10;

                if (other.GetComponent<ParticleSystem>().isPlaying == false)
                {
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().airShipsNumberRemaining--;
                }

                other.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
