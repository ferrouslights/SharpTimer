using UnityEngine;

namespace ferrouslights.SharpTimer.Unity
{
    public class SampleScript : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private bool _logTick;
        [SerializeField] private bool _logComplete;

        private ITimer _timer;
        private bool _isRunning;

        private void OnEnable()
        {
            _timer?
                .RemoveCompletedListener(OnTimerComplete)
                .RemoveTickListener(OnTimerTick);

            _timer = new DurationTimer(_duration)
                .AddCompletedListener(OnTimerComplete)
                .AddTickListener(OnTimerTick)
                .Start();
            
            _isRunning = true;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            _timer.Update(Time.deltaTime);
        }

        private void OnTimerComplete()
        {
            _isRunning = _timer.IsActive;

            if (!_logComplete)
            {
                return;
            }

            Debug.Log("Timer Completed!");
        }

        private void OnTimerTick(float time)
        {
            if (!_logTick)
            {
                return;
            }

            Debug.Log($"Time: {time}");
        }
    }
}