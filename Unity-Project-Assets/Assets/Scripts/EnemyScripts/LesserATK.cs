using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserATK : MonoBehaviour
{
    public int attackLane;
    public int attackRow;
    GameObject songManager;
    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.FindGameObjectWithTag("TrackManager");
        ChoosePosition();
    }
    public void ChoosePosition()
    {
        List<GameObject> Lanes = new List<GameObject>();

        Lanes.AddRange(GameObject.FindGameObjectsWithTag("Lane"));

        attackLane = Random.Range(0, songManager.GetComponent<SongManager>().laneCount);

        for (int i = 0; i < Lanes.Count; i++)
        {
            if (Lanes[i].GetComponent<Lane>().laneID == attackLane)
            {
                transform.position = new Vector2(Lanes[i].transform.position.x, transform.position.y);
            }
        }
        attackRow = Random.Range(1, songManager.GetComponent<SongManager>().bpb);

        if(attackRow == 1)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row1").transform.position.y);
        }
        else if (attackRow == 2)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row1").transform.position.y);
        }
        else if (attackRow == 3)
        {
            transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Row1").transform.position.y);
        }
    }
}
