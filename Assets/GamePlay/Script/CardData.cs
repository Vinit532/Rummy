using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Custom/Card Data")]
public class CardData : ScriptableObject
{
    public string suit;
    public int rank;
    public GameObject cardPrefab;
}
