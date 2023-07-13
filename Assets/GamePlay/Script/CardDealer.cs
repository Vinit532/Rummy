using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public List<CardMapping> cardMappings;
    public Transform playerHand;
    public Transform botHand;
    public Transform drawCardContainer;
    public Transform finishSlotContainer;
    public Transform faceDownSlot; // Reference to the "Face Down" slot

    private List<GameObject> deck = new List<GameObject>();

    private void Start()
    {
        GenerateDeck();
        ShuffleDeck();
        DealCards();
    }

    private void GenerateDeck()
    {
        foreach (CardMapping mapping in cardMappings)
        {
            foreach (CardData cardData in mapping.cardData)
            {
                GameObject cardPrefab = cardData.cardPrefab;
                string suit = cardData.suit;
                string rank = cardData.rank;

                GameObject card = Instantiate(cardPrefab, transform.position, Quaternion.identity);
                CardScript cardScript = card.GetComponent<CardScript>();
                cardScript.SetCardData(suit, rank);

                card.name = $"{suit}_{rank}"; // Set the card's name

                deck.Add(card);
            }
        }
    }

    private void ShuffleDeck()
    {
        // Shuffle the deck using Fisher-Yates algorithm
        int deckSize = deck.Count;
        for (int i = 0; i < deckSize - 1; i++)
        {
            int randomIndex = Random.Range(i, deckSize);
            GameObject temp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = temp;
        }
    }

    private void DealCards()
    {
        // Deal cards to players
        for (int i = 0; i < 13; i++)
        {
            // Deal a card to the player's hand
            GameObject playerCard = deck[i];
            playerCard.transform.SetParent(playerHand);
            playerCard.transform.localPosition = Vector3.zero;

            // Deal a card to the bot's hand
            GameObject botCard = deck[i + 13];
            botCard.transform.SetParent(botHand);
            botCard.transform.localPosition = Vector3.zero;
        }

        // Deal remaining cards to the face down slot
        for (int i = 26; i < deck.Count; i++)
        {
            GameObject faceDownCard = deck[i];
            faceDownCard.transform.SetParent(faceDownSlot);
            faceDownCard.transform.localPosition = Vector3.zero;
        }
    }
}
