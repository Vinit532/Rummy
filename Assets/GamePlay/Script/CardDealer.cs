using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public List<CardMapping> cardMappings;
    public Transform playerHand;
    public Transform botHand;

    private List<GameObject> deck = new List<GameObject>();

    private void Start()
    {
        GenerateDeck();
        DealCards();
    }

    private void GenerateDeck()
    {
        foreach (CardMapping mapping in cardMappings)
        {
            GameObject cardPrefab = mapping.cardData.cardPrefab;
            string suit = mapping.cardData.suit;
            int rank = mapping.cardData.rank;

            GameObject card = Instantiate(cardPrefab, transform.position, Quaternion.identity);

            CardScript cardScript = card.GetComponent<CardScript>();
            cardScript.SetCardData(suit, rank);

            deck.Add(card);
        }
    }

    private void DealCards()
    {
        // Deal cards to players
        for (int i = 0; i < 13; i++)
        {
            // Deal a card to the player's hand
            GameObject playerCard = deck[i];
            playerCard.transform.parent = playerHand;
            playerCard.transform.position = playerHand.position;

            // Deal a card to the bot's hand
            GameObject botCard = deck[i + 13];
            botCard.transform.parent = botHand;
            botCard.transform.position = botHand.position;
        }
    }
}
