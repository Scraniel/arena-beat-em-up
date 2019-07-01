public interface IEnemy
{
    int Life { get; }

    void TakeDamage(int damageAmount);
}
