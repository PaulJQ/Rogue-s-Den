using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chef_Dialogue : Dialogue
{
    public Text dialogue;
    public int current;
    public string[] dialogues = { "Come now, pardner. Try out my new brew.","Feel free to take a swig.", "This stuff's great, I swear", "Won't cost ya more than a silver" };
    public override void clear()
    {
       dialogue.text = "";
    }


    //public override void speak(int i)
    //{
    //    dialogue.text = dialogues[i];
    //}
    public void speak()
    {
        dialogue.text = dialogues[current];
        current = (current +1) % 4;

    }
    // Start is called before the first frame update
    void Start()
    {
        dialogue_limit = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
