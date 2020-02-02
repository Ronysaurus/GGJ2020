using UnityEngine;

public class Scr_PlayerControl : MonoBehaviour
{
    private Animator anim;
    private float atackCD;
    private Scr_PlayerStats stats;
    private int running;
    private bool deadeded;

    [SerializeField]
    private float camSpeed = 50;

    private void Start()
    {
        stats = this.GetComponent<Scr_PlayerStats>();
        atackCD = 1.2f;
        anim = this.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (deadeded)
            return;

        Move();
        atackCD -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Atack();
        }
        if (Input.GetMouseButton(1))
        {
            Repair();
            anim.SetBool("Repair", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Repair", false);
        }
        anim.SetFloat("Vertical", Input.GetAxis("Vertical") * running);
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }

    private void Move()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * camSpeed);
        running = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        this.transform.Translate(Vector3.forward * stats.GetSpeed() * Time.deltaTime * Input.GetAxis("Vertical") * running);
        if (Input.GetAxis("Vertical") > 0)
            return;
        this.transform.Translate(Vector3.right * stats.GetSpeed() * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    private void Atack()
    {
        if (atackCD > 0)
            return;
        atackCD = 1.2f;
        PerformAction("Atack");
        foreach (var enemy in FindObjectsOfType<Enemigo>())
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) <= 2)
            {
                enemy.getHit(stats.GetAtack());
            }
        }
    }

    public void GetHit(int dmg)
    {
        if (deadeded)
            return;

        stats.SetHp(stats.GetHP() - dmg);
        if (stats.GetHP() <= 0)
            Death();
    }

    private void Repair()
    {
    }

    private void Dance()
    {
        PerformAction("Dance");
    }

    private void Death()
    {
        deadeded = true;
        PerformAction("Die");
    }

    private void PerformAction(string action)
    {
        anim.SetTrigger(action);
    }
}