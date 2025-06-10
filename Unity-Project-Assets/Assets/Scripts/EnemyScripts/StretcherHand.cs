using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretcherHand : MonoBehaviour
{
    public int attackLane;
    public int attackRow;
    GameObject songManager;
    public GameObject owningEnemy;
    public bool phantomAttack = false;
    public bool isEnd = false;
    SpriteRenderer sr;
    public Sprite end;
    public Sprite middle;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        songManager = GameObject.FindGameObjectWithTag("TrackManager");
    }
    private void Update()
    {
        if (owningEnemy == null)
        {
            Destroy(this.gameObject);
        }
        
        if(isEnd)
        {
            sr.sprite = end;
        }
        else
        {
            sr.sprite = middle;
        }
    }
}
    