using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 4f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float z = Mathf.PingPong(Time.time * speed, distance * 2) - distance;

        transform.position = startPosition + new Vector3(0f, 0f, z);
    }
}