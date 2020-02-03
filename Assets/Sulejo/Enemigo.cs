using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public Slider healthBar;

    [SerializeField]
    private readonly float AllowedDistance = 2;

    private Scr_EnemyStats stats;
    private Transform Player;
    private Animator anim;
    private int atackid;

    [SerializeField]
    private int CP_ID;

    private Transform currentCP;
    private Scr_Chechpoint[] allCP;
    private Transform targetTrans;
    private float attackCD;
    private bool targetIsPlayer;
    public int spawnIndex;

    private void Start()
    {
        stats = this.GetComponent<Scr_EnemyStats>();
        attackCD = 2;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = this.GetComponent<Animator>();
        allCP = FindObjectsOfType<Scr_Chechpoint>();
        GetNextCheckP();
        targetIsPlayer = false;
    }

    private void Update()
    {
        if (stats.GetHP() > 0)
            Follow();
    }

    private void Follow()
    {
        targetIsPlayer = (Vector3.Distance(this.transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z)) <= 10);
        targetTrans = targetIsPlayer ? Player : currentCP;
        transform.LookAt(targetTrans);
        if (Vector3.Distance(this.transform.position, new Vector3(targetTrans.position.x, transform.position.y, targetTrans.position.z)) <= AllowedDistance)
        {
            if (targetIsPlayer)
            {
                anim.SetBool("Idle", true);
                Atack();
            }
            else if (CP_ID == 5 || CP_ID == 10)
            {
                if (Vector3.Distance(this.transform.position, new Vector3(targetTrans.position.x, transform.position.y, targetTrans.position.z)) <= AllowedDistance)
                {
                    Debug.Log("hp-1");
                    FindObjectOfType<GameManager>().damage();
                    Destroy(this.gameObject);
                }
            }
            else if (CP_ID - (spawnIndex * 5) < (allCP.Length / 2) + 1)
            {
                GetNextCheckP();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetTrans.position.x, transform.position.y, targetTrans.position.z), stats.GetSpeed());
            anim.SetBool("Idle", false);
        }
    }

    private void Atack()
    {
        if (attackCD < 0)
        {
            anim.SetTrigger("Attack");
            atackid = (atackid + 1) % 4;
            anim.SetFloat("AtackID", atackid);
            anim.SetBool("Idle", false);
            attackCD = 2;
            Player.GetComponent<Scr_PlayerControl>().GetHit(stats.GetAtack());
        }
        else
        {
            attackCD -= Time.deltaTime;
        }
    }

    public void getHit(int dmg)
    {
        if (stats.GetHP() <= 0)
            return;
        stats.SetHp(stats.GetHP() - dmg);
        healthBar.value = (float)stats.GetHP() / (float)stats.GetMaxHp();
        if (stats.GetHP() <= 0)
            Die();
    }

    private void Die()
    {
        anim.SetBool("Idle", false);
        anim.SetTrigger("Die");
        Player.GetComponent<Scr_PlayerControl>().GetMoney(15);
        Destroy(this.gameObject, 5);
    }

    private void GetNextCheckP()
    {
        foreach (var CP in allCP)
        {
            if (CP.index == CP_ID + (spawnIndex * 5))
            {
                currentCP = CP.GetComponent<Transform>();
                CP_ID++;
                return;
            }
        }
    }
}