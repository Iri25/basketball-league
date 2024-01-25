using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.validator
{
    class TeamValidator : IValidator<Team>
    {
        public void Validate(Team team)
        {
            string errors = "";

            int id = team.Id;
            if (id.Equals(""))
                errors += "\n Invalid id team!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the team  must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the team!";
            }

            string name = team.Name;
            if (name.Equals(""))
                errors += "\n Invalid name!";

           // if (!errors.Equals(""))
              //  throw new ValidationException(errors);
        }
    }
}
