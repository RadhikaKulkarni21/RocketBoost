using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    float movementFactor;

    [SerializeField] float speed;
    [SerializeField] Vector3 movementVector;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + movementVector;
    }

    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPos, endPos, movementFactor);
    }
}
