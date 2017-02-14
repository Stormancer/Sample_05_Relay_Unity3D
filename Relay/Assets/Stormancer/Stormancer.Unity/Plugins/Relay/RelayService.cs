using System;
using Stormancer.Core;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Stormancer.Plugins.Relay
{
    public class RelayService
    {
        private readonly ConcurrentDictionary<long, Player> _connectedPlayers = new ConcurrentDictionary<long, Player>();

        public RelayService(Scene scene)
        {

            scene.AddRoute<Player>("players.add", OnPlayerAdded);
            scene.AddRoute<long>("players.remove", OnPlayerRemoved);

            scene.AddRoute("relay.route", OnRelayRoute);
            scene.AddProcedure("relay.rpc", OnRpc);
        }


        public event Action<Player> PlayerConnected;
        public event Action<Player> PlayerDisconnected;

        public event Action<Packet<IScenePeer>> RelayRouteCalled;
        public Func<RequestContext<IScenePeer>, Task> RelayRpcCalled { get; set; }


        private Task OnRpc(RequestContext<IScenePeer> ctx)
        {
            var handler = RelayRpcCalled;
            if(handler != null)
            {
                return handler(ctx);
            }
            else
            {
                return TaskHelper.Completed;
            }
        }

        private void OnRelayRoute(Packet<IScenePeer> packet)
        {
            var action = RelayRouteCalled;
            if(action != null)
            {
                action(packet);
            }
        }

        private void OnPlayerAdded(Player player)
        {
            _connectedPlayers[player.ConnectionId]= player;
            var action = PlayerConnected;
            if(action != null)
            {
                action(player);
            }
        }

        private void OnPlayerRemoved(long playerId)
        {
            Player player;
            if(_connectedPlayers.TryRemove(playerId, out player))
            {
                var action = PlayerDisconnected;
                if(action != null)
                {
                    action(player);
                }
            }
        }
    }
}