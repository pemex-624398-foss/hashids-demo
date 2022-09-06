// See https://aka.ms/new-console-template for more information

using HashidsNet;

var hashids = new Hashids(
    "sup3rS3cr3t",
    8,
    "ABCDEFGHJKLMNPQRSTUWXYZ0123456789"
    );

var numbers = new []
{
    1,
    2,
    3,
    4,
    5,
    15897,
    15898,
    15899
};
foreach (var number in numbers)
{
    var encoded = hashids.Encode(number);
    Console.WriteLine($"{number} => {encoded}");

    var decoded = hashids.DecodeSingle(encoded);
    Console.WriteLine($"{encoded} => {decoded}");
    
    Console.WriteLine();
}

var encodedNumbers = hashids.Encode(numbers);
Console.WriteLine($"[{string.Join(", ", numbers)}] => {encodedNumbers}");

var decodedNumbers = hashids.Decode(encodedNumbers);
Console.WriteLine($"{encodedNumbers} => [{string.Join(", ", decodedNumbers)}]");

Console.ReadLine();