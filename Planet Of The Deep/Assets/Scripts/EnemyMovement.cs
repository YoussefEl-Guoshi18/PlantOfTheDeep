using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float leftBound = -3f; 
    public float rightBound = 3f;
    public float scaleX = 0.2f;
    public float scaleY = 0.2f;

    private bool isMovingRight = true; 

    // Update is called once per frame
    void Update()
    {
        
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(scaleX,scaleY);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(-scaleX, scaleY);
        }

        
        if (transform.position.x <= leftBound || transform.position.x >= rightBound)
        {
            isMovingRight = !isMovingRight;
        }
    }
}
