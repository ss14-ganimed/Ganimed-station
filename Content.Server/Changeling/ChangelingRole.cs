using Content.Server.Chat.Managers;
using Content.Server.Roles;
using Content.Shared.Roles;

namespace Content.Server.Changeling
{
    public sealed class ChangelingRole : Role
    {
        public AntagPrototype Prototype { get; }

        public ChangelingRole(Mind.Mind mind, AntagPrototype antagPrototype) : base(mind)
        {
            Prototype = antagPrototype;
            Name = Loc.GetString(antagPrototype.Name);
            Antagonist = antagPrototype.Antagonist;
        }

        public override string Name { get; }
        public override bool Antagonist { get; }

        public void GreetTraitor()
        {
            if (Mind.TryGetSession(out var session))
            {
                var chatMgr = IoCManager.Resolve<IChatManager>();
                chatMgr.DispatchServerMessage(session, Loc.GetString("changeling-role-greeting"));
            }
        }
    }
}