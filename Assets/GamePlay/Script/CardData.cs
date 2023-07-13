using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Custom/Card Data")]
public class CardData : ScriptableObject
{
    public string suit;
    public string rank;
    public GameObject cardPrefab;
}
