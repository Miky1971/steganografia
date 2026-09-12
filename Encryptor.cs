using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

public static class Encryptor
{
	public static void Encrypt(string fileIn, string fileOut, string pass)
	{
        byte[] plaintext = File.ReadAllBytes(fileIn);
        // Szkic — wyprowadzenie klucza z hasła
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] key = Rfc2898DeriveBytes.Pbkdf2(pass, salt, 100_000, HashAlgorithmName.SHA256, 32);

        // Szyfrowanie AES-GCM
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        byte[] tag = new byte[16];
        byte[] ciphertext = new byte[plaintext.Length];
        using var aes = new AesGcm(key, tag.Length);

        // tu jest logika biznesowa, i nie rzucam wyjątków
        aes.Encrypt(nonce, plaintext, ciphertext, tag);
        byte[] result = [.. salt, .. nonce, .. tag, .. ciphertext]; // zapis do pliku wyjściowego: salt + nonce + tag + ciphertext
        File.WriteAllBytes(fileOut, result);
        
    }

    public static void Decrypt(string fileIn, string fileOut, string pass)
    {
        byte[] encryptedData = File.ReadAllBytes(fileIn);
        byte[] salt = encryptedData[0..16];        // pierwsze 16 bajtów
        byte[] nonce = encryptedData[16..28];      // kolejne 12 bajtów (16 do 28)
        byte[] tag = encryptedData[28..44];        // kolejne 16 bajtów (28 do 44)
        byte[] ciphertext = encryptedData[44..];   // wszystko od 44 do końca
        
        byte[] key = Rfc2898DeriveBytes.Pbkdf2(pass, salt, 100_000, HashAlgorithmName.SHA256, 32);
        byte[] plaintext = new byte[ciphertext.Length];
        using var aes = new AesGcm(key, tag.Length);
        
        // tu jest logika biznesowa, i nie rzucam wyjątków
        aes.Decrypt(nonce, ciphertext, tag, plaintext);
        File.WriteAllBytes(fileOut, plaintext);
        
    }
}
