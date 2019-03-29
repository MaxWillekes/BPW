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
            if(other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.name == "EnemyAirship")
            {
                other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>().health -= Random.Range(10, 25);

                if (other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>().health <= 0)
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
            else if (other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.name == "Airship")
            {
                other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<PlayerMoveScript>().health -= Random.Range(10, 25);
            }
        }
    }
}
