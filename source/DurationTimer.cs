namespace ferrouslights.SharpTimer
{
    public class DurationTimer : TimerBase
    {
        private float _duration;
        private bool _loopEnabled;
    
        public DurationTimer(float duration)
        {
            _duration = duration;
        }
    
        public DurationTimer SetLooping(bool isLooping)
        {
            _loopEnabled = isLooping;
            return this;
        }

        protected override void OnTimerCompleted()
        {
            InvokeCompletedEvent();

            if (_loopEnabled)
            {
                _elapsedTime = 0;
                _isComplete = false;
                return;
            }
        
            _isComplete = true;
            _isRunning = false;
        }

        public override bool IsComplete => _elapsedTime >= _duration;
    }
}