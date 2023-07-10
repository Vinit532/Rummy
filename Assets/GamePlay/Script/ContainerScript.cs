using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public List<GameObject> cardsInContainer = new List<GameObject>();

    public void AddCardToContainer(GameObject card)
    {
        // Add the card to the container's list of cards
        cardsInContainer.Add(card);

        // You can perform any additional logic here, such as adjusting the card's position within the container
    }
}
