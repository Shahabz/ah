using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager s_instance;

	void Awake()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	public int day = 0;

	public delegate void NextDay();
	public NextDay OnNextDay;

    public float timeBonus = 30f;

    public void AddTime()
    {
        second += timeBonus;

    }

	void GotoNextDay () {
		OnNextDay ();
		day++;
	}

    public float second = 300;
    public Text timeDisplay;//, hourDisplay, minuteDisplay;

    void Update()
    {
        //second -= Time.deltaTime;
        //timeDisplay.text = (ReturnSecond() < 10) ? timeDisplay.text = ReturnMinute().ToString() + ":0" + ReturnSecond().ToString() : timeDisplay.text = ReturnMinute().ToString() + ":" + ReturnSecond().ToString();
    }

    public int ReturnSecond()
    {
        return ((int)(second % 60));
    }

    public int ReturnMinute()
    {
        return (Mathf.FloorToInt(second / 60));
    }
}
