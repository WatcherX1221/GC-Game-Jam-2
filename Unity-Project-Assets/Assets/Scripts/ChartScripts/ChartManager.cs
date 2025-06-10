using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour
{
    public int currentBar;
    public int Bar;
    public List<int> chart = new List<int>();
    public GameObject lesser;
    public GameObject swapper;
    public GameObject phantom;
    public GameObject stretcher;
    public GameObject currentEnemy;
    GameObject songManager;
    // Start is called before the first frame update
    void Start()
    {
        songManager = GameObject.FindGameObjectWithTag("TrackManager");
        GetChart();
        GetBarEnemy();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && currentBar < chart.Count - 1)
        {
            currentBar++;
            Destroy(currentEnemy);
            GetBarEnemy();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && currentBar - 1 > -1)
        { 
            currentBar--;
            Destroy(currentEnemy);
            GetBarEnemy();
        }
    }

    public void GetChart()
    {
        string chartID = songManager.GetComponent<SongManager>().songID.ToString();
        List<string> chartStrings = new List<string>();
        chartStrings.AddRange(System.IO.File.ReadAllLines("Assets/Scripts/ChartScripts/Chart" + chartID + ".txt"));
        for(int i = 0; i < chartStrings.Count; i++)
        {
            int parsedChartValue = int.Parse(chartStrings[i]);
            chart.Add(parsedChartValue);
        }
        Debug.Log("Chart Pulled from: " + "Assets/Scripts/ChartScripts/Chart" + chartID + ".txt");
    }
    public void GetBarEnemy()
    {
        int currentBarChart = chart[currentBar];
        if(currentBarChart == 1)
        {
            GameObject newLesser = Instantiate(lesser, transform.position, transform.rotation);
            currentEnemy = newLesser;
        }
        else if (currentBarChart == 2)
        {
            GameObject newSwapper = Instantiate(swapper, transform.position, transform.rotation);
            currentEnemy = newSwapper;
        }
        else if (currentBarChart == 3)
        {
            GameObject newPhantom = Instantiate(phantom, transform.position, transform.rotation);
            currentEnemy = newPhantom;
        }
        else if (currentBarChart == 4)
        {
            GameObject newPhantom = Instantiate(stretcher, transform.position, transform.rotation);
            currentEnemy = newPhantom;
        }
    }
}
