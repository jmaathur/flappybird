using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public float gravityScale = 2.5f;
    public LogicScript logic;
    public bool isAlive = true;
    public float deadZone = -10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody.gravityScale = gravityScale;
        myRigidBody.linearVelocity = Vector2.up * flapStrength;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            // Check for spacebar input (desktop)
            bool shouldFlap = Input.GetKeyDown(KeyCode.Space);

            // Check for touch/tap input (mobile)
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                shouldFlap = true;
            }

            // Check for mouse click (works for mobile web browsers too)
            if (Input.GetMouseButtonDown(0))
            {
                shouldFlap = true;
            }

            if (shouldFlap)
            {
                myRigidBody.linearVelocity = Vector2.up * flapStrength;
            }

            // Check if bird has fallen off screen
            if (transform.position.y < deadZone)
            {
                logic.gameOver();
                isAlive = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }
}
