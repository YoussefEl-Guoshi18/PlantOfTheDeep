using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float leftBound = -3f; 
    public float rightBound = 3f; 

    private bool isMovingRight = true; 

    // Update is called once per frame
    void Update()
    {
        
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }

        
        if (transform.position.x <= leftBound || transform.position.x >= rightBound)
        {
            isMovingRight = !isMovingRight;
        }
    }
}
