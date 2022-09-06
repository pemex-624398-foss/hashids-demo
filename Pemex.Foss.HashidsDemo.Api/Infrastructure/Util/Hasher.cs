using HashidsNet;
using Pemex.Foss.HashidsDemo.Api.Core.Util;

namespace Pemex.Foss.HashidsDemo.Api.Infrastructure.Util;

public class Hasher : IHasher
{
    private readonly IHashids _hashids;

    public Hasher()
    {
        _hashids = new Hashids(
            "sup3rS3cr3t",
            8,
            "ABCDEFGHJKLMNPQRSTUWXYZ0123456789"
            );
    }

    public string Encode(int number) => _hashids.Encode(number);
    public string Encode(long number) => _hashids.EncodeLong(number);
    
    public int DecodeInt(string hash) => _hashids.DecodeSingle(hash);
    public long DecodeLong(string hash) => _hashids.DecodeSingleLong(hash);
    
    public bool TryDecodeInt(string hash, out int number) => _hashids.TryDecodeSingle(hash, out number);
    public bool TryDecodeLong(string hash, out long number) => _hashids.TryDecodeSingleLong(hash, out number);
}