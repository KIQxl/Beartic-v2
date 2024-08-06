using Beartic.Shared.ValueObjects;

namespace Beartic.Core.ValueObjects
{
    public class Images : ValueObject
    {
        public Images(string firstImageUrl, string? secondImageUrl, string? thirdImageUrl)
        {
            FirstImageUrl = firstImageUrl;
            SecondImageUrl = secondImageUrl;
            ThirdImageUrl = thirdImageUrl;
        }

        public string FirstImageUrl { get; private set; } = string.Empty;
        public string? SecondImageUrl { get; private set; } = string.Empty;
        public string? ThirdImageUrl { get; private set; } = string.Empty;
    }
}
