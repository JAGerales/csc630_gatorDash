using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void setup(int timeScore)
    {
        gameObject.SetActive(true);
        pointsText.text = timeScore.ToString() + " Seconds";
    }
}
