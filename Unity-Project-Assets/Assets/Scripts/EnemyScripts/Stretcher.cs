using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : MonoBehaviour
{
    public int lane;
    GameObject songManager;
    public List<GameObject> lanes = new List<GameObject>();
    public int spawnedProjectiles;
    public GameObject attackObj;
    public List<GameObject> attacks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lanes.Count == 0)
        {
            lanes.AddRange(GameObject.FindGameObjectsWithTag("Lane"));
            songManager = GameObject.FindGameObjectWithTag("TrackManager");
            lane = Random.Range(0, songManager.GetComponent<SongManager>().laneCount);
            for (int i = 0; i < lanes.Count; i++)
            {
                if (lanes[i].GetComponent<Lane>().laneID == lane)
                {
                    transform.position = new Vector2(lanes[i].transform.position.x, 3.75f);
                }
            }
        }

        if (spawnedProjectiles == 0)
        {
            SpawnAttack();
        }
    }


    public void SpawnAttack()
    {
        int lanePos = 0;
        int beatPos = 1;
        for (int i = 0; beatPos <= songManager.GetComponent<SongManager>().bpb - 1; i++)
        {
            if (lanePos == lane)
            {
                GameObject attack = Instantiate(attackObj, transform.position, transform.rotation);
                spawnedProjectiles++;
                attack.GetComponent<Attack>().owningEnemy = this.gameObject;
                attack.GetComponent<Attack>().phantomAttack = true;
                attack.GetComponent<Attack>().attackRow = beatPos;
                attack.GetComponent<Attack>().attackLane = lanePos;
                attacks.Add(attack);
                lanePos++;
            }
            else
            {
                lanePos++;
            }

            if (lanePos == songManager.GetComponent<SongManager>().laneCount)
            {
                lanePos = 0;
                beatPos++;
            }
        }

        for (int i = 0; i < attacks.Count; i++)
        {
            if(i == attacks.Count - 1)
            {
                attacks[i].GetComponent<StretcherHand>().isEnd = true;
            }
            else
            {

            }
        }
    }
}
