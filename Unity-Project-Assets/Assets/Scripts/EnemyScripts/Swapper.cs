using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Swapper : MonoBehaviour
{
    public int lane;
    GameObject songManager;
    public List<GameObject> lanes = new List<GameObject>();
    public int spawnedProjectiles;
    public GameObject attackObj;
    public List<GameObject> attacks = new List<GameObject>();
    public int dir;
    SpriteRenderer sr;
    [SerializeField]
    Sprite faceLeft;
    [SerializeField]
    Sprite faceRight;
    // Start is called before the first frame update
    void Start()
    {
        spawnedProjectiles = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lanes.Count == 0)
        {
            lanes.AddRange(GameObject.FindGameObjectsWithTag("Lane"));
            songManager = GameObject.FindGameObjectWithTag("TrackManager");
            lane = Random.Range(0, songManager.GetComponent<SongManager>().laneCount);
            if(lane == 0)
            {
                dir = 1;
            }
            else if(lane == songManager.GetComponent<SongManager>().laneCount - 1)
            {
                dir = 0;
            }
            else
            {
                dir = Random.Range(0, 2);
            }
            for (int i = 0; i < lanes.Count; i++)
            {
                if (lanes[i].GetComponent<Lane>().laneID == lane)
                { 
                    transform.position = new Vector2(lanes[i].transform.position.x, 3.75f);
                }           
            }
        }


        if(dir == 0)
        {
            sr.sprite = faceLeft;
        }
        else if(dir == 1)
        {
            sr.sprite = faceRight;
        }

        if (spawnedProjectiles < songManager.GetComponent<SongManager>().laneCount - 1)
        {
            GameObject attack = Instantiate(attackObj, transform.position, transform.rotation);
            attack.GetComponent<Attack>().owningEnemy = this.gameObject;
            spawnedProjectiles++;
            attacks.Add(attack);
        }
    }
}
