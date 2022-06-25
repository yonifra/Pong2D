using TMPro;
using UnityEngine;

public class PuckMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float puckSpeed;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject opponent;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI opponentScoreText;
    private AudioSource audioSource;
    private Rigidbody2D puckRigidbody;
    private float xSlope, ySlope;
    private int opponentScore, playerScore;
    private Vector2 initialPuckPosition, initialPlayerPosition, initialOpponentPosition;
    
    void Start()
    {
        puckRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        initialPuckPosition = transform.position;
        initialPlayerPosition = player.transform.position;
        initialOpponentPosition = opponent.transform.position;

        // TODO: Maybe randomize this later?
        xSlope = 1;
        ySlope = 1;
    }
    
    void FixedUpdate()
    {
        puckRigidbody.velocity = new Vector2(xSlope * puckSpeed, ySlope*puckSpeed);
    }

    void RepositionObjects()
    {
        transform.position = initialPuckPosition;
        player.transform.position = initialPlayerPosition;
        opponent.transform.position = initialOpponentPosition;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Debug.Log("Collision with " + otherCollider.name);
        audioSource.Play();
        switch (otherCollider.name)
        {
            case "ColliderUp":
                ySlope = -1;
                break;
            case "ColliderDown":
                ySlope = 1;
                break;
            case "ColliderLeft":
                opponentScore++;
                opponentScoreText.text = opponentScore.ToString();
                RepositionObjects();
                break;
            case "ColliderRight":
                playerScore++;
                playerScoreText.text = playerScore.ToString();
                RepositionObjects();
                break;
            case "Opponent":
            case "Player":
                xSlope *= -1;
                break;
        }
    }
}
