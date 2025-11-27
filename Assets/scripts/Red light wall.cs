using UnityEngine;
using UnityEngine.UI;

public class RedLightGreenLight : MonoBehaviour
{
    public BoxCollider2D wall;
    public float greenTime = 3f;
    public float redTime = 3f;
    public float yellowTime = 1f; 

    public Image lightUI;          
    public Color greenColor = Color.green;
    public Color redColor = Color.red;
    public Color yellowColor = Color.yellow; 

    private bool isGreenLight = true;
    private bool isYellowLight = true; 

    void Start()
    {
        if (wall == null)
            wall = GetComponent<BoxCollider2D>();

        StartCoroutine(LightCycle());
    }

    private System.Collections.IEnumerator LightCycle()
    {
        while (true)
        {
            // GREEN 
            isGreenLight = true;
            wall.enabled = true;
            if (lightUI != null)
                lightUI.color = greenColor;

            yield return new WaitForSeconds(greenTime);

            //yellow
            isYellowLight = true;
            wall.enabled = true;
            if (lightUI != null)
                lightUI.color = yellowColor;

            yield return new WaitForSeconds(yellowTime);


            // RED 
            isGreenLight = false;
            wall.enabled = false;
            if (lightUI != null)
                lightUI.color = redColor;

            yield return new WaitForSeconds(redTime);

         

        }
    }
}






