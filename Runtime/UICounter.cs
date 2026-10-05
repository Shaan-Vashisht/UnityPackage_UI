using TMPro;
using UnityEngine;

namespace SV.UI
{
    [RequireComponent(typeof(TextMeshProUGUI)), AddComponentMenu("SV UI/Counter")]
    public class UICounter : MonoBehaviour
    {
        [SerializeField] 
        private int count;
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            text.text = count.ToString();
        }

        /// Increases the counter's value by one and updates the text.
        public void Increment()
        {
            count++;
            text.text = count.ToString();
        }

        /// Reduces the counter's value by one and updates the text.
        public void Decrement()
        {
            count--;
            text.text = count.ToString();
        }
    }
}
