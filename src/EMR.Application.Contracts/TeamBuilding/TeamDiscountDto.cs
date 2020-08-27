using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class TeamDiscountDto
    {
        public Guid TeamId { get; set; }
        public bool IsDisable { get; set; }

        public double FullAmount { get; set; }

        public string Operation { get; set; }

        public double Discount { get; set; }
        public string Discription { get; set; }
    }
}
