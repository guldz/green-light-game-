using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winscreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(0); 
        }
    }
    
}
