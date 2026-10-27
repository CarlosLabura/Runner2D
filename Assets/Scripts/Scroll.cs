using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Min(0)] public float ScrollSpeed;
    public bool Background = false;
    private int States = 1;
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x - Time.deltaTime * ScrollSpeed,
            transform.position.y,
            transform.position.z 
        );
        if (transform.position.x < -20)
            Destroy(gameObject, 2f);

        if (Background && States < 2)
        {
            float bounds = transform.position.x + GetComponent<SpriteRenderer>().bounds.extents.x * 2;
            if (bounds > 40)
                return;

            States += 1;
            Instantiate(gameObject, transform.position + new Vector3(GetComponent<SpriteRenderer>().bounds.extents.x * 2, 0f, 0f), Quaternion.identity);
        }
      
    }
}
