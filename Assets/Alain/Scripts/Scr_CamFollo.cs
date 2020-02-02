using UnityEngine;

public class Scr_CamFollo : MonoBehaviour
{
    private Transform playerTrans;

    [SerializeField]
    private readonly int distance = 2;

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        this.transform.position = new Vector3(playerTrans.transform.position.x, this.transform.position.y, playerTrans.transform.position.z) - (playerTrans.forward * distance);
        transform.LookAt(new Vector3(playerTrans.position.x, this.transform.position.y, playerTrans.transform.position.z));
    }
}