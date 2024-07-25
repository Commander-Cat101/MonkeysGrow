using MelonLoader;
using BTD_Mod_Helper;
using MonkeysGrow;
using MonkeysGrow.API;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using System.Collections.Generic;
using Il2CppInterop.Runtime.Runtime.VersionSpecific.AssemblyName;
using Il2CppAssets.MainMenuWorld.Scripts;
using BTD_Mod_Helper.Api;
using System.Linq;
using PathsPlusPlus;

[assembly: MelonInfo(typeof(MonkeysGrow.MonkeysGrow), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MonkeysGrow;

public class MonkeysGrow : BloonsTD6Mod
{
    public static readonly List<string> sizeChangeTowers = new List<string>() { TowerType.DartMonkey, TowerType.BoomerangMonkey, TowerType.BombShooter, TowerType.TackShooter, TowerType.IceMonkey, TowerType.GlueGunner, 
        TowerType.SniperMonkey, TowerType.MonkeySub, TowerType.MonkeyBuccaneer, TowerType.MonkeyAce, TowerType.HeliPilot, TowerType.MortarMonkey, TowerType.DartlingGunner, 
        TowerType.WizardMonkey, TowerType.SuperMonkey, TowerType.Druid, TowerType.NinjaMonkey, TowerType.Alchemist, 
        TowerType.BananaFarm, TowerType.SpikeFactory, TowerType.MonkeyVillage, TowerType.EngineerMonkey, TowerType.BeastHandler };
    public override void OnApplicationStart()
    {
        ModHelper.Msg<MonkeysGrow>("MonkeysGrow loaded!");
    }
    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        base.OnTowerCreated(tower, target, modelToUse);
        var root = tower.rootModel.Duplicate().Cast<TowerModel>();
        tower.UpdateRootModel(root);
    }
    public override void OnMainMenu()
    {
        base.OnMainMenu();
        foreach (var tower in Game.instance.model.towers)
        {
            if (tower.IsBaseTower && sizeChangeTowers.Contains(tower.baseId))
            {
                SizeChangeHelper.SetSize(tower, 0.5f);
            }
        }
    }
    public override void OnTowerUpgraded(Tower tower, string upgradeName, TowerModel newBaseTowerModel)
    {
        base.OnTowerUpgraded(tower, upgradeName, newBaseTowerModel);
        if (tower.GetTier(3) == 0)
        {
            var root = tower.rootModel.Duplicate().Cast<TowerModel>();
            SizeChangeHelper.SetSize(root, 0.5f);
            tower.UpdateRootModel(root);
        }
    }
}