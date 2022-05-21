using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinTur.Exceptions;

namespace MinTur.Domain.BusinessEntities
{
    public class ChargingSpot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public string Description { get; set; }

        public virtual void ValidOrFail()
        {
            ValidateName();
            ValidateAddress();
            ValidateDescription();
        }

        private void ValidateName()
        {
            Regex nameRegex = new Regex("^[a-zA-Z0-9 ]*$");

            if (Name == null || Name.Length > 20 || !nameRegex.IsMatch(Name))
                throw new InvalidRequestDataException("the name must be alphanumeric with a maximum of 20 characters");
        }

        private void ValidateAddress()
        {
            Regex addressRegex = new Regex("^[a-zA-Z0-9 ]*$");

            if (Address == null || Address.Length > 30 || !addressRegex.IsMatch(Address))
                throw new InvalidRequestDataException("the address must be alphanumeric with a maximum of 30 characters");
        }

        private void ValidateDescription()
        {
            Regex descriptionRegex = new Regex("^[a-zA-Z0-9 ]*$");

            if (Description == null || Description.Length > 60 || !descriptionRegex.IsMatch(Description))
                throw new InvalidRequestDataException("the description must be alphanumeric with a maximum of 60 characters");
        }
    }

}
