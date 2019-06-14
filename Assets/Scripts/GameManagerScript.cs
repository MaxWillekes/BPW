using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public Text airShipsRemaining;
    public Text healthRemaining;
    public int airShipsNumberRemaining;
    public GameObject playerShip;
    int playerHealth;

    public GameObject StandardUI;
    public GameObject LostScreen;
    public GameObject VictoryScreen;

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        playerHealth = playerShip.GetComponent<PlayerMoveScript>().health;
        airShipsRemaining.text = "Number of airships remaining: " + airShipsNumberRemaining;
        healthRemaining.text = "Own airship integrity: " + ( playerHealth / 10) + "%";

        if (airShipsNumberRemaining <= 0)
        {
            StandardUI.SetActive(false);
            VictoryScreen.SetActive(true);
            Cursor.visible = true;
        }

        if (playerShip.GetComponent<PlayerMoveScript>().health <= 0 && playerShip.transform.position.y <= 15)
        {
            StandardUI.SetActive(false);
            LostScreen.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
