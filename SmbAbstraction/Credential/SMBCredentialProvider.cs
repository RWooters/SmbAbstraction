﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SmbAbstraction
{
    public class SMBCredentialProvider : ISMBCredentialProvider
    {
        List<ISMBCredential> credentials = new List<ISMBCredential>();

        public SMBCredentialProvider()
        {
        }

        public ISMBCredential GetSMBCredential(string path)
        {
            var host = path.Hostname();
            var shareName = path.ShareName();

            var credential = credentials.Where(q => q.Host == host && q.ShareName == shareName).FirstOrDefault();
            if(credential != null)
            {
                return credential;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ISMBCredential> GetSMBCredentials()
        {
            return credentials;
        }

        public void AddSMBCredential(ISMBCredential credential)
        {
            credential.SetParentList(credentials);
            credentials.Add(credential);
        }
    }
}
