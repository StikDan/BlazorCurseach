using System;
using System.Text;
using System.Security.Cryptography;
using BlazorCurseach.Interfaces;
using BlazorCurseach.Models;

namespace BlazorCurseach.Services;

public class HashService : IHash
{
    public string CalculateHashData(string nonHashData)
    {
        SHA1 sha1Hash = SHA1.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(nonHashData);
        byte[] hashBytes = sha1Hash.ComputeHash(bytes);

        StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
    }
}