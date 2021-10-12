using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    private float scorevalue;

    public float totalcoins;

    public float timeleft;

    public float timeRemaining;

    public Text ScoreText;
    public Text TimerText;

    public GameObject explosion;

    private float TimerValue;

    void Update()
    {
        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimerText.text = "Timer : " + timeRemaining.ToString();

        if(scorevalue==totalcoins)
        {
            if(timeleft<=TimerValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }

        else if(timeleft <=0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }

        ScoreText.text = "Score: " + scorevalue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Coin"))
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            scorevalue += 10;
            Destroy(collision.gameObject);
            if (scorevalue == totalcoins)
            {
                  SceneManager.LoadScene("GameWinScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Water"))
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
