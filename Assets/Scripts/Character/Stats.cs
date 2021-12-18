using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Stats
{
    public string name;
    public Subject<int> attack;
    public Subject<int> maxHp;
    public Subject<int> hp;
    public Subject<int> maxExp;
    public Subject<int> exp;

    public Stats(string name, int attack, int maxhp, int hp, int maxExp, int exp)
    {
        this.name = name;
        this.attack = new Subject<int>();
        this.maxHp = new Subject<int>();
        this.hp = new Subject<int>();
        this.maxExp = new Subject<int>();
        this.exp = new Subject<int>();

        this.attack.OnNext(attack);
        this.maxHp.OnNext(maxhp);
        this.hp.OnNext(hp);
        this.maxExp.OnNext(maxExp);
        this.exp.OnNext(exp);
    }
}
