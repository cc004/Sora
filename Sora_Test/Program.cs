using System.Threading.Tasks;
using Sora.Server;
using YukariToolBox.Console;
using YukariToolBox.Extensions;

namespace Sora_Test
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            //设置log等级
            ConsoleLog.SetLogLevel(LogLevel.Debug);

            //实例化服务器
            SoraWSServer server = new SoraWSServer(new ServerConfig {Port = 8080});

            #region 服务器事件处理

            //服务器连接事件
            server.ConnManager.OnOpenConnectionAsync += (connectionInfo, eventArgs) =>
                                                        {
                                                            ConsoleLog.Debug("Sora_Test",
                                                                             $"connectionId = {connectionInfo.Id} type = {eventArgs.Role}");
                                                            return ValueTask.CompletedTask;
                                                        };
            //服务器连接关闭事件
            server.ConnManager.OnCloseConnectionAsync += (connectionInfo, eventArgs) =>
                                                         {
                                                             ConsoleLog.Debug("Sora_Test",
                                                                              $"connectionId = {connectionInfo.Id} type = {eventArgs.Role}");
                                                             return ValueTask.CompletedTask;
                                                         };
            //服务器心跳包超时事件
            server.ConnManager.OnHeartBeatTimeOut += (connectionInfo, eventArgs) =>
                                                     {
                                                         ConsoleLog.Debug("Sora_Test",
                                                                          $"Get heart beat time out from[{connectionInfo.Id}] uid[{eventArgs.SelfId}]");
                                                         return ValueTask.CompletedTask;
                                                     };
            //群聊消息事件
            server.Event.OnGroupMessage += async (msgType, eventArgs) =>
                                           {
                                               ConsoleLog.Info("test", $"self msg = {eventArgs.IsSelfMessage}");
                                               if(eventArgs.IsSelfMessage) return;
                                               await eventArgs.SourceGroup.SendGroupMessage("好耶");
                                           };
            //私聊消息事件
            server.Event.OnPrivateMessage += async (msgType, eventArgs) =>
                                             {
                                                 await eventArgs.Sender.SendPrivateMessage("好耶");
                                             };
            #endregion

            //启动服务器并捕捉错误
            await server.StartServer().RunCatch(e => ConsoleLog.Error("Server Error", ConsoleLog.ErrorLogBuilder(e)));
        }
    }
}