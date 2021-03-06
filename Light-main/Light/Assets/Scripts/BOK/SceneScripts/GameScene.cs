using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        int count = 1;
        SceneType = Define.Scene.Game;
        Managers.Map.LoadMap(1);

        GameObject player = Managers.Resource.Instantiate("Creature/Player");

        player.name = "Player";
        Managers.Object.Add(player);
        GameObject monster = Managers.Resource.Instantiate("Creature/Monster_Ming");
        monster.name = $"Monster_Ming{count}";
        MonsterMove mv = monster.GetComponent<MonsterMove>();
        Managers.Object.Add(monster);

    }
    //Managers.UI.ShowSceneUI<UI_Inven>();
    //Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
    //gameObject.GetOrAddComponent<CursorController>();

    //GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
    //Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

    ////Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
    //GameObject go = new GameObject { name = "SpawningPool" };
    //SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
    //pool.SetKeepMonsterCount(2);

    public override void Clear()
    {

    }
}
