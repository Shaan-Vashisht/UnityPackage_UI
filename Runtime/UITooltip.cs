using TMPro;
using UnityEngine;

namespace SV.UI
{
    [RequireComponent(typeof(RectTransform)), AddComponentMenu("SV UI/Tooltip")]
    public class UITooltip : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI titleTMP;
        [SerializeField] 
        private TextMeshProUGUI contentTMP;
        
        private RectTransform rectTransform;
        private bool followCursor;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            HideTooltip();
        }

        private void Update()
        {
            if (followCursor)
                rectTransform.position = Input.mousePosition;
        }

        public void ShowTooltip(string title, string content, bool follow = true)
        {
            gameObject.SetActive(true);
            
            titleTMP.text = title;
            contentTMP.text = content;
            followCursor = follow;
        }
        public void ShowTooltip(string title, string content, Vector2 position)
        {
            ShowTooltip(title, content, false);
            rectTransform.anchoredPosition = position;
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
            followCursor = false;
        }
    }
}
