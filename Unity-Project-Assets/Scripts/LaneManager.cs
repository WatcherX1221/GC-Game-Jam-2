using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] 
    GameObject trackManager;
    [SerializeField]
    GameObject laneObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CreateLanes()
    {
        int lanesGenerated = 0;
        float newLanePos = -trackManager.GetComponent<SongManager>().laneCount / 2;
        if(trackManager.GetComponent<SongManager>().laneCount%2==0)
        {
            for (int i = 0; trackManager.GetComponent<SongManager>().laneCount > i; i++)
            {
                GameObject newLane = Instantiate(laneObj, new Vector2(newLanePos, 0), transform.rotation);
                newLanePos++;
                lanesGenerated++;
            }
        }
    }
}
