﻿namespace WPF.Services;

public static class CodePersonne
{
    public static string CreationCode(string prefixe) => $"{prefixe!}-{Guid.NewGuid().ToString().ToUpper().Substring(0, 6)}";
}
