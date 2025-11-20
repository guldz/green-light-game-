using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatplayerscript : MonoBehaviour
{
    public float radius = 10;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject Square; 

    public GameObject SquareRef;

    public bool hasLineOfSight { get; private set; }

    void Start()
    {
        SquareRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOV();
        }
    }
    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                    hasLineOfSight = true;
                else
                    hasLineOfSight = false;
            }
            else
                hasLineOfSight = false;
        }
        else if (hasLineOfSight)
            hasLineOfSight = false;
    }


}








