using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogController : MonoBehaviour
{
public NpcDialogManager npc;
public bool inside;

public GameObject dialogUI;
public Text title;
public Text context;
public Image face;
public Button btn;

void Start()
{
    dialogUI.SetActive(false);
    btn.onClick.AddListener(NextDialog);
}
void Update()
{

  if(inside)
    {
        dialogUI.SetActive(true);
        title.text = npc.npcDialogs[npc.currentDialog].dialogs[npc.currentDialogText].Speaker.ToString();
        context.text = npc.npcDialogs[npc.currentDialog].dialogs[npc.currentDialogText].context;
        face.sprite = npc.npcIcon;
    }else if (!inside)
    {
        dialogUI.SetActive(false);
    }
}


private void OnTriggerStay2D(Collider2D col)
{
    if(col.gameObject.tag=="NPC")
    {
      //  npc = col.gameObject.GetComponent<NpcDialogManager>();
        inside = true;
    }
}

private void OnTriggerExit2D(Collider2D col)
{
if(col.gameObject.tag=="NPC")
    {
        
        inside = false;
    }
}


public void NextDialog()
{
    if(npc.currentDialogText < npc.npcDialogs[npc.currentDialog].dialogs.Count -1 )
    {
        npc.currentDialogText++;
    }else
    {
        npc.currentDialogText =0;
        if(npc.currentDialog < npc.npcDialogs.Count -1)
        {
            npc.currentDialog++;
        }else
        {
            dialogUI.SetActive(false);
        }
    }
}

   




}
