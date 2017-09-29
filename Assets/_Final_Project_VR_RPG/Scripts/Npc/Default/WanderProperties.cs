using System;

[Serializable]
public class WanderProperties
{
    public float Radius    = 5f;
    public float Distance  = 1.5f;
    public float Jitter    = 0.5f;
    public float timeLimit = 5f;

    private float timeCounter = 0;

    public float getTimeCounter() { return timeCounter; }
    public void IncreaseTime(float increase) { this.timeCounter += increase; }
    public void resetTimeCounter() { timeCounter = 0; }
}