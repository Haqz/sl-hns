using Exiled.API.Interfaces;

namespace HideAndSeek
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public bool Debug { get; set; }
        public float SeekerWeight { get; set; } = 0.1f;
    }
}