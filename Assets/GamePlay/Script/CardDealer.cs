using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public List<CardMapping> cardMappings;
    public Transform playerHand;
    public Transform botHand;
    public Transform faceDownSlot;
    public Transform boardImg; // Reference to the "Board_Img" object in the scene

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

                if (cardPrefab != null)
                {
                    GameObject card = Instantiate(cardPrefab, GetCardParent(suit));
                    card.transform.localPosition = Vector3.zero;

                    CardScript cardScript = card.GetComponent<CardScript>();
                    cardScript.SetCardData(suit, rank);

                    card.name = $"{suit}_{rank}"; // Set the card's name

                    deck.Add(card);
                }
                else
                {
                    Debug.LogError($"CardPrefab is not assigned for card: {suit}_{rank}");
                }
            }
        }
    }

    private Transform GetCardParent(string suit)
    {
        if (suit == "Player")
        {
            return playerHand;
        }
        else if (suit == "Bot")
        {
            return botHand;
        }
        else
        {
            return faceDownSlot;
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
        int numCardsPerHand = deck.Count / 4;

        // Shuffle the deck again before dealing
        ShuffleDeck();

        // Deal cards to the player's hand
        for (int i = 0; i < numCardsPerHand; i++)
        {
            GameObject card = deck[i];
            card.transform.SetParent(playerHand);
            card.transform.localPosition = Vector3.zero;
        }

        // Deal cards to the bot's hand
        for (int i = numCardsPerHand; i < numCardsPerHand * 2; i++)
        {
            GameObject card = deck[i];
            card.transform.SetParent(botHand);
            card.transform.localPosition = Vector3.zero;
        }

        // Set the remaining cards' parent to the faceDownSlot
        for (int i = numCardsPerHand * 2; i < deck.Count; i++)
        {
            GameObject card = deck[i];
            card.transform.SetParent(faceDownSlot);
            card.transform.localPosition = Vector3.zero;
        }
    }

}
