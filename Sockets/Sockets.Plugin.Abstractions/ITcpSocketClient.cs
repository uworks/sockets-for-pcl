﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Sockets.Plugin.Abstractions
{
    /// <summary>
    ///     Sends and receives data over a TCP socket. Establish a connection with a listening TCP socket using
    ///     <code>ConnectAsync</code>.
    ///     Use the <code>WriteStream</code> and <code>ReadStream</code> properties for sending and receiving data
    ///     respectively.
    /// </summary>
    public interface ITcpSocketClient : IDisposable
    {
        /// <summary>
        ///     Establishes a TCP connection with the endpoint at the specified address/port pair.
        /// </summary>
        /// <param name="address">The address of the endpoint to connect to.</param>
        /// <param name="port">The port of the endpoint to connect to.</param>
        /// <param name="secure">Is this socket secure?</param>
        Task ConnectAsync(string address, int port, bool secure = false);

        /// <summary>
        ///     Disconnects from an endpoint previously connected to using <code>ConnectAsync</code>.
        ///     Should not be called on a <code>TcpSocketClient</code> that is not already connected.
        /// </summary>
        Task DisconnectAsync();

        /// <summary>
        ///     A stream that can be used for receiving data from the remote endpoint.
        /// </summary>
        Stream ReadStream { get; }

        /// <summary>
        ///     A stream that can be used for sending data to the remote endpoint.
        /// </summary>
        Stream WriteStream { get; }

        /// <summary>
        ///     The address of the remote endpoint to which the <code>TcpSocketClient</code> is currently connected.
        /// </summary>
        string RemoteAddress { get; }

        /// <summary>
        ///     The port of the remote endpoint to which the <code>TcpSocketClient</code> is currently connected.
        /// </summary>
        int RemotePort { get; }
    }
}