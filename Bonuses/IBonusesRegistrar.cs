using CodeBase.Logic.Bonuses.Blocks;
using UnityEngine;

namespace CodeBase.Logic.Bonuses
{
    public interface IBonusesRegistrar
    {
        void RegisterBonusBlock(BonusBlock bonusBlock);
        void RegisterCurrencyBlock(CurrencyBlock currencyBlock, Vector3 finishPosition);
    }
}