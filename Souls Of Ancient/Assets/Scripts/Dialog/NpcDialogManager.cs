using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogManager : MonoBehaviour
{
    public List<Dialog> npcDialogs = new List<Dialog>();
    public int currentDialog;
    public int currentDialogText;
    public Sprite npcIcon;
}
