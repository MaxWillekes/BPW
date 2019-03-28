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
            Debug.Log("Warcrime :-D");
        }
    }
}
