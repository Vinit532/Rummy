using System.Collections.Generic;
using UnityEngine;
using System;

public class CardDealer : MonoBehaviour
{
    public Dictionary<string, GameObject> cardPrefabMapping = new Dictionary<string, GameObject>(); // Mapping of suit and rank combinations to card prefabs
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
        // Generate a deck of cards based on the cardPrefabMapping
        foreach (var kvp in cardPrefabMapping)
        {
            string suit = kvp.Key.Split('_')[0]; // Extract the suit from the mapping key
            string rankString = kvp.Key.Split('_')[1]; // Extract the rank string from the mapping key

            int rank;
            if (int.TryParse(rankString, out rank)) // Try parsing the rank string as an integer
            {
                GameObject cardPrefab = kvp.Value;
                GameObject card = Instantiate(cardPrefab, transform.position, Quaternion.identity);

                CardScript cardScript = card.GetComponent<CardScript>();
                cardScript.SetCardData(suit, rank);

                deck.Add(card);
            }
            else
            {
                Debug.LogError("Invalid rank value: " + rankString);
            }
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
