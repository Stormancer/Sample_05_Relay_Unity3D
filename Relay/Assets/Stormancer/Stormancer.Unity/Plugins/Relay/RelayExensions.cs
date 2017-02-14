using Stormancer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Stormancer.Plugins.Relay
{
    public static class RelayExensions
    {
        public static void RelayRoute(this Scene scene, Action<Stream> writer, PacketReliability reliability = PacketReliability.RELIABLE_ORDERED)
        {
            scene.SendPacket("relay.route", s =>
            {
                s.WriteByte((byte)reliability);
                writer(s);
            }, reliability: reliability);
        }

        public static void RelayRoute<T>(this Scene scene, T data, PacketReliability reliability = PacketReliability.RELIABLE_ORDERED)
        {
            scene.RelayRoute(s => scene.Host.Serializer().Serialize(data, s), reliability);
        }

        public static void RelayRoute2Player(this Scene scene, long playerId, Action<Stream> writer, PacketReliability reliability = PacketReliability.RELIABLE_ORDERED)
        {
            scene.SendPacket("relay.route2player", s =>
            {
                s.WriteByte((byte)reliability);
                scene.Host.Serializer().Serialize(playerId, s);
                writer(s);
            }, reliability: reliability);
        }

        public static void RelayRoute2Player<T>(this Scene scene, long playerId, T data, PacketReliability reliability = PacketReliability.RELIABLE_ORDERED)
        {
            scene.RelayRoute2Player(playerId, s => scene.Host.Serializer().Serialize(data, s), reliability);
        }

        public static void RelayRouteNamed(this Scene scene, string route, Action<Stream> writer, PacketReliability reliability = PacketReliability.RELIABLE_ORDERED)
        {
            scene.SendPacket("relay.namedroute", s =>
            {
                s.WriteByte((byte)reliability);
                scene.Host.Serializer().Serialize(route, s);
                writer(s);
            }, reliability: reliability);
        }

        public static void RelayRouteNamed<T>(this Scene scene, string route, T data, PacketReliability reliability)
        {
            scene.RelayRouteNamed(route, s => scene.Host.Serializer().Serialize(data, s), reliability);
        }

        public static Task RelayRpc(this Scene scene, Action<Stream> writer)
        {
            //had to use a lambda here because otherwise Unity 3.4's compiler is to dumb to differenciate RpcVoid for RpcVoid<Action<Stream>>
            return scene.RpcVoid("relay.rpc", s => writer(s));
        }

        public static Task RelayRpc<T>(this Scene scene, T data)
        {
            return scene.RelayRpc(s => scene.Host.Serializer().Serialize(data, s));
        }

        public static Task RelayRpcNamed(this Scene scene, string route, Action<Stream> writer)
        {
            return scene.RpcVoid("relay.namedrpc", s =>
            {
                scene.Host.Serializer().Serialize(route, s);
                writer(s);
            });
        }

        public static Task RelayRpcNamed<T>(this Scene scene, string route, T data)
        {
            return scene.RelayRpcNamed(route, s =>
            {
                scene.Host.Serializer().Serialize(data, s);
            });
        }

        public static IObservable<Packet<IScenePeer>> RelayRpc2Player(this Scene scene, long playerId, Action<Stream> writer)
        {
            return scene.Rpc("relay.rpc2player", s =>
            {
                scene.Host.Serializer().Serialize(playerId, s);
                writer(s);
            });
        }

        public static IObservable<TResponse> RelayRpc2Player<TResponse>(this Scene scene, long playerId)
        {
            return scene.RelayRpc2Player(playerId, s => { })
                .Select(p => p.ReadObject<TResponse>());
        }

        public static IObservable<TResponse> RelayRpc2Player<TData, TResponse>(this Scene scene, long playerId, TData data)
        {
            return scene.RelayRpc2Player(playerId, s => scene.Host.Serializer().Serialize(data, s))
                .Select(p => p.ReadObject<TResponse>());
        }

        public static Task RelayRpc2PlayerVoid(this Scene scene, long playerId, Action<Stream> writer)
        {
            return scene.RpcVoid("relay.rpc2player", s =>
            {
                scene.Host.Serializer().Serialize(playerId, s);
                writer(s);
            });
        }

        public static Task RelayRpc2PlayerVoid(this Scene scene, long playerId)
        {
            return scene.RelayRpc2PlayerVoid(playerId, s => { });
        }

        public static Task RelayRpc2PlayerVoid<T>(this Scene scene, long playerId, T data)
        {
            return scene.RelayRpc2PlayerVoid(playerId, s => scene.Host.Serializer().Serialize(data, s));
        }

        public static Task<TResponse> RelayRpc2PlayerTask<TResponse>(this Scene scene, long playerId, Action<Stream> writer)
        {
            return scene.RpcTask<TResponse>("relay.rpc2player", s =>
            {
                scene.Host.Serializer().Serialize(playerId, s);
                writer(s);
            });
        }

        public static Task<TResponse> RelayRpc2PlayerTask<TResponse>(this Scene scene, long playerId)
        {
            return scene.RelayRpc2PlayerTask<TResponse>(playerId, s => { });
        }

        public static Task<TResponse> RelayRpc2PlayerTask<TData, TResponse>(this Scene scene, long playerId, TData data)
        {
            return scene.RelayRpc2PlayerTask<TResponse>(playerId, s => scene.Host.Serializer().Serialize(data, s));
        }

        public static IObservable<Packet<IScenePeer>> RelayRpc2PlayerNamed(this Scene scene, long playerId, string route, Action<Stream> writer)
        {
            return scene.Rpc("relay.namedrpc2player", s =>
            {
                var serializer = scene.Host.Serializer();
                serializer.Serialize(playerId, s);
                serializer.Serialize(route, s);
                writer(s);
            });
        }



        public static IObservable<TResponse> RelayRpc2PlayerNamed<TData, TResponse>(this Scene scene, long playerID, string route, TData data)
        {
            return scene.RelayRpc2PlayerNamed(playerID, route, s => scene.Host.Serializer().Serialize(data, s))
                .Select(p => p.ReadObject<TResponse>());
        }

        public static Task RelayRpc2PlayerNamedVoid(this Scene scene, long playerId, string route, Action<Stream> writer)
        {
            return scene.RpcVoid("relay.namedrpc2player", s =>
            {
                var serializer = scene.Host.Serializer();
                serializer.Serialize(playerId, s);
                serializer.Serialize(route, s);
                writer(s);
            });
        }

        public static Task RelayRpc2PlayerNamedVoid(this Scene scene, long playerId, string route)
        {
            return scene.RelayRpc2PlayerNamedVoid(playerId, route, s => { });
        }

        public static Task RelayRpc2PlayerNamedVoid<T>(this Scene scene, long playerId, string route, T data)
        {
            return scene.RelayRpc2PlayerNamedVoid(playerId, route, s => scene.Host.Serializer().Serialize(data, s));
        }

        public static Task<TResponse> RelayRpc2PlayerNamedTask<TResponse>(this Scene scene, long playerId, string route, Action<Stream> writer)
        {
            return scene.RpcTask<TResponse>("relay.namedrpc2player", s =>
            {
                var serializer = scene.Host.Serializer();
                serializer.Serialize(playerId, s);
                serializer.Serialize(route, s);
                writer(s);
            });
        }

        public static Task<TResponse> RelayRpc2PlayerNamedTask<TResponse>(this Scene scene, long playerId, string route)
        {
            return scene.RelayRpc2PlayerNamedTask<TResponse>(playerId, route, s => { });
        }

        public static Task<TResponse> RelayRpc2PlayerNamedTask<TData, TResponse>(this Scene scene, long playerId, string route, TData data)
        {
            return scene.RelayRpc2PlayerNamedTask<TResponse>(playerId, route, s => scene.Host.Serializer().Serialize(data, s));
        }

        public static void RelayRoute<T>(this Scene scene, Action<T> handler)
        {
            var relayService = scene.DependencyResolver.Resolve<RelayService>();

            relayService.RelayRouteCalled += packet =>
            {
                handler(packet.ReadObject<T>());
            };
        }

        public static void RelayRpc<TData>(this Scene scene, Func<TData, Task> handler)
        {
            var relayService = scene.DependencyResolver.Resolve<RelayService>();
            relayService.RelayRpcCalled = ctx =>
            {
                return handler(ctx.ReadObject<TData>());
            };
        }

        public static void RelayRpc<TData, TResponse>(this Scene scene, Func<TData, Task<TResponse>> handler)
        {
            var relayService = scene.DependencyResolver.Resolve<RelayService>();
            relayService.RelayRpcCalled = ctx =>
            {
                return handler(ctx.ReadObject<TData>())
                .Then(response => ctx.SendValue(response));
            };
        }
    }
}
