using System;
using System.Text;
using System.Security.Cryptography;
using BlazorCurseach.Models;

namespace BlazorCurseach.Interfaces;

    public interface IHash 
    {
        public string CalculateHashData(string nonHashData);
    }