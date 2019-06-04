using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPosition;
    public float shootingForce = 500;
    private bool fired = false;
    float cannonsFired = 0;
    private float sideVal = -2.85f;
    private int sideRot = 270;

    void Update() {
        if (Input.GetMouseButton(0)) {
            if (fired == false) {
                fired = true;
            }
            sideRot = -90;
            sideVal = -2.85f;
        }
    }

    public void Shoot(bool Side) {
        if (Side == false) {
            sideVal = 2.85f;
            sideRot = 90;
        }

        while (cannonsFired < 12) {
            shootingPosition.transform.localPosition = new Vector3(sideVal, 0, cannonsFired - 5);
            shootingPosition.transform.localRotation = Quaternion.Euler(0, (180 + sideRot), 0);
            GameObject bullet = Instantiate(bulletPrefab, shootingPosition.position, shootingPosition.rotation);
            Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
            bulletRigidBody.AddForce(shootingForce * bullet.transform.forward);
            cannonsFired += 1.5f;
            if (cannonsFired >= 12)
            {
                cannonsFired = 0;
                shootingPosition.transform.localPosition = new Vector3(1.18f, 0, cannonsFired);
                break;
            }
        }
    }
}