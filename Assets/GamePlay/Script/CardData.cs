using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "CardData", menuName = "Custom/Card Data")]
public class CardData : ScriptableObject
{
    public string suit;
    public string rank;
    public GameObject cardPrefab;
}

[CustomEditor(typeof(CardData))]
public class CardDataEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty suitProperty = serializedObject.FindProperty("suit");
        EditorGUILayout.PropertyField(suitProperty);

        SerializedProperty rankProperty = serializedObject.FindProperty("rank");
        EditorGUILayout.PropertyField(rankProperty);

        SerializedProperty cardPrefabProperty = serializedObject.FindProperty("cardPrefab");
        EditorGUILayout.PropertyField(cardPrefabProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
