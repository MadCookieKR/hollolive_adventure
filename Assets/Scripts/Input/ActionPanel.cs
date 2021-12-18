using System.Collections.Generic;
using UnityEngine;

public class ActionPanel : InputSource
{
    enum Selection
    {
        Fight, Bag, VMon,Run
    }
    /// <summary>
    /// 0--1
    /// 2--3
    /// </summary>
    public List<GameObject> arrows;
    private int selection = 0;

    public Character enemy;

    private void Start()
    {
        arrows.ForEach(delegate (GameObject go)
        {
            go.SetActive(false);
        });
        arrows[selection].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        int delta = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            delta = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            delta = -1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            delta = -2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            delta = +2;
        }

        if (delta != 0)
        {
            selection = Mathf.Clamp(selection + delta, 0, 3);
            arrows.ForEach(delegate (GameObject go)
            {
                go.SetActive(false);
            });
            arrows[selection].SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (selection)
            {
                case (int)Selection.Fight:
                    command.OnNext(new Command.Attack(enemy));
                    break;
                case (int)Selection.Bag:
                    command.OnNext(new Command.ShowBag());
                    break;
                case (int)Selection.VMon:
                    command.OnNext(new Command.ShowVMonBag());
                    break;
                case (int)Selection.Run:
                    command.OnNext(new Command.Run());
                    break;
            }
            
        }
    }
}
