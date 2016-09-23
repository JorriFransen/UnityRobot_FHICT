﻿using Communication;
using UnityEngine;

namespace Networking
{
    public class Communicator : MonoBehaviour, IMessageSender
    {
        private IPresentationProtocol _pp;
        private IDataLink _datalink;

        public Communicator(IDataLink dataLink, IPresentationProtocol pP)
        {
            if (pP == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "pP");
            }

            if (dataLink == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "dataLink");
            }

            _pp = pP;
            _datalink = dataLink;
        }

        public bool SendCommand(Message message)
        {
            bool success = false;

            byte[] values = _pp.MessageToBinaryData(message);

            if(values.Length > 0)
            {
                if (_datalink.Connected())
                {
                    success = _datalink.SendData(values);
                }
            }

            return success;
        }
    }
}