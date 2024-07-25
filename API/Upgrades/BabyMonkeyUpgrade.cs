using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using PathsPlusPlus;

namespace MonkeysGrow.API.Upgrades
{
    public class BabyMonkeyUpgrade : MultiUpgradePlusPlus<SizeChangingPath>
    {
        public override string Name => "Baby Monkey";
        public override int Cost => 500;

        public override string Icon => "1";
        public override int Tier => 1;

        public override string Description => "The monkey grows from the size of a smurf into the size of an infant!";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            SizeChangeHelper.SetSize(towerModel, 1f);
        }
        public override void OnUpgraded(Tower tower)
        {
            SizeChangeHelper.SellOverlappingTowers(tower);
        }
    }
}
