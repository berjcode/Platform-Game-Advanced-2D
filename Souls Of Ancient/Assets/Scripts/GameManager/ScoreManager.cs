using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    public float HealthPlayer =100;
   public Text healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
