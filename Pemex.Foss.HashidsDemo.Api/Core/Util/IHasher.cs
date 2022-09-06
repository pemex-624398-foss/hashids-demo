namespace Pemex.Foss.HashidsDemo.Api.Core.Util;

public interface IHasher
{
    string Encode(int number);
    string Encode(long number);
    int DecodeInt(string hash);
    long DecodeLong(string hash);
    bool TryDecodeInt(string hash, out int number);
    bool TryDecodeLong(string hash, out long number);
}