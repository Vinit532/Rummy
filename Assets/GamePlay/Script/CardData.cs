using UnityEngine;
using UnityEditor;
using System.Reflection;

[CreateAssetMenu(fileName = "CardData", menuName = "Custom/Card Data")]
public class CardData : ScriptableObject
{
    public string suit;
    public string rank;
    public GameObject cardPrefab;

    // Editor-specific code
#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(CardData))]
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
#endif
}

public class CardDataEditorRuntime
{
    public static void OnInspectorGUI(UnityEngine.Object target)
    {
        var serializedObject = new UnityEditor.SerializedObject(target);

        var suitProperty = serializedObject.FindProperty("suit");
        UnityEditor.EditorGUILayout.PropertyField(suitProperty);

        var rankProperty = serializedObject.FindProperty("rank");
        UnityEditor.EditorGUILayout.PropertyField(rankProperty);

        var cardPrefabProperty = serializedObject.FindProperty("cardPrefab");
        UnityEditor.EditorGUILayout.PropertyField(cardPrefabProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
