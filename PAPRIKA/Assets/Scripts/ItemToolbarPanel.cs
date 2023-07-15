using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemToolbarPanel : ItemPanel
{
   [SerializeField] public ToolbarController toolbarController;

   private void Start()
   {
       Init();
       toolbarController.onChange += Highlight;
       Highlight(0);
   }
   
    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
    }

    private int currentSelectedTool;
    
    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
