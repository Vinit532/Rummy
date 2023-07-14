using UnityEngine;

[System.Serializable]
public class CardMapping : MonoBehaviour
{
    public CardDataUI[] cardData; // Change the type to an array of CardDataUI

    // You can also create a method to get the appropriate CardDataUI based on a given index or any other identifier
    public CardDataUI GetCardData(int index)
    {
        if (index >= 0 && index < cardData.Length)
        {
            return cardData[index];
        }
        else
        {
            Debug.LogError("Invalid index for CardDataUI array: " + index);
            return null;
        }
    }
}
