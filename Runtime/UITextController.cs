using TMPro;
using UnityEngine;

namespace SV.UI
{
    [RequireComponent(typeof(TextMeshProUGUI)), AddComponentMenu("SV UI/Text Controller")]
    public class UITextController : MonoBehaviour
    {
        private TextMeshProUGUI text;
    
        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        /// Sets the text to the given message.
        /// <param name="message">The message to display.</param>
        public void SetText(string message)
        {
            text.text = message;
        }
        public void SetText(object message) => SetText(message.ToString());
        public void SetText(int message) => SetText(message.ToString());
        public void SetText(float message) => SetText(message.ToString());
        
        /// Sets the text's color to the given value.
        /// <param name="color">The color the text should be.</param>
        public void SetColor(Color color)
        {
            text.color = color;
        }
        public void SetColor(float r, float g, float b, float a = 1f) => SetColor(new Color(r, g, b, a));
        
        /// Sets the text's font size.
        /// <param name="size">The size the text should be.</param>
        public void SetSize(int size)
        {
            text.fontSize = size;
        }
    }
}
