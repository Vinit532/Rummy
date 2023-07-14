using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    public List<CardMapping> cardMappings;
    public Transform playerHand;
    public Transform botHand;
    public Transform drawCardContainer;
    public Transform finishSlotContainer;
    public Transform heartSuitSlot;
    public Transform diamondSuitSlot;
    public Transform clubsSuitSlot;
    public Transform spadeSuitSlot;
    public Transform faceDownSlot;

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

                GameObject card = Instantiate(cardPrefab, playerHand);
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

    public void SortCardsBySuit()
    {
        // Sort the cards based on their suit
        List<GameObject> sortedCards = new List<GameObject>(deck);
        sortedCards.Sort((card1, card2) =>
        {
            string suit1 = card1.GetComponent<CardScript>().GetSuit();
            string suit2 = card2.GetComponent<CardScript>().GetSuit();
            return suit1.CompareTo(suit2);
        });

        // Assign the sorted cards to their respective suit slots
        foreach (GameObject card in sortedCards)
        {
            string suit = card.GetComponent<CardScript>().GetSuit();
            Transform suitSlot = FindSuitSlot(suit);
            if (suitSlot != null)
            {
                card.transform.SetParent(suitSlot);
                card.transform.localPosition = Vector3.zero;
            }
        }
    }

    private Transform FindSuitSlot(string suit)
    {
        // Find the suit slot based on the suit name
        Transform[] suitSlots = new Transform[] { diamondSuitSlot, clubsSuitSlot, spadeSuitSlot, heartSuitSlot };
        foreach (Transform slot in suitSlots)
        {
            if (slot.name.ToLower().Contains(suit.ToLower()))
            {
                return slot;
            }
        }
        return null;
    }


    private Transform GetSuitSlot(string suit)
    {
        switch (suit)
        {
            case "Diamond":
                return diamondSuitSlot;
            case "Clubs":
                return clubsSuitSlot;
            case "Spade":
                return spadeSuitSlot;
            case "Heart":
                return heartSuitSlot;
            default:
                return null;
        }
    }

}
