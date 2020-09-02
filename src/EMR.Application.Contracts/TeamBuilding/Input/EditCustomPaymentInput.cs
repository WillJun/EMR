using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditCustomPaymentInput
    {
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public string Account { get; set; }
        public double Amount { get; set; }

    }
}
