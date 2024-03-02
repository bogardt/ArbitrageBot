# BinanceWebSocketApi

## Description

The `BinanceWebSocketApi` project facilitates efficient and simplified interaction with Binance's WebSockets for trading and real-time market data monitoring. This project aims to provide a high-level abstraction for managing WebSocket connections, listening to data streams, and asynchronously processing messages.

## Features

- Easy connection to Binance WebSocket streams for various data types (prices, orders, etc.).
- Handles automatic reconnections in case of connection loss.
- Abstraction for sending and receiving messages via WebSocket.
- Supports configuration through `appsettings.json` for easy customization.

## Prerequisites

- .NET 8
- A Binance account (optional for some public streams).

## Installation

1. Clone the repository to your local machine:

```bash
git clone https://github.com/bogardt/BinanceWebSocketApi.git
```

## Navigate to the project directory :
```bash
cd BinanceWebSocketApi
```
## Restore NuGet packages :
```bash
dotnet restore
```
## Build and run the project :
```bash
dotnet run
```

## Usage
Here is a simple example of using the API to listen to a real-time price stream:

```csharp
var api = new BinanceWebSocketApi();
api.SubscribeToPriceStream("BTCUSDT", price => {
    Console.WriteLine($"Current price of BTC/USDT: {price}");
});
```

## Contributing
Contributions are welcome! If you'd like to contribute, please fork the repository, create a feature branch for your contribution, and submit a pull request.

## License
This project is distributed under the MIT License. See the LICENSE file for more information.