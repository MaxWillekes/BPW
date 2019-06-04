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

    float rot;
    float hor;
    float vert;

    public bool rightFire;

    public float fireRate = 5;
    private float nextFire = 5.0F;
    private float nextFireEnemy = 5.0F;

    public int health;

    // Use this for initialization
    void Start () {
        body = transform;
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().drag = 5;
            
            if(transform.position.y <= 20)
            {
                Debug.Log("endGame");
            }
        }

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

        if(Input.GetMouseButtonDown(0) && health > 0) {
            if (angleX >= 70 && Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                rightFire = true;
                GetComponent<Gun>().Shoot(rightFire);
                GetComponent<AudioSource>().Play();
            }
            else if(angleX <= -70 && Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                rightFire = false;
                GetComponent<Gun>().Shoot(rightFire);
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void FixedUpdate() {
        rigidBody.MovePosition(position);
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Bullet(Clone)" && other.transform.parent.GetComponent<EnemyMovement>().health > 0)
        {
            if (other.tag == "TriggerRight" && Time.time > nextFireEnemy)
            {
                nextFireEnemy = Time.time + fireRate;
                other.transform.parent.GetComponent<Gun>().Shoot(false);
                other.transform.parent.GetComponent<AudioSource>().Play();
            }
            else if (other.tag == "TriggerLeft" && Time.time > nextFireEnemy)
            {
                nextFireEnemy = Time.time + fireRate;
                other.transform.parent.GetComponent<Gun>().Shoot(true);
                other.transform.parent.GetComponent<AudioSource>().Play();
            }
        }
    }
}