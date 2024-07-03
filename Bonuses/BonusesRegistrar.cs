using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic.Bonuses.Blocks;
using CodeBase.Logic.Bonuses.Mover;
using CodeBase.Logic.Particles;
using UnityEngine;

namespace CodeBase.Logic.Bonuses
{
    public class BonusesRegistrar : IBonusesRegistrar
    {
        private readonly IParticlesSpawnEventsHandlerService _eventsHandler;
        private readonly ISpawnableBlocksMover _blocksMover;
        private readonly ISaveLoadService _saveLoadService;

        public BonusesRegistrar(IParticlesSpawnEventsHandlerService eventsHandler, 
            ISpawnableBlocksMover blocksMover, ISaveLoadService saveLoadService)
        {
            _eventsHandler = eventsHandler;
            _blocksMover = blocksMover;
            _saveLoadService = saveLoadService;
        }

        public void RegisterBonusBlock(BonusBlock bonusBlock)
        {
            _eventsHandler.RegisterEmitter(bonusBlock);
            _saveLoadService.RegisterUpdater(bonusBlock);
            bonusBlock.OnDestroyed += UnregisterBonusBlock;
            _blocksMover.StartMoveBonusBlock(bonusBlock);
        }

        public void RegisterCurrencyBlock(CurrencyBlock currencyBlock, Vector3 finishPosition)
        {
            _eventsHandler.RegisterEmitter(currencyBlock);
            _blocksMover.StartMoveCurrencyBlock(currencyBlock, finishPosition);
            currencyBlock.OnDestroyed += UnregisterCurrencyBlock;
        }

        private void UnregisterBonusBlock(BonusBlock bonusBlock)
        {
            bonusBlock.OnDestroyed -= UnregisterBonusBlock;
            _eventsHandler.UnregisterEmitter(bonusBlock);
            _saveLoadService.UnregisterUpdater(bonusBlock);
        }

        private void UnregisterCurrencyBlock(CurrencyBlock currencyBlock)
        {
            currencyBlock.OnDestroyed -= UnregisterCurrencyBlock;
            _eventsHandler.UnregisterEmitter(currencyBlock);
        }
    }
}