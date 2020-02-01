using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

	public Transform ObjectToFollow = null;
	public float Speed =2;

    // Start is called before the first frame update

    void Start()
    {
        ObjectToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectToFollow == null)
	return;

	transform.position = Vector2.MoveTowards(transform.position, ObjectToFollow.transform.position, Speed *Time.deltaTime);
	transform.up = ObjectToFollow.position - transform.position ;
    }
}
