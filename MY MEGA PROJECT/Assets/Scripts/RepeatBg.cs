using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    public int repeatitionDivide;
    private Vector3 startPosition;
    [SerializeField] private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / repeatitionDivide;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
