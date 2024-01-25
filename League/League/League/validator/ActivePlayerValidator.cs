using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.validator
{
    class ActivePlayerValidator : IValidator<ActivePlayer>
    {
        public void Validate(ActivePlayer activePlayer)
        {
            string errors = "";

            int id = activePlayer.Id;
            if (id.Equals(""))
                errors += "\nInvalid id of the active player!";
            try
            {
                if (id <= 0)
                    errors += "\nThe id of the active player must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the active player!";
            }

            int idMatch = activePlayer.IdMatch;
            if (id.Equals(""))
                errors += "\nInvalid id match!";
            try
            {
                if (idMatch <= 0)
                    errors += "\nThe id of the match must be an integer greater than zero!";
            }
            catch (Exception)
            {
                errors += "\nInvalid id of the match!";
            }

            //if (!errors.Equals(""))
                //throw new ValidationException(errors);
        }
    }
}
