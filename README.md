<h1 align="center">
	<br>
	Sora
	<h4 align="center">
        一个基于<a href="https://github.com/howmanybots/onebot">OneBot</a>协议的 <a href="https://dotnet.microsoft.com/download/dotnet/5.0">C#/.Net 5</a> 异步机器人开发框架
	</h4>
</h1>

----

框架现在已经做好了

不过还没写文档(在做了在做了)

## 我要怎么用

在nuget包管理器中搜索`Sora`然后安装就可以了

## 一个非常简陋的示例

先将就着看看吧.jpg

```c#
using System.Threading.Tasks;
using Sora;
using Sora.Tool;

namespace SoraExamples
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            SoraWSServer server = new SoraWSServer(new ServerConfig());
            server.OnOpenConnectionAsync += (id, eventArgs) =>
                                            {
                                                ConsoleLog.Debug("Sora_Test",$"selfId = {id} type = {eventArgs.Role}");
                                                return ValueTask.CompletedTask;
                                            };
            
            server.OnCloseConnectionAsync += (id, eventArgs) =>
                                             {
                                                 ConsoleLog.Debug("Sora_Test",$"selfId = {id} type = {eventArgs.Role}");
                                                 return ValueTask.CompletedTask;
                                             };
            server.Event.OnGroupMessage += async (sender, eventArgs) =>
                                           {
                                               //最简单的复读（x
                                               await eventArgs.Repeat();
                                           };
            await Task.Delay(-1);
        }
    }
}
```

## 开源协议

![AGPL](https://img.shields.io/github/license/CBGan/Sora?style=for-the-badge)