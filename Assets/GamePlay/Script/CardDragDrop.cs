using UnityEngine;

public class CardDragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 originalPosition;

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
            // Check if the collider belongs to a valid target position
            ContainerScript container = hit.collider.GetComponent<ContainerScript>();
            if (container != null)
            {
                // Card is dropped into a valid container
                container.AddCardToContainer(gameObject);
            }
            else
            {
                // Card is dropped outside a valid container
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
