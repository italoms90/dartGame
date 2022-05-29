using DartGame.Extensions;
using DartGame.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DartGame.Database
{
    public class MyDartGameDatabase
    {
        #region Private Fields

        private static readonly Lazy<SQLiteAsyncConnection> _lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
        });

        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
                
        private static bool _initialized = false;

        #endregion

        #region Properties 

        public static SQLiteAsyncConnection Database => _lazyInitializer.Value;

        #endregion

        #region Constructor

        public MyDartGameDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        #endregion

        #region Initialize

        public async Task InitializeAsync()
        {
            await _semaphoreSlim.WaitAsync().ConfigureAwait(false);

            try
            {
                if (!_initialized)
                {                     
                    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(GameConfig).Name))
                    {       
                        await Database.EnableWriteAheadLoggingAsync().ConfigureAwait(false);                                     
                        await Database.CreateTablesAsync(CreateFlags.None, typeof(GameConfig)).ConfigureAwait(false); 
                        _initialized = true;                       
                    }

                    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Player).Name))
                    {
                        await Database.EnableWriteAheadLoggingAsync().ConfigureAwait(false);
                        await Database.CreateTablesAsync(CreateFlags.None, typeof(Player)).ConfigureAwait(false);
                        _initialized = true; 
                    }
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        #endregion

        #region Player

        public Task<List<Player>> GetPlayersAsync()
        {
            return Database.Table<Player>().ToListAsync();
        }

        public Task<Player> GetPlayerAsync(int playerId)
        {
            return Database.Table<Player>().Where(p => p.PlayerId == playerId).FirstOrDefaultAsync();
        }

        public Task<int> InsertPlayerAsync(Player player)
        {
            return Database.InsertAsync(player);
        }

        public Task<int> UpdatePlayerAsync(Player player)
        {
            return Database.UpdateAsync(player);          
        }

        public Task<int> DeletePlayerAsync(Player player)
        {
            return Database.DeleteAsync(player);
        }

        #endregion

        #region GameConfig

        public Task<GameConfig> GetGameConfigAsync(int gameConfigId)
        {
            return Database.Table<GameConfig>().Where(i => i.GameConfigId == gameConfigId).FirstOrDefaultAsync();
        }

        public Task<int> SaveGameConfigAsync(GameConfig gameConfig)
        {
            var existingConfig = Database.Table<GameConfig>().Where(i => i.GameConfigId == gameConfig.GameConfigId)
                .FirstOrDefaultAsync().Result;
            if (existingConfig != null)
            {
                return Database.UpdateAsync(gameConfig);
            }
            else
            {
                return Database.InsertAsync(gameConfig);
            }
        }

        public Task<int> DeleteGameConfigAsync(GameConfig gameConfig)
        {
            return Database.DeleteAsync(gameConfig);
        }

        #endregion
    }
}
