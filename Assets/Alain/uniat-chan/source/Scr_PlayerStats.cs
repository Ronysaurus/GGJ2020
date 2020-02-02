using UnityEngine;

public class Scr_PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private float atk;

    [SerializeField]
    private int gold;

    public int getGold()
    {
        return gold;
    }

    public void SetGold(int _gold)
    {
        gold = _gold;
    }

    public float GetAtack()
    {
        return atk;
    }

    public void SetAtack(float _atk)
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