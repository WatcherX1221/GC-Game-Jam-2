using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartManager : MonoBehaviour
{
    public int currentBar;
    public int Bar;
    public List<int> chart = new List<int>();
    public GameObject lesser;
    public GameObject currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        GetChart();
        GetBarEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && currentBar + 1 <= chart.Count)
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
        List<string> chartStrings = new List<string>();
        chartStrings.AddRange(System.IO.File.ReadAllLines("Assets/Scripts/ChartScripts/Chart1.txt"));
        for(int i = 0; i < chartStrings.Count; i++)
        {
            int parsedChartValue = int.Parse(chartStrings[i]);
            chart.Add(parsedChartValue);
        }
    }
    public void GetBarEnemy()
    {
        int currentBarChart = chart[currentBar];
        if(currentBarChart == 1)
        {
            GameObject newLesser = Instantiate(lesser, transform.position, transform.rotation);
            currentEnemy = newLesser;
        }
    }
}
