using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public Camera cam;
    public float moveSpeed = 5f;
    public float lookSensX = 15f;
    public float lookSensY = 15f;
    public float maxAngle = 85f;
    public float maxAngleY = 85f;

    private Rigidbody rigidBody;
    private float angleX = 0;
    private float angleY = 0;
    public Transform body;
    public Vector3 position;

    public float rotVal;

    public bool rightFire;

    public float fireRate = 0F;
    private float nextFire = 5.0F;

    // Use this for initialization
    void Start () {
        body = transform;
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float rot = -Input.GetAxis("Horizontal");
        float hor = -Input.GetAxis("Vertical");
        float vert = Input.GetAxis("Vert");

        if (rot == 1) {
            rotVal += 0.1f;
        } else if (rot == -1) {
            rotVal -= 0.1f;
        }

        position = body.transform.position + (hor * body.transform.forward + vert * body.transform.up ).normalized * moveSpeed * Time.deltaTime;
        angleX += mouseX * lookSensX;
        angleY += mouseY * lookSensY;
        angleX = Mathf.Clamp(angleX, -maxAngle, maxAngle);
        angleY = Mathf.Clamp(angleY, -maxAngleY, maxAngleY);

        //Rotation
        body.transform.rotation = Quaternion.Euler(+0, +0 + -rotVal, +0);
        cam.transform.localRotation = Quaternion.Euler(-angleY+0, angleX + 180, +0);

        if(Input.GetMouseButtonDown(0)) {
            if (angleX >= 70 && Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                rightFire = true;
                Debug.Log("fire right");
                GetComponent<Gun>().Shoot(rightFire);
            }
            else if(angleX <= -70 && Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                rightFire = false;
                Debug.Log("fire left");
                GetComponent<Gun>().Shoot(rightFire);
            }
        }
    }

    //Update
    void FixedUpdate() {
        rigidBody.MovePosition(position);
    }
}