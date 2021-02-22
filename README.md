# .NET Core + Azure Service Bus Sample
# Introduction 
A sample project to show how to use Azure Service Bus for queues in .NET Core on simple ConsoleApps (Consumer and Publisher).
The `Sender` project will send 10 messages to the queue, with messages string bodies like Message 1 to Message 10.
The `Consumer` project will process all messages from the queue and print the results.
# Build and Test
To run this project, just `git clone` it, use `dotnet run` on the .csproj folder, you can also configure visual studio to run both projects right clicking in `Solution > Properties > Multiple startup projects >  Check both projects and select 'Start'`

- [Azure Service Bus docs](https://docs.microsoft.com/pt-br/azure/service-bus-messaging/)