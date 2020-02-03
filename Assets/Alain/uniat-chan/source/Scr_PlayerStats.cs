using UnityEngine;

public class Scr_PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float hp;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int atk;

    [SerializeField]
    private float gold;

    public float getGold()
    {
        return gold;
    }

    public void SetGold(float _gold)
    {
        gold = _gold;
    }

    public int GetAtack()
    {
        return atk;
    }

    public void SetAtack(int _atk)
    {
        atk = _atk;
    }

    public float GetMaxHp()
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

    public float GetHP()
    {
        return hp;
    }

    public void SetHp(float _hp)
    {
        hp = _hp;
    }
}