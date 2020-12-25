using Robust.Server.Interfaces.Player;
using Robust.Server.Player;
using Robust.Shared.Enums;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Interfaces.Map;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;

namespace Content.Server
{
    public class ExperienceManager
    {
        [Dependency] private IMapManager _mapManager = default!;
        [Dependency] private IEntityManager _entityManager = default!;
        [Dependency] private IPlayerManager _playerManager = default!;

        public MapId Map { get; private set; }

        public void Initialize()
        {
            // Create ingress point map.
            Map = _mapManager.CreateMap();
            var grid = _mapManager.CreateGrid(Map);
            
            grid.SetTile(new Vector2i(-1, -1), new Tile(0));
            grid.SetTile(new Vector2i(0, -1), new Tile(1));
            grid.SetTile(new Vector2i(1, -1), new Tile(0));

            grid.SetTile(new Vector2i(-1, 0), new Tile(1));
            grid.SetTile(new Vector2i(0, 0), new Tile(0));
            grid.SetTile(new Vector2i(1, 0), new Tile(1));

            grid.SetTile(new Vector2i(-1, 1), new Tile(0));
            grid.SetTile(new Vector2i(0, 1), new Tile(1));
            grid.SetTile(new Vector2i(1, 1), new Tile(0));
            // _mapManager.CreateNewMapEntity(IngressMap);

            // Setup join experience.
            _playerManager.PlayerStatusChanged += PlayerStatusChanged;
        }

        private void PlayerStatusChanged(object blah, SessionStatusEventArgs args)
        {
            if (args.NewStatus == SessionStatus.Connected)
            {
                // Setup an entity for the player...
                var playerEntity = _entityManager.SpawnEntity("Player", new EntityCoordinates(_mapManager.GetMapEntityId(Map), 0.5f, 0.5f));
                // This brings them into the InGame runlevel and to the InGame session status.
                args.Session.AttachToEntity(playerEntity);
                args.Session.JoinGame();
            }
        }
    }
}