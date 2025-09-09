using UnityEngine;
public class PlayerClamp : MonoBehaviour
{
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y),
            transform.position.z
        );
    }
}

