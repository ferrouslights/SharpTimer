using System;

namespace ferrouslights.SharpTimer
{
    public abstract class TimerBase : ITimer
    {
        protected bool _isRunning;
        protected bool _isPaused;
        protected bool _isComplete;
    
        protected float _elapsedTime;
        public abstract bool IsComplete { get; }
        
        public float ElapsedTime => _elapsedTime;

        public bool IsActive => _isRunning;

        public bool IsPaused => _isPaused;

        public ITimer SetTime(float time)
        {
            _elapsedTime = time;
            return this;
        }

        public event Action OnCompleted;
        public event Action<float> OnTick;

        public virtual ITimer Start()
        {
            _isRunning = true;
            return this;
        }

        public virtual ITimer Stop()
        {
            _isRunning = false;
            return this;
        }
    
        public virtual ITimer Pause()
        {
            _isPaused = true;
            return this;
        }

        public virtual ITimer Reset() => this;
        
        public virtual ITimer AddCompletedListener(Action callback)
        {
            OnCompleted += callback;
            return this;
        }
        
        public virtual ITimer AddTickListener(Action<float> callback)
        {
            OnTick += callback;
            return this;
        }
        
        public virtual ITimer RemoveCompletedListener(Action callback)
        {
            OnCompleted -= callback;
            return this;
        }
        
        public virtual ITimer RemoveTickListener(Action<float> callback)
        {
            OnTick -= callback;
            return this;
        }

        public virtual ITimer Update(float deltaTime)
        {
            if (!_isRunning || _isPaused)
            {
                return this;
            }
        
            _elapsedTime += deltaTime;
        
            OnTick?.Invoke(_elapsedTime);

            if (!IsComplete)
            {
                return this;
            }
        
            OnTimerCompleted();
        
            return this;
        }

        protected virtual void OnTimerCompleted()
        {
            _isComplete = true;
            _isRunning = false;
        
            InvokeCompletedEvent();
        }

        protected void InvokeCompletedEvent()
        {
            OnCompleted?.Invoke();
        }
    }
}