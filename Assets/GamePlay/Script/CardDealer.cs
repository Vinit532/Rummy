using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public CardGenerator cardGenerator;
    public int numberOfCardsToDeal = 13;
    public int numberOfPlayers = 2;
    public List<List<CardGenerator.Card>> playersCards = new List<List<CardGenerator.Card>>();

    private void Start()
    {
        cardGenerator = GetComponent<CardGenerator>();
        DealCards();
    }

    private void DealCards()
    {
        cardGenerator.GenerateDeck();
        playersCards.Clear();

        // Initialize card arrays/lists for players
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playersCards.Add(new List<CardGenerator.Card>());
        }

        // Deal cards to each player
        for (int i = 0; i < numberOfCardsToDeal; i++)
        {
            for (int j = 0; j < numberOfPlayers; j++)
            {
                CardGenerator.Card card = cardGenerator.deck[0];
                playersCards[j].Add(card);
                cardGenerator.deck.RemoveAt(0);
            }
        }

        // Call a separate method to display the player's cards on the screen
        DisplayPlayersCards();
    }

    private void DisplayPlayersCards()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Debug.Log("Player " + (i + 1) + " Cards: ");
            foreach (CardGenerator.Card card in playersCards[i])
            {
                Debug.Log(card.rank + " of " + card.suit);
            }
        }
    }
}
