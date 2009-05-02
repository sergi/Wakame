
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Wakame
{
    public static class TransactionListCacheManager
    {
        private static Hashtable _requests = new Hashtable();
        
        public static void addCacheRequest(string accountId, List<Transaction> request)
        {
            if (!_requests.ContainsKey(accountId))
                _requests.Add(accountId, request);
        }

        public static List<Transaction> getCacheRequest(string accountId)
        {
            if (_requests.ContainsKey(accountId))
                return (List<Transaction>)_requests[accountId];
            else
                return null;
        }
    }
}
