using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    // Start is called before the first frame update
    public Bird[] birdList;
    private int index = -1;

    public int pigTotalCount;
    public int pigDeadCount;

    private FollowTarget cameraFollowTarget;
    public void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
    }
    void Start()
    {
        birdList = FindObjectsByType<Bird>(FindObjectsSortMode.None);
        pigTotalCount = (FindObjectsByType<Pig>(FindObjectsSortMode.None)).Length;
        cameraFollowTarget = Camera.main.GetComponent<FollowTarget>();

        birdList = birdList.OrderBy(obj => -obj.transform.position.x).ToArray();

        LoadNextBird();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextBird()
    {
        index++;
        if(index >= birdList.Length)
        {
            GameEnd();
        }
        else
        {
            birdList[index].GoStage(SlingShot.Instance.getCenterPosition());
            cameraFollowTarget.SetTarget(birdList[index].transform);
        }
        
    }
    public void OnPigDead()
    {
        pigDeadCount++;
        if(pigDeadCount >= pigTotalCount)
        {
            GameEnd();
        }
    }
    private void GameEnd()
    {
        print("gameover");
    }
}
