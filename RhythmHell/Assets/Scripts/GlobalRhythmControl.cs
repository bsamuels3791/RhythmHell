using UnityEngine;
using System.Collections;

public class GlobalRhythmControl : MonoBehaviour
{
    public static GlobalRhythmControl Instance;
    public static float globalOffset = 0;
	public static int finishedPizza = 0;
	public static int perfectCount = 0;
	public static int okayCount = 0;
	public static int score =0;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
