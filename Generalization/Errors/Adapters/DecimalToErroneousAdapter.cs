using System;
using ESparrow.Utils.Generalization.Types.Enums;

namespace ESparrow.Utils.Generalization.Errors.Adapters
{
    public class DecimalToErroneousAdapter : ToErroneousAdapterBase<decimal>
    {
        public override decimal DefaultError => (decimal) double.Epsilon;

        public DecimalToErroneousAdapter(decimal value) : base(value)
        {

        }

        protected override bool CompareWithError(decimal self, decimal other, decimal error)
        {
            return Math.Abs(other - self) <= error;
        }

        public override EGeneralizationType GeneralizationType => EGeneralizationType.Decimal;
    }
}
