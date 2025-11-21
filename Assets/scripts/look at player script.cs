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
    public GameObject playerRef;
    private PlayerMovement PlayerMovement; 

    public bool hasLineOfSight { get; private set; }
    private float healthTimer;
    void Start()
    {        
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }
    void Update()
    {
        healthTimer -= Time.deltaTime;
        if (hasLineOfSight && healthTimer <= 0 
        && Square.GetComponent<PlayerMovement>().IsMoving) 
        {
            Square.GetComponent<PlayerMovement>().health--;
            healthTimer = 1;
            
        }
        
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

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFrameAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionFrameAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

        if (hasLineOfSight)
        {
            
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
            
        }
    }

    private Vector2 DirectionFrameAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad)); 
    }
}









