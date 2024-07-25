using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PathsPlusPlus;

namespace MonkeysGrow.API.Upgrades
{
    public class GodzillaUpgrade : MultiUpgradePlusPlus<SizeChangingPath>
    {
        public override string Name => "Godzilla";
        public override int Cost => 20000;

        public override int Tier => 5;
        public override string Icon => "5";

        public override string Description => "Big chunky!";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            SizeChangeHelper.SetSize(towerModel, 16f);
        }
        public override void OnUpgraded(Tower tower)
        {
            SizeChangeHelper.SellOverlappingTowers(tower);
        }
    }
}
