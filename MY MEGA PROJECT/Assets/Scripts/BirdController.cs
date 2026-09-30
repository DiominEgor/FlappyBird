using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D birdRb;

    [SerializeField] private int jumpForce;
    [SerializeField] private float gravityModifier;

    [SerializeField] private InputAction jumpAction;
    [SerializeField] private float maxUpRotation = 25f;
    [SerializeField] private float maxDownRotation = -25f;
    [SerializeField] private float rotationSpeed = 5f;

    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        birdRb = GetComponent<Rigidbody2D>();
        jumpAction.Enable();
        birdRb.gravityScale *= gravityModifier;
        birdRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && gameManager.isGameActive && transform.position.y < 3)
        {
            birdRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        float targetRotation;

        if (birdRb.linearVelocity.y > 0)
        {
            targetRotation = maxUpRotation;
        }
        else
        {
            targetRotation = maxDownRotation;
        }

        float currentRotation = transform.eulerAngles.z;

        float newRotation = Mathf.LerpAngle(
            currentRotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
        if (gameManager.isGameActive)
        {
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreTrigger"))
        {
            gameManager.ScoreCount();

        }

    }
}
