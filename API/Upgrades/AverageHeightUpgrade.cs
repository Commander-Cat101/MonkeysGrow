using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PathsPlusPlus;


namespace MonkeysGrow.API.Upgrades
{
    public class AverageHeightUpgrade : MultiUpgradePlusPlus<SizeChangingPath>
    {
        public override string Name => "Average Height";
        public override int Cost => 1500;

        public override string Icon => "3";
        public override int Tier => 3;

        public override string Description => "Just a normal monkey!";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            SizeChangeHelper.SetSize(towerModel, 4f);
        }
        public override void OnUpgraded(Tower tower)
        {
            SizeChangeHelper.SellOverlappingTowers(tower);
        }
    }
}
