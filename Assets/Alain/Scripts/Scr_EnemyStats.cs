using UnityEngine;

public class Scr_EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int atk;

    public int GetAtack()
    {
        return atk;
    }

    public void SetAtack(int _atk)
    {
        atk = _atk;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public void SetMaxHP(int _maxHP)
    {
        maxHp = _maxHP;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHp(int _hp)
    {
        hp = _hp;
    }
}