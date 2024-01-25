using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.validator
{
    class MatchValidator : IValidator<Match>
    {
        public void Validate(Match match)
        {
            string errors = "";

            int id = match.Id;
            if (id.Equals(""))
                errors += "\n Invalid id match!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the match must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the match!";
            }

            // if (!errors.Equals(""))
            //  throw new ValidationException(errors);
        }
    }
}
