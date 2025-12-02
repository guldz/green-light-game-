using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
        {
            remainingTime = 0;
            SceneManager.LoadSceneAsync(3);
        }
           
       
            
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }




}
