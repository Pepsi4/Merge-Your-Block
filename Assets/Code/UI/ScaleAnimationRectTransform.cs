using UnityEngine;
using DG.Tweening;

namespace TZ_24PLAY
{
    [RequireComponent(typeof(RectTransform))]
    public class ScaleAnimationRectTransform : MonoBehaviour
    {
        [SerializeField] private float _scaleTo = 1.5f;
        [SerializeField] private float _speedScale = 2f;
        private Tween _tween;
        private RectTransform _rect;

        private void Start()
        {
            _rect = this.GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _tween?.Kill();
            _tween = _rect.DOScale(new Vector3(_scaleTo, _scaleTo), _speedScale).SetSpeedBased(true).SetLoops(-1, LoopType.Yoyo);
            _tween.Play();
        }
    }
}