using UnityEngine;

public class Jump : MonoBehaviour
{
    [Min(0)] public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Rigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
    }
}
