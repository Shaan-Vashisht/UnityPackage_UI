using UnityEngine;
using UnityEngine.EventSystems;

namespace SV.UI
{ 
    [AddComponentMenu("SV UI/Tooltip Controller")]
    public class TooltipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, TextArea]
        private string title;
        [SerializeField, TextArea]
        private string content;
        [SerializeField]
        private bool followCursor = true;
        [SerializeField]
        private Vector2 tooltipPos;
        [SerializeField]
        private UITooltip tooltip;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (followCursor)
                tooltip.ShowTooltip(title, content);
            else
                tooltip.ShowTooltip(title, content, tooltipPos);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.HideTooltip();
        }
    }
}
