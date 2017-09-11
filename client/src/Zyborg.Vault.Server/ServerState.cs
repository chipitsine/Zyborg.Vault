using System;

namespace Zyborg.Vault.Server
{
    public class ServerState
    {
        public string StorageRootPath
        { get; set; }

        public string StorageFilePath
        { get; set; }

        public string UnsealNonce
        { get; set; }

        public List<string> UnsealProgress
        { get; set; }

        public IEnumerable<byte[]> UnsealKeys
        { get; set; }

        public byte[] RootKey
        { get; set; }

        public byte[] RootToken
        { get; set; }

        public DurableServerState Durable
        { get; set; }
    }

    public class DurableServerState
    {
        public string ClusterId
        { get; set; }

        public string ClusterName
        { get; set; }

        public int SecretShares
        { get; set; }

        public int SecretThreshold
        { get; set; }

        public int? RootKeyTerm
        { get; set; }

        public DateTime? RootKeyInstallTime
        { get; set; }

        public byte[] RootKeyEncrypted
        { get; set; }

        public byte[] RootKeyHash
        { get; set; }

        public byte[] RootTokenHash
        { get; set; }
    }
}