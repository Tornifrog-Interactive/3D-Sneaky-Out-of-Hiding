using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider  collision)
    {
        if (collision.CompareTag("Player")) // Change "Player" to the tag of the object you want to collide with
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneName);
        }
    }
}
