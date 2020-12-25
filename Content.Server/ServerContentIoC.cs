using Robust.Shared.IoC;

namespace Content.Server
{
    internal static class ServerContentIoC
    {
        public static void Register()
        {
            IoCManager.Register<ExperienceManager, ExperienceManager>();
            // DEVNOTE: IoCManager registrations for the server go here and only here.
        }
    }
}