# 🗳️ Live Polling SignalR API

A real-time voting and polling system demonstrating WebSockets and server-to-client broadcasting.

## 🚀 Key Features
- **Real-Time Updates**: Uses **SignalR** to push vote counts to all connected clients instantly.
- **Broadcasting Architecture**: Implements a `PollHub` for managing live connections.
- **Service Layer Pattern**: Business logic and SignalR broadcasting are isolated in a dedicated Service.
- **Interactive Frontend**: Includes a simple HTML/JS page to demonstrate live updates without refreshing.

## 🛠️ Technologies
- ASP.NET Core Web API
- SignalR
- C#
- Singleton In-Memory Storage

## 📖 How to Run
1. Clone the repo and open the solution in Visual Studio.
2. Run the project (**F5**).
3. Use Swagger to create a poll via `/api/Poll/create`.
4. Open `index.html` in multiple browser windows to see the live voting in action.
