using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public Text airShipsRemaining;
    public Text healthRemaining;
    public int airShipsNumberRemaining;
    public GameObject playerShip;
    int playerHealth;

    void Start()
    {
        playerHealth = playerShip.GetComponent<PlayerMoveScript>().health;
    }

    void Update()
    {
        airShipsRemaining.text = "Number of practice airships remaining: " + airShipsNumberRemaining;
        healthRemaining.text = "Health: " + ( playerHealth / 10 );
    }
}
