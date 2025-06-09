using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    float size;
    public GameObject trackManager;
    // Start is called before the first frame update
    void Start()
    {
        trackManager = GameObject.FindGameObjectWithTag("TrackManager");
        size = trackManager.GetComponent<SongManager>().laneCount;
        transform.localScale = new Vector2(size, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
