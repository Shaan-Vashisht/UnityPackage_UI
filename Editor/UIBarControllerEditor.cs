using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SV.UI.Editor
{
    [CustomEditor(typeof(UIBarController))]
    public class UIBarControllerEditor : UnityEditor.Editor
    {
        private Sprite barSprite;
        private Color backgroundColor;
        private Gradient barColor;
        private float minFill;
        private Image barBackgroundImage;
        private Image barImage;
        private Image maskImage;

        public override void OnInspectorGUI()
        {
            barSprite = serializedObject.FindProperty("barSprite").objectReferenceValue as Sprite;
            backgroundColor = serializedObject.FindProperty("backgroundColor").colorValue;
            barColor = serializedObject.FindProperty("barColor").gradientValue;
            minFill = serializedObject.FindProperty("minFill").floatValue;
            barBackgroundImage = serializedObject.FindProperty("barBackgroundImage").objectReferenceValue as Image;
            barImage = serializedObject.FindProperty("barImage").objectReferenceValue as Image;
            maskImage = serializedObject.FindProperty("maskImage").objectReferenceValue as Image;
            
            DrawDefaultInspector();
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (!barBackgroundImage || !barImage || !maskImage) return;
            
            barBackgroundImage.sprite = barSprite;
            barBackgroundImage.color = backgroundColor;

            barImage.sprite = barSprite;
            barImage.color = barColor.Evaluate(minFill);

            maskImage.fillAmount = minFill;
        }
        
        [MenuItem("GameObject/SV UI/Line Bar")]
        public static void InstantiateLinear()
        {
            GameObject bar = Instantiate(Resources.Load<GameObject>("SV UI Line Bar"));
            bar.name = "Line Bar";
            
            Selection.activeObject = bar;
            
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null) bar.transform.SetParent(canvas.transform, false);
        }

        [MenuItem("GameObject/SV UI/Circular Bar")]
        public static void InstantiateCircular()
        {
            GameObject bar = Instantiate(Resources.Load<GameObject>("SV UI Circular Bar"));
            bar.name = "Circular Bar";

            Selection.activeObject = bar;
            
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null) bar.transform.SetParent(canvas.transform, false);
        }
    }
}
