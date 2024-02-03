using System;

namespace ferrouslights.SharpTimer
{
    public interface ITimer
    {
        public event Action OnCompleted;
        public event Action<float> OnTick;
        public float ElapsedTime { get; }
        public bool IsActive { get; }
        public bool IsComplete { get; }
        public bool IsPaused { get; }
        public ITimer Start();
        public ITimer Stop();
        public ITimer Reset();
        public ITimer SetTime(float time);
        public ITimer Update(float deltaTime);
        public ITimer AddCompletedListener(Action callback);
        public ITimer RemoveCompletedListener(Action callback);
        public ITimer AddTickListener(Action<float> callback);
        public ITimer RemoveTickListener(Action<float> callback);
    }
}