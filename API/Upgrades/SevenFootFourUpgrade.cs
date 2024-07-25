using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PathsPlusPlus;

namespace MonkeysGrow.API.Upgrades
{
    public class SevenFootFourUpgrade : MultiUpgradePlusPlus<SizeChangingPath>
    {
        public override string Name => """7'4""";
        public override int Cost => 3000;

        public override int Tier => 4;
        public override string Icon => "4";

        public override string Description => "What a tall monkey!";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            SizeChangeHelper.SetSize(towerModel, 8f);
        }
        public override void OnUpgraded(Tower tower)
        {
            SizeChangeHelper.SellOverlappingTowers(tower);
        }
    }
}
