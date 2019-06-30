using UnityEngine;
using System.Collections;

public class CooldownTimer
{
    #region Properties
 
    /// <summary>
    /// True whenever the cooldown timer mark hits the given time limit.
    /// </summary>
    public bool IsFinished { get { return mTimer.CurrentTime >= mTimeLimit;} }


    public float TimeLimit { get { return mTimeLimit; } }
    #endregion

    #region Fields
    /// <summary>
    /// The underlying timer used to calculate the current time.
    /// </summary>
    private Timer mTimer = new Timer();
    
    /// <summary>
    /// The time limit allocated. A running cooldown timer will be marked as finished
    /// once the current time surpasses this limit.
    /// </summary>
    private float mTimeLimit = 0;
    #endregion

    /// <summary>
    /// Creates a new CooldownTimer instance.
    /// </summary>
    public CooldownTimer()
    {
		mTimer.Start ();
    }

    /// <summary>
    /// The time limit of the cooldown timer. 
    /// This timer will be marked as finished once the hits this mark.
    /// </summary>
    /// <param name="timeLimit">The allocated time limit.</param>
    /// <param name="reset">Whether the timer should be reseted.</param>
    public void SetTimeLimit(float timeLimit, bool reset = true)
    {
        mTimeLimit = timeLimit;
        
        if(reset)
            mTimer.Reset();
    }


    /// <summary>
    /// Starts/Resumes the cooldown timer without reseting its state. 
    /// </summary>
    public void Start()
    {
        mTimer.Start();
    }
    
    /// <summary>
    /// Stops the cooldown timer without reseting its state.
    /// </summary>
    public void Stop()
    {
        mTimer.Stop();
    }

    public void Finish()
    {
        mTimer.AddTime(TimeLimit);
    }


    /// <summary>
    /// Updates the cooldown timer.
    /// </summary>
    public void Update()
    {
        mTimer.Update();
    }

    /// <summary>
    /// Resets the cooldown timer. Does not reset the time limit.
    /// </summary>
    public void Reset()
    {
        mTimer.Reset();
    }
}
