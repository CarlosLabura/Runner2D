using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float ScrollSpeed;
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x - Time.deltaTime * ScrollSpeed,
            transform.position.y,
            transform.position.z 
        );
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject, 2f);
        }
    }
}
