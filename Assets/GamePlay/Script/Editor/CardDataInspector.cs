using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardData))]
public class CardDataInspector : UnityEditor.Editor
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
