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
       // SortCardsBySuit();
    }

    private void GenerateDeck()
    {
        foreach (CardMapping mapping in cardMappings)
        {
            foreach (CardDataUI cardData in mapping.cardData)
            {
                GameObject cardPrefab = cardData.cardPrefab;
                string suit = cardData.suit;
                string rank = cardData.rank;

                GameObject card = Instantiate(cardPrefab, faceDownSlot);
                CardScript cardScript = card.GetComponent<CardScript>();
                cardScript.SetCardData(suit, rank);

                card.name = $"{rank}_{suit}";

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
            card.transform.localRotation = Quaternion.Euler(0, 0, 90); // Set rotation to (0, 0, 90) degrees
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
        // Get the cards from the playerHand
        CardScript[] playerCards = playerHand.GetComponentsInChildren<CardScript>();

        // Create a dictionary to store the cards for each suit
        Dictionary<string, List<CardScript>> suitCards = new Dictionary<string, List<CardScript>>();

        // Initialize the dictionary with empty lists for each suit
        suitCards.Add("HEART", new List<CardScript>());
        suitCards.Add("CLUB", new List<CardScript>());
        suitCards.Add("SPADE", new List<CardScript>());
        suitCards.Add("DIAMOND", new List<CardScript>());
        
       

        // Sort the player cards into their respective suit lists
        foreach (CardScript card in playerCards)
        {
            string suit = card.GetSuit().ToUpper(); // Convert the suit to uppercase
            if (suitCards.ContainsKey(suit))
            {
                Debug.Log("Suit: " + suit + ", Card Suit: " + card.Suit);

                suitCards[suit].Add(card);
            }
            else
            {
                Debug.LogError("Suit slot not found for suit: " + suit);
            }
        }

        // Move the sorted cards to their respective suit slots
        foreach (KeyValuePair<string, List<CardScript>> pair in suitCards)
        {
            string suit = pair.Key;
            List<CardScript> cards = pair.Value;

            Transform suitSlot = GetSuitSlot(suit);
            if (suitSlot != null)
            {
                foreach (CardScript card in cards)
                {
                    card.transform.SetParent(suitSlot);
                    card.transform.localPosition = Vector3.zero;
                }
            }
        }

        // Debug message after sorting cards
        Debug.Log("After sorting player hand:");
        foreach (CardScript card in playerCards)
        {
            Debug.Log($"{card.name} - Suit: {card.GetSuit()}, Rank: {card.GetRank()}");
        }
    }





    private Transform GetSuitSlot(string suit)
    {
        if (suit.Equals("HEART"))
            return heartSuitSlot;
        else if (suit.Equals("DIAMOND"))
            return diamondSuitSlot;
        else if (suit.Equals("CLUB"))
            return clubsSuitSlot;
        else if (suit.Equals("SPADE"))
            return spadeSuitSlot;
        else
            return null;
    }
}
