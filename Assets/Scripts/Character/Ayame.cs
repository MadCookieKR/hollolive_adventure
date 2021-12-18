using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayame : Character
{
    private Stats stats = new Stats("�ƾ߸�", 7, 100, 100, 100, 10);

    public override Stats getStats()
    {
        return stats;
    }

    public override void handleCommand(Command c)
    {
        switch (c)
        {
            case Command.Attack att:
                att.other.takeDamage(7);
                break;
        }
    }

    public override void takeDamage(int damage)
    {
        stats.hp.OnNext(Mathf.Max(0, damage));
        Debug.Log("ayame take " + damage + "damage!");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
