using UnityEngine;

public class Scr_PlayerControl : MonoBehaviour
{
    private Animator anim;
    private float atackCD;
    private Scr_PlayerStats stats;
    private int running;

    private void Start()
    {
        stats = this.GetComponent<Scr_PlayerStats>();
        atackCD = 1.2f;
        anim = this.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
        atackCD -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Atack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Repair();
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
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 50);
        running = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        this.transform.Translate(this.transform.forward * stats.GetSpeed() * Time.deltaTime * Input.GetAxis("Vertical") * running);
        if (Input.GetAxis("Vertical") > 0)
            return;
        this.transform.Translate(this.transform.right * stats.GetSpeed() * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
    private void Atack()
    {
        if (atackCD > 0)
            return;
        atackCD = 1.2f;
        PerformAction("Atack");
    }

    private void Repair()
    {
        PerformAction("Repair");
    }

    private void Dance()
    {
        PerformAction("Dance");
    }

    private void Death()
    {
        PerformAction("Die");
    }

    private void PerformAction(string action)
    {
        anim.SetTrigger(action);
    }
}