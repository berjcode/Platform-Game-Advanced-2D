using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Dialog 1",menuName ="Dialog And Questler/Dialog")]
public class Dialog : ScriptableObject
{
   public int ID;
   public List<DialogText> dialogs = new List<DialogText>();
   

}
