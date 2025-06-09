using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesser : MonoBehaviour
{
    public int lane;
    GameObject songManager;
    public List<GameObject> lanes = new List<GameObject>();
    public int spawnedProjectiles;
    public GameObject lesserProj;
    public List<GameObject> attacks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lanes.Count == 0)
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

        if(spawnedProjectiles < (songManager.GetComponent<SongManager>().bpb - 1) / 2)
        {
            GameObject lesserAttack = Instantiate(lesserProj, transform.position, transform.rotation);
            spawnedProjectiles++;
            attacks.Add(lesserAttack);
        }
    }
    private void OnDestroy()
    {
        for (int i = 0;i < attacks.Count;i++)
        {
            Destroy(attacks[i]);
            attacks.Remove(attacks[i]);
        }
    }
}
