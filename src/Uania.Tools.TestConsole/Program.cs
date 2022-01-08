// See https://aka.ms/new-console-template for more information
using Uania.Tools.Infrastructure.MD5Services.Impl;
{
    var md5 = new MD5ServiceImpl();

    var cipherText = md5.EncryptStringWithSalt("1234566");
    var isCompair = md5.CompairWithSaltText("1234566", cipherText);
    Console.WriteLine($"cipherText:{cipherText} isCompair:{isCompair}");
}
Console.WriteLine("Hello, World!");
