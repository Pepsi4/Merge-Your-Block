using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace TZ_24PLAY
{
    public class FailPanel : MonoBehaviour
    {
        [SerializeField] private int _levelToLoad;
        [SerializeField] Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(OnRestartClick);
            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnRestartClick()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(_levelToLoad);
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.Fail)
                this._restartButton.gameObject.SetActive(true);
            else
                this._restartButton.gameObject.SetActive(false);
        }
    }
}