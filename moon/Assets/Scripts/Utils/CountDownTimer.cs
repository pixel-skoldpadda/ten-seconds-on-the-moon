using System;
using UnityEngine;

namespace Utils
{
    public class CountDownTimer
    {
        private float _coolDown;
        private bool _started;
        
        private Action _onExecute;
        private Action<float> _onUpdate;

        public CountDownTimer(float coolDown)
        {
            _coolDown = coolDown;
        }

        public void Update()
        {
            if (!_started)
            {
                return;
            }
            
            if (_coolDown <= 0f)
            {
                Stop();
            }
            else
            {
                _coolDown -= Time.deltaTime;
            }
            _onUpdate?.Invoke(_coolDown);
        }
        
        public void Start()
        {
            _started = true;
        }

        public void Destroy()
        {
            _onExecute = null;
            _onUpdate = null;
        }

        public Action OnExecute
        {
            get => _onExecute;
            set => _onExecute = value;
        }

        public Action<float> OnUpdate
        {
            get => _onUpdate;
            set => _onUpdate = value;
        }

        private void Stop()
        {
            _coolDown = 0f;
            _started = false;
            _onExecute?.Invoke();
        }
    }
}