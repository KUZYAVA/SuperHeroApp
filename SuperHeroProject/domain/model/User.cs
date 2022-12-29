namespace SuperHeroBackend.domain.model
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record User(
        string Id,
        string UserName,
        string Password,
        int AmountOfCoins
    );
}