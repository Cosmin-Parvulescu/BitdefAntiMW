# BitdefAntiMW

An exercise in Inter Process Communication.

## AntiMW 

A **Python** 2.7 process runs multiple sub-processes simulating an anti malware solution (with realtime processes as well as on demand scanning) and exposes two **ZeroMQ** sockets. One such socket is open for basic API requests (start realtime, stop realtime, start ondemand, stop ondemand) and the other one is a PUB socket used to broadcast messages to any intested client. The communication encoding is done via **Protobuf**.

## .NET SDK

A **.NET Standard** project holds a core implementation of an API allowing clients to communicate with the Python process. It uses Protobuf to establish the connection rules between the Python process and .NET clients. The connection can either be REQ/RES - shortlived - and is used for simple requests, or a PUB/SUB connection which is long lived and opens a long running socket connection.

### CSharpAPI

The IPC process connection is left to this layer and here ZeroMQ is used to implement the in / out socket strategy

### Web

A WebAPI server exposing four endpoints for the four basic process operations.
