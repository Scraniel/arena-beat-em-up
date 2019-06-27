using UnityEngine;

public interface IWeapon 
{
    void Attack(Vector2 direction);
    void Bind(GameObject character);
}
