using System;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Configs")]
    [Min(0)] public float JumpForce;
    public float Points;
    
    [Header("Objects Needed")]
    [SerializeField] private GameObject DeathParticles;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject GameOverUI;
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    private bool Jumped = false;
    private Vector3 OrginalScale;
    private float TargetAlpha = 1f;
    private bool Dead = false;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        OrginalScale = transform.localScale;
    }
    void Update()
    {
        if (!Dead) {
            Points += Time.deltaTime;
            UIText.SetText(Math.Truncate(Points).ToString());
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (!Jumped) {
                Rigidbody2D.AddForceY(JumpForce, ForceMode2D.Impulse);
                transform.localScale = new Vector3(OrginalScale.x * 0.75f, OrginalScale.y * 1.25f, OrginalScale.z);
                Jumped = true;
            }
        } else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow)) {
            if (Jumped) {
                Rigidbody2D.AddForceY(-0.1f, ForceMode2D.Impulse);
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(OrginalScale.x * 1.15f, OrginalScale.y * 0.85f, OrginalScale.z), Time.deltaTime * 5);
            } else {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(OrginalScale.x, OrginalScale.y * 0.5f, OrginalScale.z), Time.deltaTime * 5);
            }
        } else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, OrginalScale, Time.deltaTime * 5);
        }
        SpriteRenderer.color = Color.Lerp(SpriteRenderer.color, new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, TargetAlpha), Time.deltaTime * 5);

        if (Dead && Time.timeScale > 0) {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, Time.deltaTime);
            GameOverUI.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            Jumped = false;
        else if (collision.gameObject.CompareTag("Obstacle")) {
            TargetAlpha = 0;
            Rigidbody2D.bodyType = RigidbodyType2D.Static;
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject, 2f);
            Dead = true;
        }
    }
}
