using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System.Numerics;


namespace MonkeysGrow.API
{
    public static class SizeChangeHelper
    {
        public static void SellOverlappingTowers(Tower tower)
        {
            foreach (var tts in InGame.instance.bridge.GetAllTowers().ToList())
            {
                if (tts.tower.Id == tower.Id)
                    continue;

                if (tower.GetTowerToSim().simPosition.ToVector2().Distance(tts.simPosition.ToVector2()) <= (tts.tower.towerModel.radius / 2 + tower.towerModel.radius / 2) * 1.80)
                {
                    tts.tower.SellTower();
                }
            }
        }
        public static void SetSize(TowerModel tower, float modifier)
        {
            if (tower.displayScale != 1)
                ChangeSize(tower, 1 / tower.displayScale);

            ChangeSize(tower, modifier);

        }
        private static void ChangeSize(TowerModel tower, float modifier)
        {
            tower.GetDescendants<AttackModel>().ForEach(a => a.range *= modifier);
            tower.range *= modifier;

            tower.GetDescendants<WeaponModel>().ForEach(a => a.rate /= modifier);

            tower.displayScale *= modifier;
            tower.radius *= modifier;
            tower.radiusSquared = tower.radius * tower.radius;

            tower.GetDescendants<CircleFootprintModel>().ForEach(footprint => footprint.radius *= modifier);

            tower.GetDescendants<RectangleFootprintModel>().ForEach(footprint =>
            {
                footprint.xWidth *= modifier;
                footprint.yWidth *= modifier;
            });
        }
    }
}
