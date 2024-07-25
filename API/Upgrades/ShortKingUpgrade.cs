using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PathsPlusPlus;

namespace MonkeysGrow.API.Upgrades
{
    public class ShortKingUpgrade : MultiUpgradePlusPlus<SizeChangingPath>
    {
        public override int Cost => 850;

        public override int Tier => 2;
        public override string Icon => "2";

        public override string Description => "The monkey grows from the size of a small infact into the size of an short monkey!";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            SizeChangeHelper.SetSize(towerModel, 2f);
        }

        public override void OnUpgraded(Tower tower)
        {
            SizeChangeHelper.SellOverlappingTowers(tower);
        }
    }
}
