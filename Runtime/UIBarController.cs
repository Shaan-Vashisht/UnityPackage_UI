using UnityEngine;
using UnityEngine.UI;

namespace SV.UI
{
    [AddComponentMenu("SV UI/Bar Controller"), SelectionBase]
    public class UIBarController : MonoBehaviour
    {
        [SerializeField] 
        private Sprite barSprite;
        [SerializeField] 
        private Color backgroundColor;
        [SerializeField, Tooltip("The color of the bar at each fill amount.")] 
        private Gradient barColor;
        [SerializeField, Range(0, 1)]
        private float minFill;
        
        [Header("Image Components")]
        [SerializeField] 
        private Image barBackgroundImage;
        [SerializeField] 
        private Image barImage;
        [SerializeField] 
        private Image maskImage;

        /// Updates the bar's fill amount and color.
        /// <param name="fill">How full the bar should be.</param>
        public void UpdateBar(float fill)
        {
            fill = Mathf.Clamp(fill, minFill, 1f);
            maskImage.fillAmount = fill;
            barImage.color = barColor.Evaluate(fill);
        }
    }
}
