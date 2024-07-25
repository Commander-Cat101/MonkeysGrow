using PathsPlusPlus;
using System.Collections.Generic;

namespace MonkeysGrow.API
{
    public class SizeChangingPath : MultiPathPlusPlus
    {
        public override int UpgradeCount => 5;
        public override IEnumerable<string> Towers => MonkeysGrow.sizeChangeTowers;
    }
}
