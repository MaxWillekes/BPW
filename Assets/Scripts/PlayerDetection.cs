using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool rightSide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Airship")
        {
            GetComponent<Gun>().Shoot(rightSide);
        }
    }
}
