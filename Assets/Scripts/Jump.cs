using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Rigidbody2D.AddForceY(JumpForce);
    }
}
