using System;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;

namespace DPPStreamingClientExample
{
  class Program
  {
    static void Main(string[] args)
    {
      var opts = new IO.Options {ForceNew = true, Upgrade = true};
      var socket = IO.Socket("https://streams.dapowerplay.com?apikey=xxxxx-xxxx-xxxx-xxxx-xxxxxxxx&apisecret=xxxxx-xxxxxxx-xxxxxxx-xxxxxxx",opts);

      //example parameters
      var jsonParams =JsonConvert.DeserializeObject("[{ product: 'trades', exchange: 'bitstamp', base: 'BTC', quote: 'USD'}]");

      socket.On(Socket.EVENT_CONNECT, d =>
      {
        Console.WriteLine("Connected!");
        socket.Emit("subscribe", (err, stream) => { }, jsonParams);
      });

      socket.On("trades", trades => { Console.WriteLine(trades); });
      Console.ReadLine();
    }
  }
}
