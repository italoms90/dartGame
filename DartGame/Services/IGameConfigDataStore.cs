using DartGame.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartGame.Services
{
    public interface IGameConfigDataStore
    {
        Task<bool> UpdateGameConfigAsync(GameConfig item);
    }
}
