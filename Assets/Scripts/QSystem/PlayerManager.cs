using QFramework;
using QModel;
namespace QSystem
{
    public class PlayerManager: AbstractSystem
    {
        private PlayerData _playerData;
        private FighterData _fighterData;

        protected override void OnInit()
        {
            _playerData = this.GetModel<PlayerData>();
            _fighterData = this.GetModel<FighterData>();
        }
        
        // 拷贝玩家本地信息到战斗者信息中
        public void SetPlayerToFighter()
        {
            Fighter player = _fighterData.GetPlayer();
            player.curHp = _playerData.curHp;
            player.maxHp = _playerData.maxHp;
            player.curEnergy = _playerData.maxEnegry;
            player.maxEnergy = _playerData.maxEnegry;
        }

        public void ResetEnergy()
        {
            _fighterData.GetPlayer().curEnergy = _fighterData.GetPlayer().maxEnergy;
        }
    }
}