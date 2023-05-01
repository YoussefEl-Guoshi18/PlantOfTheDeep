using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed = 5.0f;  
    public float chargeTime = 2.0f;  
    public float slamForce = 10.0f;  
    public float slamRadius = 2.0f;  
    public LayerMask playerLayer;  
    public Transform player;  

    private bool isCharging = false;  
    private Vector3 chargeDirection;  
    private Rigidbody2D rb;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = Vector2.zero;
    }

    void Update()
    {
        if (!isCharging && Vector2.Distance(transform.position, player.position) < 10.0f)
        {
            
            isCharging = true;
            chargeDirection = (player.position - transform.position).normalized;
            StartCoroutine(Charge());
        }
    }

    IEnumerator Charge()
    {

        rb.velocity = chargeDirection * speed;
        yield return new WaitForSeconds(chargeTime);

       
        rb.velocity = Vector2.zero;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, slamRadius, playerLayer);
        foreach (Collider2D hit in hits)
        {
            Rigidbody2D hitRb = hit.GetComponent<Rigidbody2D>();
            if (hitRb != null)
            {
                hitRb.AddForce((hit.transform.position - transform.position).normalized * slamForce, ForceMode2D.Impulse);
            }
        }


        isCharging = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slamRadius);
    }
}
