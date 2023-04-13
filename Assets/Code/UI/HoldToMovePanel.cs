using UnityEngine;
using DG.Tweening;
using Zenject;
namespace TZ_24PLAY
{
    public class HoldToMovePanel : MonoBehaviour
    {
        private GameStateManager _gameStateManager;
        [SerializeField] private RectTransform _cursor;

        private const float CURSOR_MIN_POS_X = -160f;
        private const float CURSOR_SPEED = 160f;

        [Inject]
        private void Construct(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private void Start()
        {
            MoveCursor();
        }

        private void MoveCursor()
        {
            _cursor.transform.DOLocalMoveX(CURSOR_MIN_POS_X, CURSOR_SPEED).SetSpeedBased(true).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutBack);
        }

        private void Play()
        {
            _gameStateManager.UpdateGameState(GameState.Play);
        }

        private void Hide()
        {
            this.gameObject.SetActive(false);
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                OnInputHandle();
            }
#endif

            if (Input.touchCount > 0)
            {
                OnInputHandle();
            }
        }

        private void OnInputHandle()
        {
            Hide();
            Play();
        }
    }
}