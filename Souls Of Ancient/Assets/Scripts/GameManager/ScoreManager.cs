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
    public int HealthPlayer =100;
    public Text healthText;
    public float HungerPlayer=100;
   public Text hungerText;
   
}
