using UnityEngine;
using UnityEngine.EventSystems;

public class DPadButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum Direction { Up, Down, Left, Right }
    public Direction buttonDirection;

    public PlayerMovement playerMovement;

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindAnyObjectByType<PlayerMovement>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerMovement == null) return;

        switch (buttonDirection)
        {
            case Direction.Up:
                playerMovement.MoveUp();
                break;
            case Direction.Down:
                playerMovement.MoveDown();
                break;
            case Direction.Left:
                playerMovement.MoveLeft();
                break;
            case Direction.Right:
                playerMovement.MoveRight();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.StopMove();
        }
    }
}