using DG.Tweening;
using Dialog;
using Loader;
using TMPro;
using UnityEngine;
using Utils;

namespace Ui
{
    public class GameOverlay : MonoBehaviour
    {
        private const string MenuScene = "MenuScene";

        [SerializeField] private SceneLoader sceneLoader;
        
        [Space(10)]
        [SerializeField] private TextMeshProUGUI timer;
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private CanvasGroup foreground;
        
        [Space(10)]
        [SerializeField] private float phraseInterval;
        [SerializeField] private Phrase firstPhrase;
        [SerializeField] private Phrase secondPhrase;

        [Space(10)]
        [SerializeField] private float timerCoolDown;

        private string _textBuffer;
        private Sequence _printTextSequence;

        private CountDownTimer _timer;
        
        private void Awake()
        {
            CreateAndStartTimer();
            StartPrintTextMessage();
        }

        private void CreateAndStartTimer()
        {
            _timer = new CountDownTimer(timerCoolDown);
            _timer.OnUpdate += DisplayTime;
            _timer.OnExecute += FadeScreen;
            _timer.Start();
        }

        private void Update()
        {
            _timer?.Update();
        }

        private void OnDestroy()
        {
            _printTextSequence.Kill();
            _printTextSequence = null;
            
            _timer.OnUpdate -= DisplayTime;
            _timer.OnExecute -= FadeScreen;
            _timer.Destroy();
            _timer = null;
        }

        private void FadeScreen()
        {
            foreground.DOFade(1f, 5f)
                .OnComplete(() =>
                {
                    sceneLoader.LoadScene(MenuScene);
                });
        }

        private void StartPrintTextMessage()
        {
            _printTextSequence = DOTween.Sequence()
                .Append(CreatePrintTextTween(firstPhrase))
                .AppendInterval(phraseInterval)
                .AppendCallback(CreateCleanTextCallback())
                .Append(CreatePrintTextTween(secondPhrase));
        }

        private TweenCallback CreateCleanTextCallback()
        {
            return () =>
            {
                _textBuffer = string.Empty;
                message.SetText(_textBuffer);
            };
        }

        private Tween CreatePrintTextTween(Phrase phrase)
        {
            return DOTween.To(() => _textBuffer, x => _textBuffer = x, phrase.Text, phrase.Duration)
                .OnUpdate(() =>
                {
                    message.SetText(_textBuffer);
                });
        }

        private void DisplayTime(float time)
        {
            float seconds = Mathf.FloorToInt(time % 60);
            float milliseconds = (int)(time * 1000f) % 100;
            timer.text = $"{seconds:00}.{milliseconds:00}";
        }
    }
}