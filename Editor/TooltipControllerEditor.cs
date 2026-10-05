using UnityEditor;
using UnityEngine;

namespace SV.UI.Editor
{
    [CustomEditor(typeof(TooltipController))]
    public class TooltipControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SerializedProperty title = serializedObject.FindProperty("title");
            SerializedProperty content = serializedObject.FindProperty("content");
            SerializedProperty follow = serializedObject.FindProperty("followCursor");
            SerializedProperty position = serializedObject.FindProperty("tooltipPos");
            SerializedProperty tooltip = serializedObject.FindProperty("tooltip");

            EditorGUILayout.PropertyField(title);
            EditorGUILayout.PropertyField(content);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(follow);
            if (!follow.boolValue)
                EditorGUILayout.PropertyField(position);
            
            EditorGUILayout.PropertyField(tooltip);

            serializedObject.ApplyModifiedProperties();
        }

        [MenuItem("GameObject/SV UI/Tooltip")]
        public static void Instantiate()
        {
            GameObject tooltip = Instantiate(Resources.Load<GameObject>("SV UI Tooltip"));
            tooltip.name = "Tooltip";

            Selection.activeObject = tooltip;
            
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null) tooltip.transform.SetParent(canvas.transform, false);
        }
    }
}