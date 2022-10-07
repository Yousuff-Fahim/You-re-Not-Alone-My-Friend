using UnityEngine;

public class PlayerFallTrigger : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        }
    }
}
