using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ContainerScript playerContainer;
    public ContainerScript botContainer;
    public ContainerScript finishSlotContainer;
    public ContainerScript drawCardContainer;
    public GameObject cardPrefab; // Add this line to define the cardPrefab

    public void DiscardCard(GameObject card)
    {
        // Remove the card from the player's hand or the appropriate container
        ContainerScript container = card.GetComponentInParent<ContainerScript>();
        if (container != null)
        {
            container.RemoveCardFromContainer(card);
        }

        // Add the discarded card to the appropriate container
        finishSlotContainer.AddCardToContainer(card);

        // Implement any additional functionality related to discarding cards
        // For example, you can trigger the bot's turn or check the win condition here
        BotTurn();
        CheckWinCondition();
    }

    public void DrawCard()
    {
        // Handle the logic for drawing a new card
        // Instantiate a new card or retrieve a card from the deck
        // Add the card to the player's hand or the appropriate container
        GameObject newCard = InstantiateCard();
        playerContainer.AddCardToContainer(newCard);

        // Implement any additional functionality related to drawing cards
    }

    public void CheckWinCondition()
    {
        // Check the win condition, such as verifying if the player has formed valid sets or runs
        // Implement the logic for determining if the player has won the game
        // You can access the cards in the player's container and perform the necessary checks
        // For example, you can check if the player has formed valid melds or runs
        bool hasWon = CheckForWin(playerContainer);
        if (hasWon)
        {
            Debug.Log("Player has won the game!");
            // Implement any additional actions when the player wins
        }
    }

    private bool CheckForWin(ContainerScript container)
    {
        // Implement the logic to check for a win condition
        // You can iterate through the cards in the container and check for valid melds or runs
        // Return true if the win condition is met, otherwise return false
        return false; // Placeholder logic, replace with your own implementation
    }

    private void BotTurn()
    {
        // Implement the logic for the bot's turn
        // This can include actions such as discarding a card or drawing a card from the drawCardContainer
        // Adjust the bot's actions based on your game's rules and strategy
        GameObject cardToDiscard = botContainer.GetRandomCard();
        if (cardToDiscard != null)
        {
            // Remove the card from the bot's container and add it to the finishSlotContainer
            botContainer.RemoveCardFromContainer(cardToDiscard);
            finishSlotContainer.AddCardToContainer(cardToDiscard);
        }
        else
        {
            // Bot needs to draw a card from the drawCardContainer
            GameObject cardToDraw = drawCardContainer.GetTopCard();
            if (cardToDraw != null)
            {
                // Add the drawn card to the bot's container
                botContainer.AddCardToContainer(cardToDraw);

                // Remove the drawn card from the drawCardContainer
                drawCardContainer.RemoveCardFromContainer(cardToDraw);
            }
        }
    }

    private GameObject InstantiateCard()
    {
        // Implement the logic to instantiate a new card or retrieve a card from the deck
        // Adjust this code to match your game's card instantiation or retrieval mechanism
        GameObject card = Instantiate(cardPrefab, drawCardContainer.transform.position, Quaternion.identity);
        return card;
    }
}
