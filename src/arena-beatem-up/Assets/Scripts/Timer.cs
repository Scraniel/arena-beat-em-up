using UnityEngine;

public class Timer
{
    #region Fields
    /// <summary>
    /// The total time elapsed since the timer has been started.
    /// </summary>
    public float CurrentTime { get; private set; }
    public bool IsPaused {  get { return mIsActive; } }
    private bool mIsActive = false;
    #endregion

    /// <summary>
    /// Creates a new Timer instance.
    /// </summary>
    public Timer()
    {
        CurrentTime = 0;
    }

    /// <summary>
    /// Starts the timer. A call to update is still necessary.
    /// </summary>
    public void Start()
    {
        mIsActive = true;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void Stop()
    {
        mIsActive = false;
    }

    /// <summary>
    /// Resets the timer's time to 0. The timer does not pause/start.
    /// </summary>
    public void Reset()
    {
        CurrentTime = 0;
    }

    /// <summary>
    /// Updates the timer.
    /// </summary>
    public void Update()
    {
        if (mIsActive)
        {
            CurrentTime += Time.deltaTime;
        }
    }

    public void AddTime(float time)
    {
        CurrentTime += time;
    }
}
