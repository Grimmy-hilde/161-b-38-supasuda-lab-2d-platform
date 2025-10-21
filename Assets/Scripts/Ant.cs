using UnityEngine;

public class Ant : Enemy
{
    public Vector2 velosity;
    public Transform[] movePoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(20);

        DamageHit = 20;
        velosity = new Vector2(-1.0f, 0.0f);
    }

    public override void Behavior()
    {
        //move from current position
        rb.MovePosition(rb.position + velosity * Time.fixedDeltaTime);
        //move left และเกินขอบซ้าย
        if (velosity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }
        //move right และเกินขอบขวา
        if (velosity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }

    }
    public void Flip()
    {
        velosity.x *= -1; //change direction of movement
                          //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
        Behavior();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
