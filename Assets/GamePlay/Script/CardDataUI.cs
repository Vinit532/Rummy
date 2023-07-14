using UnityEngine;

public class CardDataUI : MonoBehaviour
{
    public string rank;
    public string suit;
    public GameObject cardPrefab;

    public void SetCardData()
    {
        CardScript cardScript = cardPrefab.GetComponent<CardScript>();
        cardScript.SetCardData(suit, rank);
    }
}
