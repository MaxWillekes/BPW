using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Collider ownCollider;
    public bool enter = true;
    int extraRotation;

    GameObject hitObject;

    void Start()
    {
        ownCollider = gameObject.AddComponent<BoxCollider>();
        ownCollider.isTrigger = true;
        Destroy(gameObject, 2);

        /*
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveScript>().rightFire)
        {
            extraRotation = 90;
        }
        else
        {
            extraRotation = 270;
        }

        gameObject.transform.localRotation = Quaternion.Euler(+0, +extraRotation, +0);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AirshipHitboxTag")
        {
            hitObject = other.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

            if (hitObject.tag == "EnemyAirship")
            {
                hitObject.GetComponent<EnemyMovement>().health -= Random.Range(10, 25);

                if (hitObject.GetComponent<EnemyMovement>().health <= 0)
                {
                    hitObject.GetComponent<Rigidbody>().useGravity = true;
                    hitObject.GetComponent<Rigidbody>().drag = 10;

                    if (other.GetComponent<ParticleSystem>().isPlaying == false)
                    {
                        GameObject.Find("GameManager").GetComponent<GameManagerScript>().airShipsNumberRemaining--;
                    }

                    other.GetComponent<ParticleSystem>().Play();
                }
            }
            else if (hitObject.tag == "Player")
            {
                hitObject.GetComponent<PlayerMoveScript>().health -= Random.Range(10, 25);
            }
        }
    }
}