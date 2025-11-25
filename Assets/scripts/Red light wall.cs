using UnityEngine;
using UnityEngine.UI;

public class RedLightGreenLight : MonoBehaviour
{
    public BoxCollider2D wall;
    public float greenTime = 3f;
    public float redTime = 3f;

    public Image lightUI;          
    public Color greenColor = Color.green;
    public Color redColor = Color.red;

    private bool isGreenLight = true;

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
            // GREEN LIGHT
            isGreenLight = true;
            wall.enabled = true;
            if (lightUI != null)
                lightUI.color = greenColor;

            yield return new WaitForSeconds(greenTime);

            // RED LIGHT
            isGreenLight = false;
            wall.enabled = false;
            if (lightUI != null)
                lightUI.color = redColor;

            yield return new WaitForSeconds(redTime);
        }
    }
}






