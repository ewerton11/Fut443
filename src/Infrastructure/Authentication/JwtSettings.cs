﻿namespace Infrastructure.Authentication;

public class JwtSettings
{
    public string SecretKey { get; init; } = null!;
    public int ExpiryMinutes { get; init; } = 60;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}
