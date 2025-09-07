using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bump okay");
                break;

            case "Finish":
                Debug.Log("You've reached the end");
                break;

            case "Fuel":
                Debug.Log("Get the juice");
                break;

            default:
                //Debug.Log("Mayday");
                ReloadLevel();
                break;
        }
        
        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
