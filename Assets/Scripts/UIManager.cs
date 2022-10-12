using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private TMP_InputField SpawnTimeText;
    [SerializeField] private TMP_InputField SpeedCubeText;
    [SerializeField] private TMP_InputField DistanceErasingText;

    private void Awake()
    {
        SpawnTimeText.onValueChanged.AddListener(e => UpdateData());
        SpeedCubeText.onValueChanged.AddListener(e => UpdateData());
        DistanceErasingText.onValueChanged.AddListener(e => UpdateData());
       
    }
    private void Start()
    {
        UpdateData();
    }
    public void UpdateData()
    {
        float createTime = float.Parse(SpawnTimeText.text);
        float cubeSpeed = float.Parse(SpeedCubeText.text);
        int moveDistance = int.Parse(DistanceErasingText.text);

        if (createTime < 1f)
        {
            createTime = 1f;
            SpawnTimeText.text = createTime.ToString();
        }
        if (cubeSpeed < 1f)
        {
            cubeSpeed = 1f;
            SpeedCubeText.text = cubeSpeed.ToString();
        }
        if (moveDistance < 1)
        {
            moveDistance = 1;
            DistanceErasingText.text = moveDistance.ToString();
        }

        GameCoreSystem.instance.UpdateData(createTime, cubeSpeed, moveDistance); 
    }


   
}
