using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class ScaleButton : MonoBehaviour
    {
        [SerializeField] private float duration;

        private Tweener _scalePositiveTween;
        private Tweener _scaleNegativeTween;
        
        public void ScalePositive()
        {
            _scalePositiveTween = transform.DOScale(new Vector3(1.05f, 1.05f, 1), duration);
        }

        public void ScaleNegative()
        {
            _scaleNegativeTween = transform.DOScale(new Vector3(1f, 1f, 1f), duration);
        }

        private void OnDestroy()
        {
            _scaleNegativeTween.Kill();
            _scalePositiveTween.Kill();
        }
    }
}