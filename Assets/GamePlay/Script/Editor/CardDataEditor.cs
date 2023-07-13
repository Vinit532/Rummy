using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardData))]
public class CardDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CardData cardData = (CardData)target;

        cardData.suit = EditorGUILayout.TextField("Suit", cardData.suit);
        cardData.rank = EditorGUILayout.TextField("Rank", cardData.rank);

        cardData.cardPrefab = EditorGUILayout.ObjectField("Card Prefab", cardData.cardPrefab, typeof(GameObject), false) as GameObject;

        serializedObject.ApplyModifiedProperties();
    }
}
