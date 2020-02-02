using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private readonly float AllowedDistance = 2;

    private Scr_EnemyStats stats;
    private Transform Player;
    private Animator anim;
    private int atackid;
    private int CP_ID;
    private Transform currentCP;
    private Scr_Chechpoint[] allCP;
    private Transform targetTrans;
    private float attackCD;
    private bool targetIsPlayer;

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
                anim.SetBool("Idle", false);
                Atack();
            }
            else if (CP_ID < allCP.Length - 1)
            {
                GetNextCheckP();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetTrans.position.x, transform.position.y, targetTrans.position.z), stats.GetSpeed());
            anim.SetBool("Idle", true);
        }
    }

    private void Atack()
    {
        if (attackCD < 0)
        {
            anim.SetTrigger("Attack");
            atackid = (atackid + 1) % 4;
            anim.SetFloat("AtackID", atackid);
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
        if (stats.GetHP() <= 0)
            Die();
    }

    private void Die()
    {
        anim.SetTrigger("Die");
        Destroy(this.gameObject, 5);
    }

    private void GetNextCheckP()
    {
        foreach (var CP in allCP)
        {
            if (CP.index == CP_ID)
            {
                currentCP = CP.GetComponent<Transform>();
                CP_ID++;
                return;
            }
        }
    }
}