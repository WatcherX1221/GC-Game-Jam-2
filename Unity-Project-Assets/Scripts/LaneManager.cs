using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public GameObject trackManager;
    public GameObject laneObj;

    // Start is called before the first frame update
    void Start()
    {
        CreateLanes();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CreateLanes()
    {
        int lanesGenerated = 0;
        float newLanePos = -trackManager.GetComponent<SongManager>().laneCount / 2;
        int laneID = 0;
        if(trackManager.GetComponent<SongManager>().laneCount%2==0)
        {
            newLanePos += 0.5f;
            for (int i = 0; trackManager.GetComponent<SongManager>().laneCount > i; i++)
            {
                GameObject newLane = Instantiate(laneObj, new Vector2(newLanePos, 0), transform.rotation);
                newLane.GetComponent<Lane>().laneID = laneID;
                laneID++;
                newLanePos++;
                lanesGenerated++;
            }
        }
        else
        {
            for (int i = 0; trackManager.GetComponent<SongManager>().laneCount > i; i++)
            {
                GameObject newLane = Instantiate(laneObj, new Vector2(newLanePos, 0), transform.rotation);
                newLane.GetComponent<Lane>().laneID = laneID;
                laneID++;
                newLanePos++;
                lanesGenerated++;
            }
        }
        
    }
}
