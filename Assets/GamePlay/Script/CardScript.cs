using UnityEngine;

public class CardScript : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 originalPosition;

    private string suit;
    private string rank;

    private ContainerScript drawCardContainer; // Reference to the drawCardContainer object

    public void SetCardData(string suit, string rank)
    {
        this.suit = suit;
        this.rank = rank;
        // Additional logic for updating the card's sprite or visual representation based on the suit and rank
    }

    private void Awake()
    {
        // Get the GameManager instance and access the drawCardContainer
        drawCardContainer = GameManager.instance.drawCardContainer;
    }

    private void OnMouseDown()
    {
        originalPosition = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Perform raycast to detect the target position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            // Check if the collider belongs to the drawCardContainer object
            if (hit.collider.gameObject == drawCardContainer.gameObject)
            {
                // Card is dropped into the drawCardContainer
                transform.position = drawCardContainer.transform.position;
            }
            else
            {
                // Card is dropped outside the drawCardContainer
                ResetCardPosition();
            }
        }
        else
        {
            // Card is dropped outside any collider
            ResetCardPosition();
        }
    }

    private void ResetCardPosition()
    {
        // Reset the card position to its original position
        transform.position = originalPosition;
    }
}
