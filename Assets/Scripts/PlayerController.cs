using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Rigidbody rb;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.y);
        rb.AddForce(speed * moveDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = $"Score: {score}";
        }
        
    }

}
