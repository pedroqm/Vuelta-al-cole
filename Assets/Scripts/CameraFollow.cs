using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float size, min, max;
    //public GameObject[] arrayTanks;
    public float timeC;
    public Vector3 velocity;
    private float distance;

    public int numPlayer;
    private GameObject player1, player2;


    //private List<GameObject> arrayPlayer;

    private void Start()
    {
        
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            //arrayPlayer.Add(player.gameObject);
        
    }

    void FixedUpdate()
    {

        Vector3 pos = (player1.transform.position + player2.transform.position) / 2;
        transform.parent.transform.position = pos;
        transform.parent.transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, timeC);

        distance = (player1.transform.position - player2.transform.position).magnitude;

        GetComponent<Camera>().orthographicSize = distance * size;
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize, min, max);
    }
}
