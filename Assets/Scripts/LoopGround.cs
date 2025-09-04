using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 6f;

    private SpriteRenderer spriteRenderer;

    private Vector2 startSize;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = spriteRenderer.size;
    }

    void Update()
    {
        spriteRenderer.size += Vector2.right * speed * Time.deltaTime;

        if (spriteRenderer.size.x >= width)
        {
            spriteRenderer.size = startSize;
        }
    }
}
