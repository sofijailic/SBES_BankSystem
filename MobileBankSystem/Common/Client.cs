﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Client
    {
        /// <summary>
        /// Vraca proxy za komuniciranje sa bankom
        /// </summary>
        /// <returns></returns>
        public IBankConnection GetBankProxy()
        {
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBankConnection> factory = new ChannelFactory<IBankConnection>(binding,
            new EndpointAddress("net.tcp://localhost:65000/BankConnection"));
            IBankConnection proxy = factory.CreateChannel();
            return proxy;
        }

        /// <summary>
        /// Vraca proxy za komuniciranje sa klijentom
        /// </summary>
        /// <returns></returns>
        public IClientConnection GetClientProxy()
        {
            // Skontati kako da uzmemo port bas od tog klijenta koji je poslao zahtev, posto ne mozemo slati fiksno na 62000
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IClientConnection> factory = new ChannelFactory<IClientConnection>(binding,
            new EndpointAddress("net.tcp://localhost:62000/ClientConnection"));
            IClientConnection proxy = factory.CreateChannel();
            return proxy;
        }

        /// <summary>
        /// Vraca proxy za komuniciranje sa SOA Gateway-om
        /// </summary>
        /// <returns></returns>
        public IGatewayConnection GetGatewayProxy()
        {
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IGatewayConnection> factory = new ChannelFactory<IGatewayConnection>(binding,
            new EndpointAddress("net.tcp://localhost:63000/GatewayConnection"));
            IGatewayConnection proxy = factory.CreateChannel();
            return proxy;
        }

        /// <summary>
        /// Vraca proxy za komuniciranje sa Operatorom
        /// </summary>
        /// <returns></returns>
        public IOperatorConnection GetOperatorProxy()
        {
            // Skontati kako da uzmemo port bas od tog operatora koji je poslao zahtev, posto ne mozemo slati fiksno na 64000
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IOperatorConnection> factory = new ChannelFactory<IOperatorConnection>(binding,
            new EndpointAddress("net.tcp://localhost:64000/OperaterConnection"));
            IOperatorConnection proxy = factory.CreateChannel();
            return proxy;
        }
    }
}