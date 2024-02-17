using ArbitrageBot.Messages;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ArbitrageBot.WebSocket;

public class BinanceResponses
{
    internal readonly Subject<MiniTickerResponse> _miniTickerSubject = new();
    public IObservable<MiniTickerResponse> MiniTickerStream => _miniTickerSubject.AsObservable();
}
