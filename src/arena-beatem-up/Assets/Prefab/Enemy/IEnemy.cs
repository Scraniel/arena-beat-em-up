public interface IEnemy
{
    int Life { get; }

    void Hit(int damageAmount);
}
