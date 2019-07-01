using UnityEngine;

public class Bat : MonoBehaviour, IEnemy
{
    public float DirectionChangeTime = 3.0f;
    public float Speed = 0.1f;

    public int Life { get; private set; } = 1;

    private CooldownTimer _dirTimer = new CooldownTimer();
    private Vector3       _direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        _dirTimer.Update();

        if (_dirTimer.IsFinished)
            ChangeDirection();

        transform.position += _direction * Speed;
        
    }

    public void TakeDamage(int damageAmount)
    {
        Life -= damageAmount;

        if (Life <= 0)
            Kill();
    }

    public void Kill()
    {
        Debug.Log("Bat died!");
        Score.Instance.AddScore(1);
        Destroy(gameObject);
    }

    private void ChangeDirection() {
        _direction = GetRandomDirection();
        _dirTimer.SetTimeLimit(DirectionChangeTime);
    }

    public Vector3 GetRandomDirection()
        => new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f))
            .normalized
            .ToVector2();


}
