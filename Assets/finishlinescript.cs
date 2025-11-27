using UnityEngine;
using UnityEngine.SceneManagement;
public class finishlinescript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("player touches finish line"); 
        }
        {
            SceneManager.LoadSceneAsync(2); 
        }
        
    }
}
