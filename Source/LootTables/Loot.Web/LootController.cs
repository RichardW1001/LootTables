using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Loot.Web
{
    public class LootController : ApiController
    {
        private readonly LootTable _lootTable;

        public LootController()
        {
            var weightings = new List<ItemWeighting>
            {
                new ItemWeighting(new Item("Sword"), 10),
                new ItemWeighting(new Item("Shield"), 10),
                new ItemWeighting(new Item("Health Potion"), 30),
                new ItemWeighting(new Item("Resurrection Phial"), 30),
                new ItemWeighting(new Item("Scroll of wisdom"), 20)
            }; //TODO: Get these from a real place

            _lootTable = new LootTable(weightings, new RandomGenerator(), new DebugLogger()); //TODO: Dependency injection
        }

        [HttpGet]
        [Route("Loot/{playerName}")]
        public Item LootItem(string playerName)
        {
            try
            {
                return _lootTable.RollItem(playerName);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}