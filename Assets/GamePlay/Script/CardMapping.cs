using UnityEngine;

[System.Serializable]
public class CardMapping : MonoBehaviour
{
    public CardData[] cardData; // Change the type to an array of CardData

    // You can also create a method to get the appropriate CardData based on a given index or any other identifier
    public CardData GetCardData(int index)
    {
        if (index >= 0 && index < cardData.Length)
        {
            return cardData[index];
        }
        else
        {
            Debug.LogError("Invalid index for CardData array: " + index);
            return null;
        }
    }
}
