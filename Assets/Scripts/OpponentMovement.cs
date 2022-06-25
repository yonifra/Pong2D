using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    [SerializeField] private GameObject puck;
    private Vector2 puckPosition;
    private Vector2 newPosition;

    void FixedUpdate()
    {
        puckPosition = puck.transform.position;
        newPosition = new Vector2(transform.position.x, puckPosition.y);
        
        transform.position = newPosition;
    }
}
