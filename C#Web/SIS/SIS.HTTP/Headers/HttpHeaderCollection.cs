﻿using System;
using System.Collections.Generic;
using SIS.HTTP.Common;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection:IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            headers=new Dictionary<string, HttpHeader>();
        }
        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header,nameof(header));
            headers.Add(header.Key,header);
        }

        public bool ContainsHeader(string header)
        {
            CoreValidator.ThrowIfEmpty(header,nameof(header));
            return headers.ContainsKey(header);
        }

        public HttpHeader GetHeader(string header)
        {
            CoreValidator.ThrowIfEmpty(header,nameof(header));
            return headers[header];
        }

        public override string ToString()
        {
            return String.Join("\r\n",headers.Values);
        }
    }
}