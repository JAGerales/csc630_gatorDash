using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public timer gameTimer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameTimer.addTime();

            Destroy(gameObject);
        }
    }
}
