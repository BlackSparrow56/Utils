using System;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Nodes.Splitters.Interfaces;

namespace ESparrow.Utils.Nodes.Splitters
{
    public class Splitter<TNode, TId> : SplitterBase<TNode, TId>
    {
        public Splitter(Func<TNode, TId> generateId)
        {
            _generateId = generateId;
        }

        private readonly Func<TNode, TId> _generateId;

        protected override TId GenerateId(TNode customer)
        {
            return _generateId.Invoke(customer);
        }
    }

    public class Splitter<TChannel> : Splitter<TChannel, TChannel>, ISplitter<TChannel>
    {
        public Splitter() : base(UniversalHelper.Self)
        {
            
        }

        public void Fire(Action<TChannel> action)
        {
            Fire(Execute);

            void Execute(TChannel channel, TChannel _)
            {
                action.Invoke(channel);
            }
        }
    }
}