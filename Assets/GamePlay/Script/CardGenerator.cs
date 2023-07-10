using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card
    {
        public Suit suit;
        public Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
    }

    public List<Card> deck = new List<Card>();

    private void Start()
    {
        GenerateDeck();
    }

    public void GenerateDeck()
    {
        deck.Clear();

        foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in System.Enum.GetValues(typeof(Rank)))
            {
                Card card = new Card(suit, rank);
                deck.Add(card);
            }
        }

        // Shuffle the deck (you can implement your own shuffling algorithm)
        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }
}
