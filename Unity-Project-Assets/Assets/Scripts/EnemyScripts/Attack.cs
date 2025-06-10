using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackLane;
    public int attackRow;
    GameObject songManager;
    public GameObject owningEnemy;
    public bool phantomAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.FindGameObjectWithTag("TrackManager");
        ChoosePosition();
    }
    private void Update()
    {
        if(owningEnemy == null)
        {
            Destroy(this.gameObject);
        }
    }
    public void ChoosePosition()
    {
        List<GameObject> Lanes = new List<GameObject>();

        Lanes.AddRange(GameObject.FindGameObjectsWithTag("Lane"));

        if (!phantomAttack)
        {
            attackRow = Random.Range(1, songManager.GetComponent<SongManager>().bpb);
            attackLane = Random.Range(0, songManager.GetComponent<SongManager>().laneCount);
        }

        for (int i = 0; i < Lanes.Count; i++)
        {
            if (Lanes[i].GetComponent<Lane>().laneID == attackLane)
            {
                transform.position = new Vector2(Lanes[i].transform.position.x, transform.position.y);
            }
        }

        if(attackRow == 1)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row1").transform.position.y);
        }
        else if (attackRow == 2)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row2").transform.position.y);
        }
        else if (attackRow == 3)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row3").transform.position.y);
        }
    }
}
