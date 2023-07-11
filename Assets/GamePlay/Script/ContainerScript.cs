using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    private List<GameObject> cardsInContainer = new List<GameObject>();

    public void AddCardToContainer(GameObject card)
    {
        // Add the card to the container's list of cards
        cardsInContainer.Add(card);

        // You can perform any additional logic here, such as adjusting the card's position within the container
    }

    public void RemoveCardFromContainer(GameObject card)
    {
        // Remove the card from the container's list of cards
        cardsInContainer.Remove(card);

        // You can perform any additional logic here, such as updating the display or handling card removal effects
    }

    public GameObject GetRandomCard()
    {
        // Implement the logic to get a random card from the container
        // Return null if the container is empty or if there is an error
        if (cardsInContainer.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, cardsInContainer.Count);
        return cardsInContainer[randomIndex];
    }

    public GameObject GetTopCard()
    {
        // Implement the logic to get the top card from the container
        // Return null if the container is empty or if there is an error
        if (cardsInContainer.Count == 0)
        {
            return null;
        }

        return cardsInContainer[cardsInContainer.Count - 1];
    }
}
