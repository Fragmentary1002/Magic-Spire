using QFramework;
using QModel;
namespace QSystem
{
    public class EnemyManager:AbstractSystem
    {
        private PlayerData _playerData;
        private FighterData _fighterData;

        protected override void OnInit()
        {
            _playerData = this.GetModel<PlayerData>();
            _fighterData = this.GetModel<FighterData>();
        }
        
        // 拷贝怪物本地信息到战斗者信息中
        public void SetEnemiesToFighter()
        {
           
        }
    }
}