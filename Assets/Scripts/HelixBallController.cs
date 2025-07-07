using UnityEngine;

public class HelixBallController : MonoBehaviour
{
    public float bounceForce = 9f;
    public float speedBoostForce = 16f;
    public GameManager gameManager;
    private Rigidbody rb;
    private bool speedBoosted = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        if (!gameManager) gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            Bounce();
#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            Bounce();
#endif
    }

    void Bounce() {
        float force = speedBoosted ? speedBoostForce : bounceForce;
        rb.velocity = new Vector3(rb.velocity.x, force, rb.velocity.z);
        if (speedBoosted) speedBoosted = false;
        gameManager?.OnBallBounce();
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Platform")) {
            speedBoosted = false;
        } else if (col.gameObject.CompareTag("SpeedBoost")) {
            speedBoosted = true;
            gameManager?.OnSpeedBoost();
            Destroy(col.gameObject);
        } else if (col.gameObject.CompareTag("Coin")) {
            gameManager?.AddCoins(1);
            Destroy(col.gameObject);
        }
    }
}
