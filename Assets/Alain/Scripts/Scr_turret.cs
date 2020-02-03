using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scr_turret : MonoBehaviour
{
    public GameObject ray;
    public Slider healthBar;

    [SerializeField]
    private float range;

    [SerializeField]
    private float atackCD;

    [SerializeField]
    private int atack;

    [SerializeField]
    public float hp;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int detRate;

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
        }
        else
        {
            Atack();
        }
    }

    private void FindTarget()
    {
        Enemigo[] Enemies = FindObjectsOfType<Enemigo>();
        if (Enemies.Length == 0)
            return;

        Transform closest = null;
        float cDistance = Mathf.Infinity;

        foreach (var enemy in Enemies)
        {
            if (!closest || Vector3.Distance(enemy.transform.position, transform.position) < cDistance)
            {
                closest = enemy.transform;
                cDistance = Vector3.Distance(closest.position, transform.position);
            }
        }
        if (cDistance <= range)
            target = closest;
    }

    private void Atack()
    {
        transform.LookAt(new Vector3(target.position.x, this.transform.position.y, target.position.z));
        if (atackCD < 0)
        {
            ray.SetActive(true);
            StartCoroutine(disableFX());
            atackCD = 5;
            target.GetComponent<Enemigo>().getHit(atack);
            hp -= detRate;
            healthBar.value = hp / maxHp;
            if (hp <= 0)
                Die();
        }
        atackCD -= Time.deltaTime;
    }

    private IEnumerator disableFX()
    {
        yield return new WaitForSeconds(1);
        ray.SetActive(false);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void Repair(float health)
    {
        hp += health;
        if (hp > maxHp)
            hp = maxHp;
        healthBar.value = hp / maxHp;
    }
}